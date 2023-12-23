namespace VEconomy
{
	/// <summary>
	/// Stores an individual dollar amount.
	/// </summary>
	/// <remarks>Designed to function similar to money in a wallet.</remarks>
	/// <remarks>
	/// Creates a new instance of the <see cref="VMoney"/> struct object.
	/// </remarks>
	/// <param name="currencyType">The currency type being used for this item.</param>
	/// <param name="initialValue">The initial value to set for this object.</param>
	public struct VMoney(VCurrency currencyType, double initialValue) : IEquatable<VMoney>
	{
		/// <summary>
		/// The currency type being used for this item.
		/// </summary>
		public readonly VCurrency CurrencyType=currencyType;
		/// <summary>
		/// The current value/amount of this object.
		/// </summary>
		public double Value { get; set; } = initialValue;


		/// <inheritdoc cref="VMoney(VCurrency, double)"/>
		public VMoney(VCurrency currencyType) : this(currencyType, 0.0) { }
		/// <inheritdoc cref="UnitSymbol.ToString(double, string)"/>
		public readonly string ToString(string format) => CurrencyType.ToString(Value, format);
		/// <inheritdoc cref="UnitSymbol.ToString(double, string)"/>
		public new readonly string ToString() => CurrencyType.ToString(Value);
		/// <summary>
		/// Adds the <paramref name="value"/> to the currennt value stored in this object.
		/// </summary>
		/// <param name="value"></param>
		public void Add(double value) => Value+=value;

		public bool Equals(VMoney other) => CurrencyType.Equals(other.CurrencyType);

		public static bool operator ==(VMoney a, VMoney b) => a.Equals(b) && a.Value.Equals(b.Value);

		public static bool operator !=(VMoney a, VMoney b) => !(a==b);

		public static VMoney operator +(VMoney x, VMoney y)
		{
			if(x.Equals(y))
				return new(x.CurrencyType, x.Value+y.Value);
			else
			{

			}
		}

	}
}