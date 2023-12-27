namespace VEconomy
{
	/// <summary>
	/// Provides query action flags.
	/// </summary>
	[Flags]
	public enum DatabaseQueryAction
	{
		/// <summary>
		/// No action.
		/// </summary>
		None=0x0,
		/// <summary>
		/// Unknown action.
		/// </summary>
		Unknown=0x1,
		/// <summary>
		/// Selects a record or records.
		/// </summary>
		Select=0x2,
		/// <summary>
		/// Selects records with different values.
		/// </summary>
		SelectDistinct=0x4,
		/// <summary>
		/// Modifies an existing record.
		/// </summary>
		Update=0x8,
		/// <summary>
		/// Deletes an existing record.
		/// </summary>
		Delete=0x10,
		/// <summary>
		/// Provides the number of records that match a condition, that exist within the table, or the number of tables within a database.
		/// </summary>
		Count=0x20,
		/// <summary>
		/// Deletes a database or database table.
		/// </summary>
		Drop=0x40,
		/// <summary>
		/// Creates a database or database table.
		/// </summary>
		Create=0x80,
		/// <summary>
		/// Adds a new record to the database table.
		/// </summary>
		Insert=0x100,
		/// <summary>
		/// Determines if a record exists.
		/// </summary>
		/// <returns>a <see cref="bool">boolean</see> value representing if a record exists or not.</returns>
		Exists=0x200,
		/// <summary>
		/// Automatically creates a database or database table if it does not exist.
		/// </summary>
		AutoCreate=0x400,
		/// <summary>
		/// Executes/Invokes a stored proceedure.
		/// </summary>
		ExecuteStoredProceedure=0x800,
		/// <summary>
		/// Creates a stored proceedure.
		/// </summary>
		CreateStoredProceedure=0x1000,

	}
}