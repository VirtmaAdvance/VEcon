namespace VEconomy.Internals.FileSystem.Security
{
	/// <summary>
	/// Manages path security access.
	/// </summary>
	internal class PathAccess
	{

#if LINUX
		[DllImport("libc", SetLastError=true)]
		private static extern int s_linuxStat(string path, out LinuxStatBuffer stat);
#endif
#if MAC
		[DllImport("libc", SetLastError=true)]
		private static extern int s_macStat(string path, out MacStatBuffer stat);
#endif


#if WINDOWS
		private WindowsIdentity? _currentUser;
		private WindowsPrincipal? _currentPrincipal;
		private SecurityIdentifier? _user => _currentUser.User;
#endif


		/// <summary>
		/// Creates a new instance of the <see cref="PathAccess"/> class.
		/// </summary>
		public PathAccess()
		{
#if WINDOWS
			_currentUser=WindowsIdentity.GetCurrent();
			_currentPrincipal=new(_currentUser);
#endif
		}
		/// <summary>
		/// Determines if the <paramref name="path"/> can be accessed.
		/// </summary>
		/// <param name="path">A <see cref="string"/> representation of an existing file system path.</param>
		/// <returns></returns>
		public bool HasAccess(string path)
		{
#if WINDOWS
			return HasAccess(path, FileSystemRights.Read);
#endif
#if LINUX
			return LinuxHasAccess(path);
#endif
#if MAC
			return MacHasAccess(path);
#endif
			return false;
		}

#if MAC
		private bool MacHasAccess(string path) => MacHasAccess(path, FilePermissionFlags.Read);

		private bool MacHasAccess(string path, FilePermissionFlags perms) => path.PathExists() && MacGetFileInfo(path).HasFlag(perms);

		private static FilePermissionFlags MacGetFileInfo(string path)
		{
			if(s_macStat(path, out var statBuffer)==0)
			{
				FilePermissionFlags res=default;
				if((statBuffer.st_mode & (1<<8))!=0)
					res|=FilePermissionFlags.Read;
				if((statBuffer.st_mode & (1<<7))!=0)
					res|=FilePermissionFlags.Write;
				if((statBuffer.st_mode & (1<<6))!=0)
					res|=FilePermissionFlags.Execute;
				return res;
			}
			return FilePermissionFlags.Unknown;
		}
#endif

#if LINUX
		private bool LinuxHasAccess(string path) => LinuxHasAccess(path, FilePermissionFlags.Read);

		private bool LinuxHasAccess(string path, FilePermissionFlags perms) => path.PathExists() && LinuxGetFileInfo(path).HasFlag(perms);

		private static FilePermissionFlags LinuxGetFileInfo(string path)
		{
			if(s_linuxStat(path, out var statBuffer)==0)
			{
				FilePermissionFlags res=default;
				if((statBuffer.st_mode & (1<<8))!=0)
					res|=FilePermissionFlags.Read;
				if((statBuffer.st_mode & (1<<7))!=0)
					res|=FilePermissionFlags.Write;
				if((statBuffer.st_mode & (1<<6))!=0)
					res|=FilePermissionFlags.Execute;
				return res;
			}
			return FilePermissionFlags.Unknown;
		}
#endif

#if WINDOWS
		private bool HasAccess(string path, FileSystemRights rights)
		{
			return path.IsFile() ? HasAccess(new DirectoryInfo(path), rights) : HasAccess(new FileInfo(path), rights);
		}

		private bool HasAccess(DirectoryInfo value, FileSystemRights rights) => HasAccess(rights, value.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier)));

		private bool HasAccess(FileInfo value, FileSystemRights rights) => HasAccess(rights, value.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier)));


		private bool HasAccess(FileSystemRights rights, AuthorizationRuleCollection acl)
		{
			bool allow=false;
			bool inheritedAllow=false;
			bool inheritedDeny=false;
			for(int i = 0;i<acl.Count;i++)
			{
				var currentRule=(FileSystemAccessRule)acl[i]!;
				if(currentRule is not null)
				{
					if((_user is not null) && (_user.Equals(currentRule.IdentityReference) || _currentPrincipal.IsInRole((SecurityIdentifier)currentRule.IdentityReference)))
					{
						if(RuleAccess(currentRule, rights))
						{
							if(currentRule.IsInherited)
								inheritedDeny=true;
							else
								return false;
						}
					}
					else if(currentRule.AccessControlType.Equals(AccessControlType.Allow))
					{
						if(RuleAccess(currentRule, rights))
						{
							if(currentRule.IsInherited)
								inheritedAllow=true;
							else
								allow=true;
						}
					}
				}
			}
			return allow || inheritedAllow && !inheritedDeny;
		}
		private static bool RuleAccess(FileSystemAccessRule currentRule, FileSystemRights rights) => (currentRule.AccessControlType.Equals(rights)) && (currentRule.FileSystemRights & rights) == rights;
#endif

	}
}
