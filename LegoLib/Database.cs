using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace LegoLib
{
    public static class Database
    {
        private static readonly Dictionary<string, ColorRecord> ColorRecords = new Dictionary<string, ColorRecord>();
        private static readonly Dictionary<string, PartCategoryRecord> PartCategoryRecords
            = new Dictionary<string, PartCategoryRecord>();
        private static readonly Dictionary<string, PartInformationRecord> PartInformationRecords
            = new Dictionary<string, PartInformationRecord>();
        
        public static readonly Dictionary<string, InventoryRecord> Inventories = new Dictionary<string, InventoryRecord>();
        public static readonly Dictionary<string, List<PartRecord>> Parts = new Dictionary<string, List<PartRecord>>();

        public static string ColorName(string colorId) => ColorRecords[colorId].Name;

        public static string PartPicturePath(PartRecord part)
        {
            if (part.CategoryName == "Stickers")
            {
                return null;
            }
            
            var directory = Path.Combine(Paths.PictureDirectory, $"parts_{part.ColorId}");
            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Directory {directory} not found (color name: {part.ColorName})");
                return null;
            }

            var path = Path.Combine(directory, $"{part.PartNumber}.png");
            if (!File.Exists(path))
            {
                Console.WriteLine($"Missing picture from {part.ColorId}: {part.PartNumber} - part name: {part.PartName} element id: {part.ElementIds} category name: {part.CategoryName} - https://rebrickable.com/parts/{part.PartNumber}");
            }
            return path;
        }

        public static void LoadColors()
        {
            var fieldsSets = CsvFiles.Load("colors.csv")
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


        public static void LoadInventories()
        {
            Inventories.Clear();

            CsvFiles.Load("inventories.csv")
                .Select(line => line.Split(','))
                .Select(fields => new InventoryRecord
                {
                    Id = fields[0],
                    Version = fields[1],
                    SetNumber = fields[2]
                })
                .ForEach(_ =>
                {
                    if (!Inventories.ContainsKey(_.SetNumber))
                    {
                        Inventories.Add(_.SetNumber, _);
                    }
                });
        }

        public static void LoadParts()
        {
            Parts.Clear();

            CsvFiles.Load("inventory_parts.csv")
                .Select(line => line.Split(','))
                .Select(fields =>
                {
                    var colorName = ColorRecords.ContainsKey(fields[2]) ? ColorRecords[fields[2]].Name : null;
                    return new PartRecord
                    {
                        InventoryId = fields[0],
                        PartNumber = fields[1],
                        PartName = PartInformationRecords.ContainsKey(fields[1]) ? PartInformationRecords[fields[1]].Name : null,
                        CategoryName = PartInformationRecords.ContainsKey(fields[1]) ? PartInformationRecords[fields[1]].PartCategoryName : null,
                        ColorId = fields[2],
                        ColorName = colorName,
                        Quantity = fields[3],
                        IsSpare = fields[4] == "t",
                        ElementIds = ElementIds.Get(fields[1], fields[2])
                    };
                })
                .Where(_ => _.ElementIds != null && _.CategoryName != "Stickers")
                .ForEach(partRecord =>
                {
                    if (!Parts.ContainsKey(partRecord.InventoryId))
                    {
                        Parts.Add(partRecord.InventoryId, new List<PartRecord>());
                    }

                    Parts[partRecord.InventoryId].Add(partRecord);
                });
            
        }

        public static void LoadPartCategories()
        {
            var fieldsSets = CsvFiles.Load("part_categories.csv")
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
            var fieldsSets = CsvFiles.Load("parts.csv")
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

        public static int MainPartNumber(string partNumber)
        {
            while (!int.TryParse(partNumber, out var unused))
            {
                partNumber = partNumber.Remove(partNumber.Length - 1);
            }

            return int.Parse(partNumber);
        }

        public static string PartName(string partNumber) 
            => PartInformationRecords.ContainsKey(partNumber) ? PartInformationRecords[partNumber].Name : null;
    }
}