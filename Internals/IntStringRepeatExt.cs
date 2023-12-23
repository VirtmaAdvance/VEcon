namespace VEconomy.Internals
{
	internal static class IntStringRepeatExt
	{
		/// <summary>
		/// Repeats a string value a set number of times.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string Repeat(this string value, int count)
		{
			string tmp=value;
			for(int i=0;i<count;i++)
				value+=tmp;
			return value;
		}

	}
}
