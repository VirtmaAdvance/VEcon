namespace VEconomy
{
	/// <summary>
	/// Provides alignment options for a currency symbol.
	/// </summary>
	[Flags]
	public enum SymbolAlignment
	{
		/// <summary>
		/// Aligns the symbol to the left of the currency value.
		/// </summary>
		Left=0x0,
		/// <summary>
		/// Aligns the symbol to the right of the currency value.
		/// </summary>
		Right=0x1,
	}
}
