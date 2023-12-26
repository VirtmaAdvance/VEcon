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


		/// <summary>
		/// Creates a new instance of the <see cref="IntTable"/> class.
		/// </summary>
		/// <param name="name"></param>
		public IntTable(string name)
		{
			Name=name;
			Added+=UpdateColumnCollection;
			Removed+=UpdateColumnCollection;
			Updated+=UpdateColumnCollection;
		}
		/// <inheritdoc cref="IntTable(string)"/>
		/// <param name="name"></param>
		/// <param name="records"></param>
		public IntTable(string name, IEnumerable<IntRecord> records)
		{
			Name=name;
			Items=records.ToArray();
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


	}
}