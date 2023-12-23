namespace VEconomy
{
	/// <summary>
	/// Provides a means to specify a range between two values.
	/// </summary>
	/// <remarks>
	/// Creates a new Vector 2 range object.
	/// </remarks>
	/// <param name="minimum"></param>
	/// <param name="maximum"></param>
	public readonly struct V2Range(double minimum, double maximum)
	{
		/// <summary>
		/// The minimum value.
		/// </summary>
		public readonly double Minimum=minimum;
		/// <summary>
		/// The maximum value.
		/// </summary>
		public readonly double Maximum=maximum;

		/// <summary>
		/// Determines if the <paramref name="value"/> is within the minimum and maximum values.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool IsInRange(double value) => value>=Minimum && value<=Maximum;

	}
}