using System.Collections.Generic;
using System.Linq;

namespace LegoLib
{
    public static class ElementIds
    {
        private static readonly Dictionary<string, Dictionary<string, List<string>>> Data = 
            new Dictionary<string, Dictionary<string, List<string>>>();
        private static readonly Dictionary<string, PartRecord> ReverseData = 
            new Dictionary<string, PartRecord>();

        public static void Load()
        {
            var fieldsSets = CsvFiles
                .Load("elements.csv")
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

                if (!ReverseData.ContainsKey(elementId))
                {
                    ReverseData.Add(elementId, new PartRecord { PartNumber = partNumber, ColorId = colorId });
                }
            }
        }

        public static string Get(string partNumber, string colorId)
        {
            if (!Data.ContainsKey(partNumber))
            {
                // Older elements did not have an elementId
                return $"_{partNumber}_{colorId}";
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

        public static PartRecord Lookup(string elementId)
        {
            if (elementId.StartsWith("_"))
            {
                var parts = elementId.Split('_');
                return new PartRecord { PartNumber = parts[1], ColorId = parts[2] };
            }
            
            if (ReverseData.ContainsKey(elementId))
            {
                return ReverseData[elementId];
            }

            if (!elementId.Contains(','))
            {
                return null;
            }

            var elementIds = elementId.Split(',');
            return elementIds
                .Select(_ => _.Replace(" ", ""))
                .Select(Lookup)
                .FirstOrDefault(_ => _ != null);
        }
    }
}