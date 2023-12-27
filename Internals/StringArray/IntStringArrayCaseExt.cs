using VEconomy.Internals.Enumerables;

namespace VEconomy.Internals.StringArray
{
	internal static class IntStringArrayCaseExt
	{
		/// <summary>
		/// Converts each string to lowercase.
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static string[] ToLower(this string[] array) => array.ForAll(q=>q.ToLower());
		/// <summary>
		/// Converts each string to uppercase.
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static string[] ToUpper(this string[] array) => array.ForAll(q=>q.ToUpper());

	}
}