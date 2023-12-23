using System.Collections;

namespace VEconomy
{
	/// <summary>
	/// Stores a collection of currencies and their relative global worth scale.
	/// </summary>
	public class CurrencyWorth : VCollection<CurrencyWorthItem>
	{


		private void Update(string name, CurrencyWorthItem item) => Update(IndexOf(name), item);

		private void Update(int index, CurrencyWorthItem item)
		{
			if(IsIndexValid(index))
				Items[index]=item;
		}

		public int IndexOf(string name)
		{
			for(int i=0;i<Length;i++)
				if(Items[i].Name.Equals(name))
					return i;
			return -1;
		}

	}
}
