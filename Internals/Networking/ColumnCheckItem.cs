using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VEconomy.Internals.Networking
{
	public struct ColumnCheckItem<TIn, TOut>
	{
		/// <summary>
		/// The condition/predicate to perform on the value.
		/// </summary>
		public Func<TIn, TOut> Predicate { get; set; }



		public void Test()
		{
			//Predicate.GetMethodInfo().GetMethodBody().
		}


	}
}
