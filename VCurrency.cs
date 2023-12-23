namespace VEconomy
{
	public class VCurrency
	{
		/// <summary>
		/// The name of the currency.
		/// </summary>
		public string Name { get; protected set; } = "";
		/// <summary>
		/// The <see cref="CurrencySymbol"/> configuration.
		/// </summary>
		public CurrencySymbol Symbol { get; protected set; }
		/// <summary>
		/// The minimum value that can be distributed.
		/// </summary>
		public double Minimum { get; set; } = 0.01;
		private UnitSymbol[] _unitSymbols=[];
		/// <summary>
		/// A set of unit symbols that are used to simplify the currency value.
		/// </summary>
		/// <remarks>Automatically sorts the array from lowest minimum value to highest.</remarks>
		public UnitSymbol[] UnitSymbols
		{
			get => _unitSymbols;
			set
			{
				_unitSymbols=value;
				Array.Sort(_unitSymbols);
			}
		}


		/// <summary>
		/// Gets the <see cref="UnitSymbol"/> that best fits for the <paramref name="value"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public UnitSymbol GetUnitSymbol(double value) => UnitSymbols.FirstOrDefault(q => q.IsInRange(value));
		/// <inheritdoc cref="UnitSymbol.ToString(double, string)"/>
		public string ToString(double value, string format) => GetUnitSymbol(value).ToString(value, format);
		/// <inheritdoc cref="UnitSymbol.ToString(double, string)"/>
		public string ToString(double value) => GetUnitSymbol(value).ToString(value);

	}
}