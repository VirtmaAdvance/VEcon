using System.Text;

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
		public string[] Columns { get; protected set; } = [];

		private string _saveDirectoryPath;
		/// <summary>
		/// Gets or sets the save directory path.
		/// </summary>
		public string SaveDirectoryPath
		{
			get => _saveDirectoryPath;
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
		public IntTable(string name, IEnumerable<IntRecord>? records)
		{
			Name=name;
			if(records is not null)
				Items=records.ToArray();
			Added+=UpdateColumnCollection;
			Removed+=UpdateColumnCollection;
			Updated+=UpdateColumnCollection;
		}

		private void UpdateColumnCollection(object sender, object? output)
		{
			Columns=GetColumnNames();
		}

		private string[] GetColumnNames() => Items.Length>0 ? Items[^1].GetColumnNames() : [];

		/// <summary>
		/// Adds a new record with the given arguments.
		/// </summary>
		/// <param name="args"></param>
		public void AddRaw(params object[] args)
		{
			if(args.Length<Columns.Length)
			{
				IntRecord ins=new IntRecord();
				for(int i = 0;i<Columns.Length;i++)
					if(i<args.Length)
						ins.Add(CreateNewItem(Columns[i], args[i]));
				Add(ins);
			}
		}

		private static IntRecordItem CreateNewItem(string name, object value) => new IntRecordItem(name, value);

		public async void Save()
		{
			await File.WriteAllBytesAsync(Path.Combine(SaveDirectoryPath, Name+".csv"), GenerateCsv());
		}

		public void Load(string tableName)
		{
			// Code to read the csv file and then create the records for each row and column.
		}

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
			foreach(var sel in Columns)
				res+=(res.Length>0 ? "," : "") + GetFriendlyValue(sel);
			return res;
		}

		private static string GetFriendlyValue(string value) => IntRecord.GetString(value);


	}
}