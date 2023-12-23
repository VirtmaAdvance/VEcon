using System.Text.RegularExpressions;

namespace VEconomy.Internals
{
	internal static class IntStringReplaceExt
	{
		/// <summary>
		/// Performs a regular expression replace operation.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="pattern"></param>
		/// <param name="replacement"></param>
		/// <returns></returns>
		public static string Replace(this string source, string pattern, string replacement) => Regex.IsMatch(source, pattern) ? Regex.Replace(source, pattern, replacement) : source;

	}
}
