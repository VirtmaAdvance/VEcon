namespace VEconomy.Internals.Networking
{
    /// <summary>
    /// Provides an enumeration of the different types of column data-types available.
    /// </summary>
    [Flags]
    public enum ColumnType : long
    {
        /// <summary>
        /// No data-type.
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Unknown data-type.
        /// </summary>
        Unknown = 0x1,
        /// <summary>
        /// Values can be 0/1 or TRUE/FALSE.
        /// </summary>
        Bit = 0x2,
        /// <inheritdoc cref="Bit"/>
        Bool = 0x2,
        /// <inheritdoc cref="Bit"/>
        Boolean = 0x2,
        /// <summary>
        /// An array of 8 bits (<see cref="byte"/>).
        /// </summary>
        Byte = 0x4,
        /// <summary>
        /// Values can range between -128 to 127 and 0 to 255.
        /// </summary>
        TinyInt = 0x8,
        /// <summary>
        /// Values can range between -32768 to 32767 and 0 to 65535.
        /// </summary>
        SmallInt = 0x10,
        /// <summary>
        /// Stores an integer value with a signed range of -8388608 to 8388607 and an unsigned range of 0 to 16777215.
        /// </summary>
        MediumInt = 0x20,
        /// <summary>
        /// Stores an integer value with a signed range of -2147483648 to 2147483647 and an unsigned range of 0 to 4294967295.
        /// </summary>
        Int = 0x40,
        /// <summary>
        /// Stores a large integer value with a signed range of -9223372036854775808 to 9223372036854775807 and an unsigned range of 0 to 18446744073709551615.
        /// </summary>
        BigInt = 0x80,
        /// <summary>
        /// Stores a floating point number.
        /// </summary>
        Float = 0x100,
        /// <inheritdoc cref="DoublePrecision"/>
        Double = 0x200,
        /// <summary>
        /// Stores a floating point number with a specified number of digits (size) and a specified number of digits after the decimal point (d).
        /// </summary>
        DoublePrecision = 0x400,
        /// <summary>
        /// Stores a fixed-point number.
        /// </summary>
        Decimal = 0x800,
        /// <summary>
        /// A date value in the format of 'YYYY-MM-DD' with a supported range of '1000-01-01' to '9999-12-31'.
        /// </summary>
        Date = 0x1000,
        /// <inheritdoc cref="Timestamp" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a datetime value with a supported range of '1000-01-01 00:00:00' to '9999-12-31 23:59:59'.
        /// </summary>
        DateTime = 0x2000,
        /// <summary>
        /// Stores a timestamp value as a long where the value represents the number of seconds since the Unix Epoch event.
        /// </summary>
        /// <returns>a <see cref="System.DateTime"/> object representation.</returns>
        Timestamp = 0x4000,
        /// <inheritdoc cref="Timestamp" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores the time in the format of hh:mm:ss with a range of '-838:59:59' to '838:59:59'
        /// </summary>
        Time = 0x8000,
        /// <summary>
        /// Stores a year in a four (4) digit format.
        /// </summary>
        /// <returns>an <see cref="int">integer</see> representation of the value.</returns>
        Year = 0x10000,
        /// <summary>
        /// Stores a fixed length string value.
        /// </summary>
        /// <returns>a <see cref="char">character</see> representation of the value.</returns>
        Char = 0x20000,
        /// <summary>
        /// Stores a variable length string.
        /// </summary>
        /// <returns>a <see cref="char"/> array.</returns>
        VarChar = 0x40000,
        /// <summary>
        /// Stores a binary byte string.
        /// </summary>
        /// <returns>a <see cref="byte"/> array.</returns>
        Binary = 0x80000,
        /// <inheritdoc cref="Binary" path="//*[not(self::summary)]" />
        /// <summary>
        /// A variable length binary value.
        /// </summary>
        VarBinary = 0x100000,
        /// <inheritdoc cref="Binary" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a Binary Large Object up to 255 bytes/
        /// </summary>
        TinyBlob = 0x200000,
        /// <summary>
        /// Stores a string value of up to 255 characters long.
        /// </summary>
        /// <returns>a <see cref="string"/> representation of the value.</returns>
        TinyText = 0x400000,
        /// <inheritdoc cref="TinyText" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a string value of up to 65,535 bytes long.
        /// </summary>
        Text = 0x800000,
        /// <inheritdoc cref="Binary" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a Binary Large Object up to 65,535 bytes.
        /// </summary>
        Blob = 0x1000000,
        /// <inheritdoc cref="Text" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a string value of up to 16,777,215 characters long.
        /// </summary>
        MediumText = 0x2000000,
        /// <inheritdoc cref="Binary" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a Binary Large Object up to 16,777,215 bytes.
        /// </summary>
        MediumBlob = 0x4000000,
        /// <inheritdoc cref="Text" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a string value of up to 4,294,967,295 characters long.
        /// </summary>
        LongText = 0x8000000,
        /// <inheritdoc cref="Binary" path="//*[not(self::summary)]" />
        /// <summary>
        /// Stores a Binary Large Object up to 4,294,967,295 bytes.
        /// </summary>
        LongBlob = 0x10000000,
        /// <summary>
        /// A string object that can have only one value, chosen from a list of possible values.
        /// </summary>
        /// <returns>a <see cref="Dictionary{String, Long}">Dictionary</see>&lt;<see cref="string"/>, <see cref="long"/>&gt; where the key is a <see cref="string"/> and the value is a <see cref="long"/>.</returns>
        Enum = 0x20000000,
        /// <summary>
        /// A string object that can have 0 or more values.
        /// </summary>
        /// <returns>a <see cref="string"/> array.</returns>
        Set = 0x40000000,
        /// <summary>
        /// Indicates that the value is unsigned or is a special case/conversion (To utilize an alternative representation mode).
        /// </summary>
        Unsigned = 0x80000000,

    }
}