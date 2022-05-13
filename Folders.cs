using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion
{
    public static class Folders
    {
        public static readonly DirectoryInfo Levels = new DirectoryInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Domain", "Levels"));
        public static readonly DirectoryInfo Images = new DirectoryInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images"));
    }
}
