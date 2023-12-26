namespace VEconomy.Internals.Networking
{
	internal struct IntDatabaseConfig
	{

		public readonly IntAccountCredentials Account;

		public string Host { get; set; }

		public string? ConnectionString => GetConnectionString();



		public string? GetConnectionString()
		{
			return Account.Username!=null && Account.Password!=null && Host!=null ? "Server=\""+Host+"\";User Id=\""+Account.Username+"\";Password=\""+Account.Password+"\";" : null;
		}

	}
}