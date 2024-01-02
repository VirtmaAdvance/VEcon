namespace VEconomy.Internals.Networking
{
    /// <summary>
    /// Provides flags for a database column's configuration properties.
    /// </summary>
    [Flags]
    public enum DatabaseColumnProperties
    {
        /// <summary>
        /// No properties.
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Unknown property.
        /// </summary>
        Unknown = 0x1,
        /// <summary>
        /// Forces each value within the column to have a unique value.
        /// </summary>
        PrimaryKey = 0x2,
        /// <summary>
        /// Indicates that the values within the column reference another column in another database table.
        /// </summary>
        ForeignKey = 0x4,
        /// <summary>
        /// Enforces each value within the column to have unique values.
        /// </summary>
        Unique = 0x8,
        /// <summary>
        /// Indicates the use of a default value for the column if none were provided.
        /// </summary>
        Default = 0x10,
        /// <summary>
        /// Configures the column to automatically increment the value for each record.
        /// </summary>
        AutoIncrement = 0x20,
        /// <summary>
        /// Indicates that the values within the column cannot be null.
        /// </summary>
        NotNull = 0x40,
        /// <summary>
        /// Indicates that values within the column satisfy a condition.
        /// </summary>
        Check = 0x80,

    }
}