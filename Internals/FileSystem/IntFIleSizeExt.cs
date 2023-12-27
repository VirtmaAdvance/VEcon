namespace VEconomy.Internals.FileSystem
{
	internal static class IntFIleSizeExt
	{
		/// <summary>
		/// Gets the size (in bytes) of the file.
		/// </summary>
		/// <param name="path">The path to an existing file.</param>
		/// <returns>the size of the file (in bytes) as a <see cref="long"/>.</returns>
		public static long GetFileSize(this string? path) => path.IsFile() ? path!.GetFileInfo().Length : -1;

	}
}