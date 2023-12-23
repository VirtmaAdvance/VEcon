namespace VEconomy
{
	/// <summary>
	/// Stores tax information.
	/// </summary>
	/// <remarks>
	/// Creates a new instance of the <see cref="TaxRateItem"/> struct object.
	/// </remarks>
	/// <param name="name"></param>
	/// <param name="description"></param>
	/// <param name="initialValue"></param>
	public struct TaxRateItem(string name, string description, double initialValue)
	{
		/// <summary>
		/// The name of this item.
		/// </summary>
		public readonly string Name=name;
		/// <summary>
		/// The description of this item.
		/// </summary>
		public readonly string Description=description;
		/// <summary>
		/// The tax percentage value.
		/// </summary>
		public double Value { get; set; } = initialValue;


		/// <inheritdoc cref="TaxRateItem(string, double)"/>
		public TaxRateItem(string name) : this(name, "", 0) { }
		/// <inheritdoc cref="TaxRateItem(string, double)"/>
		public TaxRateItem(string name, double initialValue) : this(name, "", initialValue) { }
		/// <inheritdoc cref="TaxRateItem(string, double)"/>
		public TaxRateItem(string name, string description) : this(name, description, 0) { }

	}
}