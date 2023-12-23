namespace VEconomy
{
	/// <summary>
	/// Stores tax information.
	/// </summary>
	public struct TaxRateItem
	{
		/// <summary>
		/// The name of this item.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// The description of this item.
		/// </summary>
		public readonly string Description;
		/// <summary>
		/// The tax percentage value.
		/// </summary>
		public double Value { get; set; }


		/// <summary>
		/// Creates a new instance of the <see cref="TaxRateItem"/> struct object.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="description"></param>
		/// <param name="initialValue"></param>
		public TaxRateItem(string name, string description, double initialValue)
		{
			Name=name;
			Description=description;
			Value=initialValue;
		}
		/// <inheritdoc cref="TaxRateItem(string, double)"/>
		public TaxRateItem(string name) : this(name, "", 0) { }
		/// <inheritdoc cref="TaxRateItem(string, double)"/>
		public TaxRateItem(string name, double initialValue) : this(name, "", initialValue) { }
		/// <inheritdoc cref="TaxRateItem(string, double)"/>
		public TaxRateItem(string name, string description) : this(name, description, 0) { }


	}
}
