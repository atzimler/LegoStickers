using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LegoStickers
{
    public static class Database
    {
        private static readonly Dictionary<string, ColorRecord> ColorRecords = new Dictionary<string, ColorRecord>();
        private static readonly Dictionary<string, PartCategoryRecord> PartCategoryRecords 
            = new Dictionary<string, PartCategoryRecord>();
        private static readonly Dictionary<string, PartInformationRecord> PartInformationRecords 
            = new Dictionary<string, PartInformationRecord>();

        public static void LoadColors()
        {
            var fieldsSets = File
                .ReadAllLines("colors.csv")
                .Skip(1)
                .Select(line => line.Split(','));

            ColorRecords.Clear();
            foreach (var fields in fieldsSets)
            {
                ColorRecords.Add(fields[0], new ColorRecord
                {
                    Id = fields[0],
                    Name = fields[1],
                    Rgb = fields[2],
                    IsTransparent = fields[3] == "t"
                });
            }
        }
        

        public static IEnumerable<InventoryRecord> LoadInventories() =>
            File
                .ReadAllLines("inventories.csv")
                .Skip(1)
                .Select(line => line.Split(','))
                .Select(fields => new InventoryRecord
                {
                    Id = fields[0], 
                    Version = fields[1], 
                    SetNumber = fields[2]
                });

        public static IEnumerable<PartRecord> LoadParts() =>
            File
                .ReadAllLines("inventory_parts.csv")
                .Skip(1)
                .Select(line => line.Split(','))
                .Select(fields => new PartRecord
                {
                    InventoryId = fields[0],
                    PartNumber = fields[1],
                    PartName = PartInformationRecords.ContainsKey(fields[1])? PartInformationRecords[fields[1]].Name : null,
                    CategoryName = PartInformationRecords.ContainsKey(fields[1])? PartInformationRecords[fields[1]].PartCategoryName : null,
                    ColorId = fields[2],
                    ColorName = ColorRecords.ContainsKey(fields[2])? ColorRecords[fields[2]].Name : null,
                    Quantity = fields[3],
                    IsSpare = fields[4] == "t",
                    ElementIds = ElementIds.Get(fields[1], fields[2])
                });

        public static void LoadPartCategories()
        {
            var fieldsSets = File
                .ReadAllLines("part_categories.csv")
                .Skip(1)
                .Select(line => line.Split(','));

            PartCategoryRecords.Clear();
            foreach (var fields in fieldsSets)
            {
                PartCategoryRecords.Add(fields[0], new PartCategoryRecord
                {
                    Id = fields[0],
                    Name = fields[1]
                });
            }
        }

        public static void LoadPartInformation()
        {
            var fieldsSets = File
                .ReadAllLines("parts.csv")
                .Skip(1)
                .Select(line => line.Split(','));

            PartInformationRecords.Clear();
            foreach (var fields in fieldsSets)
            {
                PartInformationRecords.Add(fields[0], new PartInformationRecord
                {
                    PartNumber = fields[0],
                    Name = fields[1],
                    PartCategoryId = fields[2],
                    PartCategoryName = PartCategoryRecords.ContainsKey(fields[2])? PartCategoryRecords[fields[2]].Name : null
                });
            }
        }
    }
}