using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEconomy.Internals
{
	internal static class IntIsTypeExt
	{

		public static bool Is(this object source, params Type[] types)
		{
			Type type=source.GetType();
			return types.Any(q=>q.IsAssignableFrom(type));
		}

		public static bool IsNumber(this object source) => source.Is(typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal), typeof(nint));

	}
}
