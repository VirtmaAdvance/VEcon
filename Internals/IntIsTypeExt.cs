namespace VEconomy.Internals
{
	internal static class IntIsTypeExt
	{
		/// <summary>
		/// Determines if the <paramref name="source"/> is any of the given <paramref name="types"/>.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="types"></param>
		/// <returns></returns>
		public static bool Is(this object source, params Type[] types)
		{
			Type type=source.GetType();
			return types.Any(q=>q.IsAssignableFrom(type));
		}
		/// <summary>
		/// Determines if the <paramref name="source"/> is a number.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNumber(this object source) => source.Is(typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal), typeof(nint));

	}
}