using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace VEconomy.Internals.Networking
{
	internal class IntDatabase
	{

		private IntDatabaseConfig? _config;

		public IntDatabaseConfig? Config
		{
			get => _config;
			set
			{
				_config=value;
			}
		}







	}
}
