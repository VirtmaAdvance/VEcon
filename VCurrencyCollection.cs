namespace VEconomy
{
	public class VCurrencyCollection : VCollection<VCurrency>
	{
		/// <summary>
		/// Gets or sets the item in this collection.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public VCurrency this[string name]
		{
			get => this[IndexOf(name)];
			set => this[IndexOf(name)]=value;
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