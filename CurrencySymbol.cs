namespace VEconomy
{
	/// <summary>
	/// Provides a symbol struct configuration object.
	/// </summary>
	/// <remarks>
	/// Creates a new instance of the <see cref="CurrencySymbol"/> struct object.
	/// </remarks>
	/// <param name="value"></param>
	/// <param name="alignment"></param>
	public readonly struct CurrencySymbol(string value, SymbolAlignment alignment)
	{
		/// <summary>
		/// The symbol to be used.
		/// </summary>
		public readonly string Value=value;
		/// <summary>
		/// The alignment of the symbol relative to the currency value.
		/// </summary>
		public readonly SymbolAlignment Alignment=alignment;


		/// <inheritdoc cref="CurrencySymbol(string, SymbolAlignment)"/>
		public CurrencySymbol(string value) : this(value, SymbolAlignment.Left) { }
	}
}
