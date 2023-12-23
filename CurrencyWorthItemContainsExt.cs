namespace VEconomy
{
	public static class CurrencyWorthItemContainsExt
	{
		/// <summary>
		/// Determines if the item collection contains the item.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public static bool Contains(this CurrencyWorthItem[] source, CurrencyWorthItem item) => source.Any(q=>q.Equals(item));
		/// <inheritdoc cref="Contains(CurrencyWorthItem[], CurrencyWorthItem)"/>
		/// <param name="source"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static bool Contains(this CurrencyWorthItem[] source, string name) => source.Any(q=>q.Name.Equals(name));
		/// <inheritdoc cref="Contains(CurrencyWorthItem[], CurrencyWorthItem)"/>
		/// <param name="source"></param>
		/// <param name="currencyType"></param>
		/// <returns></returns>
		public static bool Contains(this CurrencyWorthItem[] source, VCurrency currencyType) => source.Any(q=>q.CurrencyType.Equals(currencyType));

	}
}