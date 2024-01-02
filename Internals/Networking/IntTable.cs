using System.Text;
using System.Text.RegularExpressions;
using VEconomy.Internals.FileSystem;

namespace VEconomy.Internals.Networking
{
	internal class IntTable : VCollection<IntRecord>
	{

		/// <summary>
		/// The name of the database table.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// The columns of the table.
		/// </summary>
		public string[] ColumnNames { get; protected set; } = [];

		public ColumnCollection Columns { get; protected set; } = [];

		private string? _saveDirectoryPath;
		/// <summary>
		/// Gets or sets the save directory path.
		/// </summary>
		public string SaveDirectoryPath
		{
			get => _saveDirectoryPath??"";
			set
			{
				string path=Path.GetFullPath(value);
				bool hasExt=Path.HasExtension(path);
				string dir=hasExt ? Path.GetDirectoryName(path)! : path;
				if(!Directory.Exists(dir))
					Directory.CreateDirectory(dir);
				_saveDirectoryPath=dir;
			}
		}


		/// <summary>
		/// Creates a new instance of the <see cref="IntTable"/> class.
		/// </summary>
		/// <param name="name"></param>
		public IntTable(string name) : this(name, null) { }
		/// <inheritdoc cref="IntTable(string)"/>
		/// <param name="name"></param>
		/// <param name="records"></param>
		public IntTable(string name, IEnumerable<IntRecord>? records) : this(name, Environment.CurrentDirectory, records) { }
		/// <inheritdoc cref="IntTable(string)"/>
		/// <param name="name"></param>
		/// <param name="saveDirectoryPath"></param>
		/// <param name="records"></param>
		public IntTable(string name, string saveDirectoryPath, IEnumerable<IntRecord>? records)
		{
			Name=name;
			if(records is not null)
				Items=records.ToArray();
			Added+=UpdateColumnCollection;
			Removed+=UpdateColumnCollection;
			Updated+=UpdateColumnCollection;
			SaveDirectoryPath=saveDirectoryPath;
		}

		private void UpdateColumnCollection(object sender, object? output)
		{
			ColumnNames=GetColumnNames();
		}

		private string[] GetColumnNames() => Items.Length>0 ? Items[^1].GetColumnNames() : [];
		/// <summary>
		/// Adds a new record with the given arguments.
		/// </summary>
		/// <param name="args"></param>
		public void AddRaw(params object[] args)
		{
			if(args.Length<ColumnNames.Length)
			{
				IntRecord ins=new IntRecord();
				for(int i = 0;i<ColumnNames.Length;i++)
					if(i<args.Length)
						ins.Add(CreateNewItem(ColumnNames[i], args[i]));
				Add(ins);
			}
		}

		public void AddColumn(string name, ColumnType type) => AddColumn(new (name, type));

		public void AddColumn(DatabaseTableColumn column) => Columns.Add(column);

		private static IntRecordItem CreateNewItem(string name, object value) => new IntRecordItem(name, value);

		public async void Save()
		{
			await File.WriteAllBytesAsync(Path.Combine(SaveDirectoryPath, Name+".csv"), GenerateCsv());
		}

		public void Load(string tableName)
		{
			string? path=FindFile(tableName);
			if(path is not null)
				PopulateTableFromData(path.GetFileContents());
		}

		private void PopulateTableFromData(string data)
		{
			string[] columns=GetColumnsFromData(GetCsvHeaderString(data));
			string body=GetCsvBodyString(data);
			string[] rawRows=GetRowsFromBody(body);
			foreach(var sel in rawRows)
			{
				IntRecord res=[];
				string[] rowValues=GetRowData(sel);
				for(int i=0;i<columns.Length;i++)
					res.Add(new IntRecordItem(columns[i], i<rowValues.Length ? rowValues[i] : null));
				Add(res);
			}
		}

		protected static string[] GetRowsFromBody(string bodyString) => bodyString.Split('\n');

		protected static string[] GetRowData(string rowString) => rowString.Split(',');

		protected static string[] GetColumnsFromData(string headerString) => headerString.Trim().Split(',');

		protected static string GetCsvHeaderString(string data) => Regex.Match(data, @"(?<header>[^\n]+)").Groups["header"].Value;

		protected static string GetCsvBodyString(string data) => Regex.Match(data, @"[^\n]+[\n]+(?<body>.+)").Groups["body"].Value;

		protected string? FindFile(string tableName) => GetClosestMatch(tableName, SaveDirectoryPath.GetFiles());

		protected static bool Contains(string fileName, string[] array) => array.Any(q=>IEquals(Path.GetFileNameWithoutExtension(q), fileName));

		protected static string? GetClosestMatch(string fileName, string[] array)
		{
			foreach(var sel in array)
				if(IEquals(Path.GetFileNameWithoutExtension(sel), fileName))
					return sel;
			return null;
		}

		protected static bool IEquals(string a, string b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase);

		protected byte[] GenerateCsv(Encoding? encoding=null) => (encoding??Encoding.Unicode).GetBytes(GetCsv());

		private string GetCsv()
		{
			string res="";
			foreach(var sel in this)
				res+="\r\n"+sel.ToString();
			return res;
		}

		private string GenerateHeader()
		{
			string res="";
			foreach(var sel in ColumnNames)
				res+=(res.Length>0 ? "," : "") + GetFriendlyValue(sel);
			return res;
		}

		private static string GetFriendlyValue(string value) => IntRecord.GetString(value);


		public string GenerateSqlQuery()
		{
			string res="";

			return res;
		}

		protected string GetColumnSql()
		{
			string res="";
			foreach(var sel in ColumnNames)

			return res;
		}


	}
}