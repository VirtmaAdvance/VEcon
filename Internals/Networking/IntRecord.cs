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

	}
}