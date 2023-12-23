using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEconomy
{
	public class VWallet : Dictionary<string, VMoney>
	{
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public new VMoney this[string name]
		{
			get => ContainsKey(name) ? base[name] : default;
			set => Add(name, value);
		}


		public void Add(VMoney value)
		{
			VCurrency currencyType=value.CurrencyType;
			string? key=currencyType.Name;
			if(key is null)
				throw new ArgumentNullException(nameof(key));
			if(ContainsKey(key))
				this[key]=new (currencyType, this[key].Value+value.Value);
		}
		/// <summary>
		/// Adds a new currency to the wallet.
		/// </summary>
		/// <param name="currencyType"></param>
		/// <param name="value"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public void Add(VCurrency currencyType, VMoney value)
		{
			if(currencyType?.Name is null)
				throw new ArgumentNullException(nameof(currencyType));
			Add(currencyType.Name, value);
		}
		/// <inheritdoc cref="Add(VCurrency, VMoney)"/>
		/// <param name="currencyName">The name of the currency.</param>
		/// <param name="value">The value to set.</param>
		public new void Add(string currencyName, VMoney value)
		{
			if(ContainsKey(currencyName))
				this[currencyName]=value;
			else
				base.Add(currencyName, value);
		}


	}
}
