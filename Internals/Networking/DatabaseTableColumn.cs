using VEconomy.Internals.EnumExtensions;

namespace VEconomy.Internals.Networking
{
    /// <summary>
    /// Stores the column's configurations.
    /// </summary>
    public struct DatabaseTableColumn
    {
        /// <summary>
        /// The name of the column.
        /// </summary>
        public string? Name { get; set; }
        private ColumnType _columnDataType = ColumnType.Unknown;
        /// <summary>
        /// The data-type of the column.
        /// </summary>
        public ColumnType? ColumnDataType
        {
            get => _columnDataType;
            set
            {
                _columnDataType = value ?? ColumnType.Unknown;
                DataType = GetColumnType(_columnDataType);
            }
        }
        /// <summary>
        /// The <see cref="Type"/> object representing the data-type to use.
        /// </summary>
        public Type? DataType { get; private set; }
        private DatabaseColumnProperties _properties=DatabaseColumnProperties.None;
        /// <summary>
        /// The column properties.
        /// </summary>
        public DatabaseColumnProperties Properties
        {
            get => _properties;
            set
            {
                _properties = value;
                switch(value)
                {
                    case DatabaseColumnProperties.AutoIncrement:
                        DataType=typeof(long);
                        _properties|=DatabaseColumnProperties.Unique | DatabaseColumnProperties.PrimaryKey | DatabaseColumnProperties.NotNull;
                        break;
                    case DatabaseColumnProperties.PrimaryKey:
                        DataType=typeof(long); break;

                }
            }
        }
        /// <summary>
        /// Determines if the column has this property.
        /// </summary>
        public bool IsPrimaryKey
        {
            get => Properties.HasFlag(DatabaseColumnProperties.PrimaryKey);
            set => _properties=value ? Properties.Add(DatabaseColumnProperties.PrimaryKey) : Properties.Remove(DatabaseColumnProperties.PrimaryKey);
        }
        /// <inheritdoc cref="IsPrimaryKey"/>
        public bool IsUnique
        {
            get => Properties.HasFlag(DatabaseColumnProperties.Unique);
            set => _properties=value ? Properties.Add(DatabaseColumnProperties.Unique) : Properties.Remove(DatabaseColumnProperties.Unique);
        }
        /// <inheritdoc cref="IsPrimaryKey"/>
        public bool HasCheck
        {
            get => Properties.HasFlag(DatabaseColumnProperties.Check);
            set => _properties=value ? Properties.Add(DatabaseColumnProperties.Check) : Properties.Remove(DatabaseColumnProperties.Check);
        }


        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseTableColumn"/> struct object.
        /// </summary>
        /// <param name="name">The name of the database table column.</param>
        /// <param name="columnDataType">The data-type of the column.</param>
        public DatabaseTableColumn(string name, ColumnType? columnDataType)
        {
            Name = name;
            ColumnDataType = columnDataType;
        }
        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseTableColumn"/> struct object.
        /// </summary>
        /// <param name="name">The name of the database table column.</param>
        /// <param name="columnDataType">The data-type of the column.</param>
        /// <param name="properties">The properties for this column.</param>
        public DatabaseTableColumn(string name, ColumnType? columnDataType, DatabaseColumnProperties properties)
        {
            Name = name;
            ColumnDataType = columnDataType;
            Properties = properties;
        }
        /// <summary>
        /// Gets the <see cref="Type"/> from the <paramref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type? GetColumnType(ColumnType type)
        {
            switch (type)
            {
                case ColumnType.Text | ColumnType.TinyText | ColumnType.LongText | ColumnType.MediumText:
                    return typeof(string);
                case ColumnType.TinyBlob | ColumnType.Blob | ColumnType.MediumBlob | ColumnType.LongBlob | ColumnType.VarBinary:
                    return typeof(byte[]);
                case ColumnType.TinyInt | ColumnType.SmallInt | ColumnType.Int | ColumnType.BigInt | ColumnType.MediumInt | ColumnType.Year:
                    return typeof(int);
                case ColumnType.Bit | ColumnType.Bool | ColumnType.Boolean:
                    return typeof(bool);
                case ColumnType.Byte | ColumnType.Binary:
                    return typeof(byte);
                case ColumnType.Float:
                    return typeof(float);
                case ColumnType.Double | ColumnType.DoublePrecision:
                    return typeof(double);
                case ColumnType.Date | ColumnType.DateTime | ColumnType.Time | ColumnType.Timestamp:
                    return typeof(DateTime);
                case ColumnType.Decimal:
                    return typeof(decimal);
                case ColumnType.Enum:
                    return typeof(Dictionary<string, long>);
                case ColumnType.Set:
                    return typeof(string[]);
                case ColumnType.Char:
                    return typeof(char);
                case ColumnType.VarChar:
                    return typeof(char[]);
                default:
                    return null;
            }
        }

    }
}