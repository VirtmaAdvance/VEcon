using VEconomy.Internals.Strings;

namespace VEconomy.Internals.FileSystem
{
	internal static class IntDirectoryExistsExt
	{
		/// <inheritdoc cref="ObjectExtensions.IntObjectNullValidationExt.IsNull(object?)" path="//*[not(self::summary) and not(self::param)]"/>
		/// <summary>
		/// Determines if the <paramref name="path"/> references an existing directory path.
		/// </summary>
		/// <param name="path">The path to analyze.</param>
		public static bool IsDirectory(this string? path) => path.IsValid() && Directory.Exists(path!);

	}
}