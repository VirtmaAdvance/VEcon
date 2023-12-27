using VEconomy.Internals.ObjectExtensions;

namespace VEconomy.Internals.Strings
{
	internal static class IntStringValueValidationExt
	{
		/// <inheritdoc cref="IntObjectNullValidationExt.IsNull(object?)" path="//*[not(self::summary) and not(self::param)]"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> is a valid <see cref="string"/> where it is not <see langword="null"/> and is not empty (When trimmed of leading and trailing whitespace characters).
		/// </summary>
		/// <param name="value">The <see cref="string"/> value to analyze.</param>
		public static bool IsValid(this string? value) => value.NotNull() && !string.IsNullOrEmpty(value!.Trim());

	}
}