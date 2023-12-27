using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEconomy
{
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
		public ColumnType ColumnDataType
		{
			get => _columnDataType;
			set
			{
				_columnDataType=value??ColumnType.Unknown;
				DataType=GetColumnType(_columnDataType);
			}
		}
		/// <summary>
		/// The <see cref="Type"/> object representing the data-type to use.
		/// </summary>
		public Type? DataType { get; private set; }



		public DatabaseTableColumn(string name, ColumnType? columnDataType)
		{

		}
		/// <summary>
		/// Gets the <see cref="Type"/> from the <paramref name="type"/>.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static Type? GetColumnType(ColumnType type)
		{
			switch(type)
			{
				case ColumnType.Text|ColumnType.TinyText|ColumnType.LongText|ColumnType.MediumText:
					return typeof(string);
				case ColumnType.TinyBlob|ColumnType.Blob|ColumnType.MediumBlob|ColumnType.LongBlob|ColumnType.VarBinary:
					return typeof(byte[]);
				case ColumnType.TinyInt|ColumnType.SmallInt|ColumnType.Int|ColumnType.BigInt|ColumnType.MediumInt|ColumnType.Year:
					return typeof(int);
				case ColumnType.Bit|ColumnType.Bool|ColumnType.Boolean:
					return typeof(bool);
				case ColumnType.Byte|ColumnType.Binary:
					return typeof(byte);
				case ColumnType.Float:
					return typeof(float);
				case ColumnType.Double|ColumnType.DoublePrecision:
					return typeof(double);
				case ColumnType.Date|ColumnType.DateTime|ColumnType.Time|ColumnType.Timestamp:
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
