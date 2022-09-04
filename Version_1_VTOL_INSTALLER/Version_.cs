using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace VTOL
{
    public class Version_ : IEquatable<Version_>
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }

        public Version_(int major)
        {
            Major = major;
        }

        public Version_(int major, int minor) : this(major)
        {
            Minor = minor;
        }

        public Version_(int major, int minor, int revision) : this(major, minor)
        {
            Revision = revision;
        }

        public static bool operator >(Version_ first, Version_ second)
        {
            if (first.Major > second.Major)
                return true;
            else if (first.Minor > second.Minor)
                return true;
            else if (first.Revision > second.Revision)
                return true;

            return false;
        }

        public static bool operator <(Version_ first, Version_ second)
        {
            if (first.Major < second.Major)
                return true;
            else if (first.Minor < second.Minor)
                return true;
            else if (first.Revision < second.Revision)
                return true;

            return false;
        }

        public static bool operator ==(Version_ first, Version_ second)
        {
            if (first.Major == second.Major && first.Minor == second.Minor && first.Revision == second.Revision)
                return true;
            return false;
        }

        public static bool operator !=(Version_ first, Version_ second)
        {
            if (first.Major == second.Major && first.Minor == second.Minor && first.Revision == second.Revision)
                return true;
            return false;
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Revision}";
        }

        public static Version_ ConvertToVersion(string version)
        {
            //^\d{1,3}\.\d{1,3}(?:\.\d{1,6})?$
            version = version.Replace("v", "", true, CultureInfo.InvariantCulture).Split("-")[0];

            Regex regex = new Regex(@"\d+(?:\.\d+)+");

            if (regex.IsMatch(version))
            {
                var splitted = version.Split('.').Select(int.Parse).ToArray();
                if (splitted.Length == 1)
                {
                    return new Version_(splitted[0]);
                }
                else if (splitted.Length == 2)
                {
                    return new Version_(splitted[0], splitted[1]);

                }
                else if (splitted.Length >= 3)
                {
                    return new Version_(splitted[0], splitted[1], splitted[2]);
                }
            }

            throw new FormatException("Version was in a invalid format");
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Version_);
        }

        public bool Equals([AllowNull] Version_ other)
        {
            return other != null &&
                   Major == other.Major &&
                   Minor == other.Minor &&
                   Revision == other.Revision;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Major, Minor, Revision);
        }
    }
}
