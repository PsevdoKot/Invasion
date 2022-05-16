using System;
using System.IO;

namespace Invasion
{
    public static class Folders
    {
        public static readonly DirectoryInfo Levels = new DirectoryInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Domain", "Levels"));
        public static readonly DirectoryInfo Images = new DirectoryInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images"));
        public static readonly DirectoryInfo Resources = new DirectoryInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources"));
    }
}
