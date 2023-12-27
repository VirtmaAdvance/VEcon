using VEconomy.Internals.ObjectExtensions;
using VEconomy.Internals.Strings;

namespace VEconomy.Internals.FileSystem
{
	internal static class IntStringFileExistsExt
	{
		/// <inheritdoc cref="IntObjectNullValidationExt.IsNull(object?)" path="//*[not(self::summary) and not(self::param)]"/>
		/// <summary>
		/// Determines if the <paramref name="path"/> references an existing file path.
		/// </summary>
		/// <param name="path">The <see cref="string"/> representation of a file path to check.</param>
		public static bool IsFile(this string? path) => path.IsValid() && File.Exists(path);
		/// <inheritdoc cref="IntObjectNullValidationExt.IsNull(object?)" path="//*[not(self::summary) and not(self::param)]"/>
		/// <summary>
		/// Determines if the <paramref name="path"/> is valid for reading.
		/// </summary>
		/// <param name="path">The path of an existing file.</param>
		public static bool IsFileValid(this string? path) => path.GetFileSize() > 0;

	}
}