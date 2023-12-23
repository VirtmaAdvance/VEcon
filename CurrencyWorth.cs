using System.Collections;

namespace VEconomy
{
	/// <summary>
	/// Stores a collection of currencies and their relative global worth scale.
	/// </summary>
	public class CurrencyWorth : IEnumerable<CurrencyWorthItem>
	{

		private CurrencyWorthItem[]? _items;

		public CurrencyWorthItem[] Items
		{
			get => _items is not null ? _items : Array.Empty<CurrencyWorthItem>();
			set => _items = value;
		}
		/// <summary>
		/// Gets the length of the collection.
		/// </summary>
		public int Length => Items.Length;



		public void Add(CurrencyWorthItem item)
		{
			int index=IndexOf(item);
			if(index!=-1)
				Push(item);
		}

		private void Push(CurrencyWorthItem item)
		{
			Array.Resize(ref _items, Length);
			_items[^1]=item;
		}

		private void Update(string name, CurrencyWorthItem item) => Update(IndexOf(name), item);

		private void Update(int index, CurrencyWorthItem item)
		{
			if(IsIndexValid(index))
				Items[index]=item;
		}

		public void RemoveAt(int index)
		{
			if(IsIndexValid(index))
			{

			}
		}







		private bool IsIndexValid(int index) => index>-1 && index<Length;

		public int IndexOf(CurrencyWorthItem item)
		{
			for(int i=0;i<Length;i++)
				if(Items[i].Equals(item))
					return i;
			return -1;
		}

		public int IndexOf(string name)
		{
			for(int i=0;i<Length;i++)
				if(Items[i].Name.Equals(name))
					return i;
			return -1;
		}

		public IEnumerator<CurrencyWorthItem> GetEnumerator() => (IEnumerator<CurrencyWorthItem>)Items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

	}
}
