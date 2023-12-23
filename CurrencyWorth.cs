namespace VEconomy
{
	/// <summary>
	/// Stores a collection of currencies and their relative global worth scale.
	/// </summary>
	public class CurrencyWorth : VCollection<CurrencyWorthItem>
	{

		/// <summary>
		/// Gets or sets the item at the given key/index.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public CurrencyWorthItem this[string key]
		{
			get=>this[IndexOf(key)];
			set=>this[IndexOf(key)]=value;
		}


		private void Update(string name, CurrencyWorthItem item) => Update(IndexOf(name), item);

		private void Update(int index, CurrencyWorthItem item)
		{
			if(IsIndexValid(index))
				Items[index]=item;
		}
		/// <inheritdoc cref="VCollection.IndexOf(T)"/>
		public int IndexOf(string name)
		{
			for(int i=0;i<Length;i++)
				if(Items[i].Name.Equals(name))
					return i;
			return -1;
		}

	}
}
