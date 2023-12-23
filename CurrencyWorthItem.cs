namespace VEconomy
{
	/// <summary>
	/// Stores a currency's worth data.
	/// </summary>
	/// <remarks>
	/// Creates a new instance of the <see cref="CurrencyWorthItem"/> struct object.
	/// </remarks>
	/// <param name="currencyType"></param>
	/// <param name="initialWorth"></param>
	public struct CurrencyWorthItem(VCurrency currencyType, double initialWorth)
	{
		/// <summary>
		/// The currency type.
		/// </summary>
		public readonly VCurrency CurrencyType=currencyType;
		/// <summary>
		/// The name of the currency being use.
		/// </summary>
		public readonly string Name => CurrencyType.Name;
		/// <summary>
		/// The worth of the currency.
		/// </summary>
		/// <remarks>Standard worth is set to 0.0. Values below 0 indicates the currency is worth less, as values above 0 indicate the currency is worth more than the global standard.</remarks>
		public double Worth { get; set; } = initialWorth;

		/// <inheritdoc cref="CurrencyWorthItem(VCurrency, double)"/>
		public CurrencyWorthItem(VCurrency currencyType) : this(currencyType, 0.0) { }

	}
}