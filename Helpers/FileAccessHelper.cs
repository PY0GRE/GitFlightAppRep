using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Helpers
{
    public static class FileAccessHelper
    {
        /// <summary>
        /// Get the local file path for the given filename
        /// </summary>
        /// <param name="fileName">Name of the file that keeps the data</param>
        /// <returns></returns>
        public static string GetLocalFilePath(string fileName)
        {
            return Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
    }
}
