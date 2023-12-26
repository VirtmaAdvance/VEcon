using System.Collections;

namespace VEconomy
{
	/// <summary>
	/// Provides a class object for creating a collection of items (Similar to the List class) that can be derived from and provides a more managable and customizable system.
	/// </summary>
	/// <typeparam name="T">The data-type of the items within the collection.</typeparam>
	public class VCollection<T>:IEnumerable<T?>
	{

		private T[]? _items;
		/// <summary>
		/// The collection of items.
		/// </summary>
		public T[] Items
		{
			get => _items is not null ? _items : Array.Empty<T>();
			set => _items = value;
		}
		/// <summary>
		/// Gets the length of the collection.
		/// </summary>
		public int Length => Items.Length;
		/// <summary>
		/// Gets or sets an element at the given <paramref name="index"/> position.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public T this[int index]
		{
			get => IsIndexValid(index) ? Items[index] : throw new ArgumentOutOfRangeException(nameof(index));
			set
			{
				if(IsIndexValid(index))
					Items[index]=value;
				else
					Insert(index, value);
			}
		}


		/// <summary>
		/// Adds an item to the collection.
		/// </summary>
		/// <param name="item"></param>
		public void Add(T item)
		{
			int index=IndexOf(item);
			if(index!=-1)
				Push(item);
		}

		private void Push(T item)
		{
			Array.Resize(ref _items, Length);
			_items[^1]=item;
		}

		private void Update(int index, T item)
		{
			if(IsIndexValid(index))
				Items[index]=item;
		}
		/// <summary>
		/// Removes an item at the given index.
		/// </summary>
		/// <param name="index"></param>
		public void RemoveAt(int index)
		{
			if(IsIndexValid(index))
			{
				T[] items=IterateValidation((q, i)=>i!=index);
				Items=items;
			}
		}
		/// <summary>
		/// Removes the items at the given indices.
		/// </summary>
		/// <param name="indices"></param>
		public void RemoveAt(params int[] indices)
		{
			if(indices.All(index=>IsIndexValid(index)))
			{
				T[] items=IterateValidation((q, i)=>!indices.Contains(i));
				Items=items;
			}
		}
		/// <summary>
		/// Removes an item from the collection.
		/// </summary>
		/// <param name="items"></param>
		public void Remove(params T[] items)
		{
			foreach(var item in items)
				RemoveAt(IndexOf(item));
		}
		/// <summary>
		/// Clears the collection.
		/// </summary>
		public void Clear()
		{
			if(_items is not null)
				Array.Clear(_items);
		}
		/// <summary>
		/// Determines if the collection contains an item.
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(T item) => Items.Contains(item);
		/// <summary>
		/// Performs an action upon each item in the collection and returns the results as a modified array.
		/// </summary>
		/// <typeparam name="TOut"></typeparam>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public TOut[] Iterate<TOut>(Func<T, TOut> predicate)
		{
			TOut[] res=new TOut[Length];
			for(int i=0;i<Length;i++)
				res[i]=predicate(Items[i]);
			return res;
		}
		/// <summary>
		/// Iterates through the collection and returns only items that pass the validation.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public T[] IterateValidation(Func<T, bool> predicate)
		{
			T[] res=[];
			for(int i = 0;i<Length;i++)
				if(predicate(Items[i]))
				{
					Array.Resize(ref res, res.Length+1);
					res[^1]=Items[i];
				}
			return res;
		}
		/// <summary>
		/// Iterates through the collection and returns only items that pass the validation.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public T[] IterateValidation(Func<T, int, bool> predicate)
		{
			T[] res=[];
			for(int i = 0;i<Length;i++)
				if(predicate(Items[i], i))
				{
					Array.Resize(ref res, res.Length+1);
					res[^1]=Items[i];
				}
			return res;
		}
		/// <summary>
		/// Inserts an item into the collection at the given <paramref name="index"/> position.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void Insert(int index, T item)
		{
			if(IsIndexValid(index))
			{
				ShiftRight(index, 1);
				Items[index]=item;
			}
		}
		/// <inheritdoc cref="ShiftLeft(int, int)"/>
		/// <summary>
		/// Shifts the items starting from the <paramref name="startingIndex"/> to the right of the array <paramref name="shiftLength"/> many times.
		/// </summary>
		protected void ShiftRight(int startingIndex, int shiftLength)
		{
			int len=Length;
			for(int i=len;i>=startingIndex;i--)
				Move(i, i+shiftLength);
		}
		/// <summary>
		/// Shifts the items starting from the <paramref name="startingIndex"/> to the left of the array <paramref name="shiftLength"/> many times.
		/// </summary>
		/// <param name="startingIndex">The index to start shifting the elements at.</param>
		/// <param name="shiftLength">The number of places to move the elements by.</param>
		protected void ShiftLeft(int startingIndex, int shiftLength)
		{
			for(int i=startingIndex;i<startingIndex+shiftLength;i++)
				Move(i, i-shiftLength);
		}
		/// <summary>
		/// Prepends an item to the collection.
		/// </summary>
		/// <param name="items"></param>
		public void Prepend(params T[] items)
		{
			int len=items.Length;
			Move(0, len);
			for(int i=0;i<len;i++)
				Items[i]=items[i];
		}
		/// <summary>
		/// Copys the element at the <paramref name="sourceIndex"/> to the <paramref name="destinationIndex"/>.
		/// </summary>
		/// <param name="sourceIndex">The index of the element to move.</param>
		/// <param name="destinationIndex">The index position to move the element at the <paramref name="sourceIndex"/> to.</param>
		protected void Move(int sourceIndex, int destinationIndex)
		{
			if(IsIndexValid(sourceIndex))
			{
				T tmp=Items[sourceIndex];
				if(destinationIndex>=Length)
					Array.Resize(ref _items, destinationIndex+1);
				else if(destinationIndex<0)
				{
					ShiftRight(0, Math.Abs(destinationIndex));
					destinationIndex=0;
				}
				Items[destinationIndex]=tmp;
			}
		}
		/// <summary>
		/// Reverses the order of the items in the collection.
		/// </summary>
		public void Reverse() => Array.Reverse(Items);
		/// <summary>
		/// Determines if the <paramref name="index"/> is within this collection's range.
		/// </summary>
		/// <param name="index">An <see cref="int">integer</see> value to test if it is within the collection's range.</param>
		/// <returns>a <see cref="bool"/> representation of the condition's result.</returns>
		protected bool IsIndexValid(int index) => index>-1 && index<Length;
		/// <summary>
		/// Determines if the indices reference a valid range.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		protected bool IsIndexValid(params int[] index) => index.All(q=>IsIndexValid(q));
		/// <summary>
		/// Finds the index position of the first occurance of a matching item.
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(T item)
		{
			for(int i=0;i<Length;i++)
				if(EqualTo(Items[i], item))
					return i;
			return -1;
		}
		/// <summary>
		/// Finds the first occurance of a match.
		/// </summary>
		/// <param name="predicate">The operation to conduct on each item within the collection.</param>
		/// <returns>the first item that matches the predicate rules.</returns>
		public T? FirstOrDefault(Func<T, bool> predicate) => Items.FirstOrDefault(predicate);
		/// <inheritdoc cref="FirstOrDefault(Func{T, bool})"/>
		public T First(Func<T, bool> predicate) => Items.First(predicate);

		private static bool EqualTo(T? a, T? b) => (a is null && b is null) || (a is not null && b is not null && a.Equals(b));
		/// <summary>
		/// Gets the Enumerator for this object.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)Items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
	}
}
