namespace VEconomy.Internals.Networking
{
	internal struct IntRecordItem
	{

		/// <summary>
		/// The name of the record.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// The value of the record.
		/// </summary>
		public readonly object? Value;


		/// <summary>
		/// Creates a new instance of the <see cref="IntRecord"/> class object.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public IntRecordItem(string name, object? value)
		{
			Name=name;
			Value=value;
		}

	}
}