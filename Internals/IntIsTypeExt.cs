using VEconomy.Internals.ObjectExtensions;

namespace VEconomy.Internals
{
	internal static class IntIsTypeExt
	{
		/// <summary>
		/// Determines if the <paramref name="source"/> is a number.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNumber(this object source) => source.Is(typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal), typeof(nint));

	}
}