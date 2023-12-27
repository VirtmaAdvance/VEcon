namespace VEconomy.Internals.Enumerables
{
	internal static class IntIterableExt
	{
		/// <summary>
		/// Iterates through the entire array and performs an action on each element.
		/// </summary>
		/// <typeparam name="TIn"></typeparam>
		/// <typeparam name="TOut"></typeparam>
		/// <param name="source"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static TOut[] ForAll<TIn, TOut>(this TIn[]? source, Func<TIn, TOut> predicate)
		{
			source??=[];
			TOut[] res=new TOut[source.Length];
			for(int i=0;i<source.Length;i++)
				res[i]=predicate(source[i]);
			return res;
		}

	}
}