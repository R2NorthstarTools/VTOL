using System;

namespace VTOL
{
    public class VersionEventArgs : EventArgs
    {
        public VersionEventArgs(Version_ newVersion, Version_ currentVersion)
        {
            NewVersion = newVersion;
            CurrentVersion = currentVersion;
        }

        public Version_ NewVersion { get; private set; }

        public Version_ CurrentVersion { get; private set; }
    }
}
