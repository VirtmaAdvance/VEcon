using VEconomy.Internals.FileSystem.Security;
using VEconomy.Internals.StringArray;

namespace VEconomy.Internals.FileSystem
{
	internal static class IntDirectoryScanExt
	{
		/// <summary>
		/// Gets a <see cref="string"/> array of the files within the given directory path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string[] GetFiles(this string? path) => path.IsDirectory() && new PathAccess().HasAccess(path!) ? Directory.GetFiles(path!).ToLower() : [];
		/// <summary>
		/// Gets a <see cref="string"/> array of the directories within the given directory path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string[] GetDirectories(this string? path) => path.IsDirectory() && new PathAccess().HasAccess(path!) ? Directory.GetDirectories(path!).ToLower() : [];
		/// <summary>
		/// Gets the contents within a given directory.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string[] GetDirectoryContents(this string? path)
		{
			string[] res=[];
			if(path.IsDirectory() && new PathAccess().HasAccess(path!))
			{
				res=Directory.GetFiles(path!);
				var tmp=Directory.GetDirectories(path!);
				Array.Resize(ref res, res.Length+tmp.Length);
				for(int i=0;i<res.Length;i++)
					res[res.Length+i]=tmp[i];
			}
			return res;
		}

	}
}