using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LegoStickers
{
    public static class ElementIds
    {
        private static readonly Dictionary<string, Dictionary<string, List<string>>> Data =
            new Dictionary<string, Dictionary<string, List<string>>>();

        public static void Load()
        {
            var fieldsSets = File
                .ReadAllLines("elements.csv")
                .Skip(1)
                .Select(line => line.Split(','));

            Data.Clear();
            foreach (var fields in fieldsSets)
            {
                var elementId = fields[0];
                var partNumber = fields[1];
                var colorId = fields[2];
                
                if (!Data.ContainsKey(partNumber))
                {
                    Data.Add(partNumber, new Dictionary<string, List<string>>());
                }

                if (!Data[partNumber].ContainsKey(colorId))
                {
                    Data[partNumber].Add(colorId, new List<string>());
                }

                Data[partNumber][colorId].Add(elementId);
            }
        }

        public static string Get(string partNumber, string colorId)
        {
            if (!Data.ContainsKey(partNumber))
            {
                return null;
            }

            var partNumberColors = Data[partNumber];
            if (!partNumberColors.ContainsKey(colorId))
            {
                colorId = "-1";
            }

            if (!partNumberColors.ContainsKey(colorId))
            {
                return null;
            }

            var elements = Data[partNumber][colorId];
            elements.Sort();
            return string.Join(", ", elements);
        }
    }
}