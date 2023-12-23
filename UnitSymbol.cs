using VEconomy.Internals;

namespace VEconomy
{
	/// <summary>
	/// Stores unit symbol information.
	/// </summary>
	/// <remarks>
	/// Creates a new instance of the <see cref="UnitSymbol"/> struct object.
	/// </remarks>
	/// <param name="value">The unit symbol to display.</param>
	/// <param name="applyRange">The range to apply the symbol.</param>
	/// <param name="decimalPlaces">The number of decimal places to include when simplified.</param>
	public readonly struct UnitSymbol(string value, V2Range applyRange, int decimalPlaces) : IComparable
	{
		/// <summary>
		/// The unit symbol to display.
		/// </summary>
		public readonly string Value=value;
		/// <summary>
		/// The range when to apply the unit symbol.
		/// </summary>
		public readonly V2Range ApplyRange=applyRange;
		/// <summary>
		/// The number of decimal places to include in the simplification process.
		/// </summary>
		public readonly int DecimalPlaces=decimalPlaces;


		/// <inheritdoc cref="UnitSymbol(string, V2Range)"/>
		public UnitSymbol(string value, V2Range applyRange) : this(value, applyRange, 2) { }
		/// <inheritdoc cref="UnitSymbol(string, V2Range)"/>
		/// <param name="value">The unit symbol to display.</param>
		/// <param name="minimum">Apply the symbol when the value reaches this minimum.</param>
		/// <param name="maximum">Stop applying the symbol when the value reaches this maximum.</param>
		public UnitSymbol(string value, double minimum, double maximum) : this(value, new(minimum, maximum)) { }
		/// <summary>
		/// Compares this object with another object. Used to sort an array of <see cref="UnitSymbol"/>s in order from the lowest minimum value.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int CompareTo(object? obj)
		{
			if(obj is UnitSymbol objUnitSym)
			{
				double objMin=objUnitSym.ApplyRange.Minimum;
				return objMin<ApplyRange.Minimum ? -1 : objMin>ApplyRange.Minimum ? 1 : 0;
			}
			return 0;
		}
		/// <inheritdoc cref="V2Range.IsInRange(double)"/>
		public bool IsInRange(double value) => ApplyRange.IsInRange(value);
		/// <summary>
		/// Simplifies the <paramref name="value"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public double Simplify(double value)
		{
			if(IsInRange(value))
			{
				var dp=Math.Pow(10,DecimalPlaces);
				return Math.Floor((value/ApplyRange.Minimum)*dp)/dp;
			}
			return value;
		}
		/// <summary>
		/// Gets the <see cref="string"/> representation of this object with the <paramref name="value"/> simplified and it's symbol appended.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string ToString(double value) => ToString(value, "###."+("#".Repeat(DecimalPlaces))+"[S]");
		/// <inheritdoc cref="ToString(double)"/>
		/// <param name="value"></param>
		/// <param name="format">
		/// The format to use.
		/// <para>
		/// Use <see langword="[S]"/> to specify the location of the symbol.
		/// </para>
		/// <para>
		/// Use <see langword="#"/> to specify a digit.
		/// </para>
		/// <para>
		/// Use <see langword="."/> to specify the decimal location.
		/// </para>
		/// <para>
		/// Use of any other character will be directly inserted into the string.
		/// </para>
		/// </param>
		/// <returns></returns>
		public string ToString(double value, string format) => string.Format("{0:"+format+"}", Simplify(value).ToString()).Replace(@"\[S\]", Value);

	}
}
