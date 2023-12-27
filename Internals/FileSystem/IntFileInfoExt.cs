namespace VEconomy.Internals.FileSystem
{
	internal static class IntFileInfoExt
	{
		/// <summary>
		/// Gets the <see cref="FileInfo"/> object of the given file path.
		/// </summary>
		/// <param name="path">The path to an existing file.</param>
		/// <returns>the <see cref="FileInfo"/> object of the file.</returns>
		/// <exception cref="FileNotFoundException"></exception>
		public static FileInfo GetFileInfo(this string path) => path.IsFile() ? new FileInfo(path) : throw new FileNotFoundException();

	}
}