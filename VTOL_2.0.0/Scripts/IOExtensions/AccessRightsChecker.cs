
namespace IOExtensions
{
    using System.IO;
    using System.Security.AccessControl;
    using System.Security.Principal;
    public static class AccessRightsChecker
    {
        /// <summary>
        /// Test a directory or file for file access permissions
        /// </summary>
        /// <param name="itemPath">Full path to file or directory </param>
        /// <param name="accessRight">File System right tested</param>
        /// <returns>State [bool]</returns>
        public static bool ItemHasPermision(string itemPath, FileSystemRights accessRight)
        {
            if (string.IsNullOrEmpty(itemPath)) return false;
            var isDir = itemPath.IsDirFile();
            if (isDir == null) return false;

            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(itemPath);

                AuthorizationRuleCollection rules;
                if (isDir == true)
                {
                    DirectorySecurity dSecurity = dInfo.GetAccessControl();

                    rules = dSecurity.GetAccessRules(true, true, typeof(SecurityIdentifier));
                }
                else
                {
                    
                    rules = FileSystemAclExtensions.GetAccessControl(dInfo).GetAccessRules(true, true, typeof(SecurityIdentifier));
                }
                
                var identity = WindowsIdentity.GetCurrent();
                string userSID = identity.User.Value;

                foreach (FileSystemAccessRule rule in rules)
                {
                    if (rule.IdentityReference.ToString() == userSID || identity.Groups.Contains(rule.IdentityReference))
                    {
                        if ((accessRight & rule.FileSystemRights) == accessRight)
                        {
                            if (rule.AccessControlType == AccessControlType.Deny)
                            {
                                return false;
                            }

                            if (rule.AccessControlType == AccessControlType.Allow)
                                return true;
                        }
                    }
                }
            }
            catch { }
            return false;
        }
    }
}
