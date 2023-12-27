namespace VEconomy.Internals.FileSystem
{
	internal static class IntStringFileSystemReadExt
	{
		/// <summary>
		/// Gets the file contents as a <see cref="byte"/> array.
		/// </summary>
		/// <param name="path">The <see cref="string"/> representation of an existing file path.</param>
		/// <returns>the contents of the file.</returns>
		public static byte[] GetFileBytes(this string? path) => path.IsFileValid() ? File.ReadAllBytes(path!) : [];
		/// <inheritdoc cref="GetFileBytes(string?)"/>
		public static async Task<byte[]> AsyncGetFileBytes(this string? path) => path.IsFileValid() ? await File.ReadAllBytesAsync(path!) : [];
		/// <inheritdoc cref="GetFileBytes(string?)" path="//*[not(self::summary)]"/>
		/// <summary>
		/// Gets the file contents as a <see cref="string"/>.
		/// </summary>
		public static string GetFileContents(this string? path) => path.IsFileValid() ? File.ReadAllText(path!) : string.Empty;
		/// <inheritdoc cref="GetFileContents(string?)"/>
		public static async Task<string> AsyncGetFileContents(this string? path) => path.IsFileValid() ? await File.ReadAllTextAsync(path!) : string.Empty;

	}
}