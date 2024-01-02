using VEconomy.Internals.ObjectExtensions;

namespace VEconomy.Internals.Networking
{
	internal class IntRecord : VCollection<IntRecordItem>
	{

		public string[] GetColumnNames()
		{
			string[] res=new string[Length];
			for(int i=0;i<Length;i++)
				res[i]=this[i].Name;
			return res;
		}
		/// <summary>
		/// Gets the SQL string representation of this object.
		/// </summary>
		/// <returns></returns>
		public new string ToString()
		{
			string res="";
			foreach(var sel in this)
				res+=(res.Length>0 ? "," : "") + ""+GetString(sel.Value)+"";
			return res;
		}
		/// <summary>
		/// Gets the <see cref="string"/> representation of the <paramref name="value"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetString(object? value)
		{
			if(value is null)
				return "null";
			if(value.IsNumber())
				return value.ToString()!;
			if(value.Is(typeof(string), typeof(char)))
				return "\""+value.ToString()+"\"";
			if(value is DateTime dateTimeValue)
				return dateTimeValue.ToString("MM-dd-yyyy | HH:mm:ss:ffff tt");
			return value.ToString()??"null";
		}

	}
}