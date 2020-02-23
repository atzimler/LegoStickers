using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LegoStickers
{
    public class CsvFiles
    {
        private static IEnumerable<string> LoadLines(string fileName)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllLines(fileName).Skip(1); 
            }

            return Enumerable.Empty<string>();
        }

        public static IEnumerable<string> Load(string fileName)
        {
            var data = LoadLines(Path.Combine(Paths.DataDirectory, fileName)); 

            var missingDataFileName = LoadLines(Path.Combine(Paths.DataFixDirectory, $"add_{fileName}"));
            data = data.Concat(missingDataFileName);

            return data;
        }
    }
}