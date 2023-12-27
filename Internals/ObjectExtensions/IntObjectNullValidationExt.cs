namespace VEconomy.Internals.ObjectExtensions
{
	internal static class IntObjectNullValidationExt
	{
		/// <summary>
		/// Determines if the <paramref name="value"/> is <see langword="null"/>.
		/// </summary>
		/// <param name="value">Any <see cref="object"/>.</param>
		/// <returns>a <see cref="bool">boolean</see> value where <see cref="bool">true</see> represents success, and <see cref="bool">false</see> represents otherwise.</returns>
		public static bool IsNull(this object? value) => value is null;
		/// <inheritdoc cref="IntObjectNullValidationExt.IsNull(object?)" path="//*[not(self::summary)]"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> is not <see langword="null"/>.
		/// </summary>
		public static bool NotNull(this object? value) => !value.IsNull();

	}
}