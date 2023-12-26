namespace VEconomy.Internals.Networking
{
	internal struct IntAccountCredentials
	{
		/// <summary>
		/// The username.
		/// </summary>
		public string? Username { get; set; }
		/// <summary>
		/// The password.
		/// </summary>
		public string? Password { internal get; set; }
		/// <summary>
		/// The domain the account belongs in.
		/// </summary>
		public string? Domain { get; set; }


		/// <summary>
		/// Creates a new instance of the <see cref="IntAccountCredentials"/> struct object.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="domain"></param>
		public IntAccountCredentials(string username, string password, string domain)
		{
			Username=username;
			Password=password;
			Domain=domain;
		}
		/// <inheritdoc cref="IntAccountCredentials(string, string, string)"/>
		public IntAccountCredentials(string username, string password) : this(username, password, "") { }
		/// <summary>
		/// Destroys this object's data.
		/// </summary>
		public void Dispose()
		{
			Username=null;
			Password=null;
			Domain=null;
		}

	}
}