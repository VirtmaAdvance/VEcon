namespace VEconomy
{
	public class VEcon
	{

		public readonly 

		public readonly CurrencyWorth CurrencyWorthCollection=new ();

		private VCurrencyCollection _currencies=new();

		public double BaseGlobalWorth { get; set; }
		/// <summary>
		/// A collection of the currencies.
		/// </summary>
		public VCurrencyCollection Currencies
		{
			get => _currencies;
			set => _currencies = value;
		}


		/// <summary>
		/// Creates a new instance of the <see cref="VEcon"/> class.
		/// </summary>
		public VEcon()
		{

		}

	}
}
