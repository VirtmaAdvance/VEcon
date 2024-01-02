using VEconomy.Internals.Enumerables;

namespace VEconomy.Internals.ObjectExtensions
{
	/// <summary>
	/// Provides extension methods for the <see cref="object"/> class comparing a base <see cref="Type"/> to other types.
	/// </summary>
	internal static class IntObjectIsExt
	{
		/// <summary>
		/// Determines if the <paramref name="value"/> is inheritable from any of the given <paramref name="types"/>.
		/// </summary>
		/// <param name="value">The <see cref="object"/> to analyze.</param>
		/// <param name="types">The <see cref="Type"/> object(s) to test the <paramref name="value"/> against.</param>
		/// <returns>a <see cref="bool">boolean</see> value where <see cref="bool">true</see> indicates success, and <see cref="bool">false</see> represents otherwise.</returns>
		public static bool Is(this object? value, params Type[] types)
		{
			if(value.NotNull())
			{
				Type type=GetDataType(value!);
				return types.Any(type.IsAssignableFrom);
			}
			return false;
		}
		/// <inheritdoc cref="Is(object, Type[])"/>
		public static bool Is(this object? value, params object[] typeObjects)
		{
			if(value.NotNull())
			{
				Type type=GetDataType(value!);
				Type[] types=typeObjects.ForAll(q=>q.GetType());
				return types.Any(type.IsAssignableFrom);
			}
			return false;
		}
		/// <inheritdoc cref="Is(object, Type[])"/>
		public static bool IsAll(this object? value, params object[] typeObjects)
		{
			if(value.NotNull())
			{
				Type type=GetDataType(value!);
				Type[] types=typeObjects.ForAll(q=>q.GetType());
				return types.All(type.IsAssignableFrom);
			}
			return false;
		}
		/// <inheritdoc cref="Is(object, Type[])"/>
		public static bool IsAll(this object? value, params Type[] types)
		{
			if(value.NotNull())
			{
				Type type=GetDataType(value!);
				return types.All(type.IsAssignableFrom);
			}
			return false;
		}

		private static Type GetDataType(object value) => value is Type ? (Type)value : value!.GetType();

	}
}