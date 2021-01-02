using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegoLib;

namespace LegoStickers
{
    public class ElementIdsEqualityComparer : IEqualityComparer<PartRecord>
    {
        public bool Equals(PartRecord x, PartRecord y) => x.ElementIds == y.ElementIds;
        public int GetHashCode(PartRecord obj) => 0;
    }
    
    internal static class Program
    {
        private static bool IsWantedElement(string elementIds)
        {
            var wantedList = new List<string>
            {
                "6263345", "6139460", "6240210",
                "4599535", "6024722", "6132418",
                "6104578", "6102756", "6022032"
            };

            return wantedList.Any(elementIds.Contains);
        }
        
        public static void Main()
        {
            ElementIds.Load();
            Database.LoadColors();
            Database.LoadPartCategories();
            Database.LoadPartInformation();
            Database.LoadInventories();
            Database.LoadParts();

            var stickersToPrint = File.ReadAllLines("/Users/atzimler/LegoStickers/stickerlist.txt");

            var inventory = Database.Inventories["60195-1"];
            var allParts = Database.Parts.Select(_ => _.Value).Aggregate(new List<PartRecord>(), (res, _) =>
            {
                res.AddRange(_);
                return res;
            });
            var elementIds = new List<string>
            {
                "6141590", "6004943", "6100027",
                "6240550", "6240223"
            };

            var parts = allParts
//                .Where(_ => _.InventoryId == inventory.Id)
//                .Where(_ =>_.ElementIds != null && (_.ElementIds.Contains("4549999") || _.ElementIds.Contains("6214560")))
                .Where(_ => stickersToPrint.Contains(_.PartNumber) && _.ColorId == "0")
//                .Where(_ => elementIds.Any(_.ElementIds.Contains))
                .Distinct(new ElementIdsEqualityComparer())
                .OrderBy(_ => _.ColorName)
                .ThenBy(_ => _.CategoryName)
                .ThenBy(_ => _.PartNumber)
                .ToList();

            if (parts.Count != stickersToPrint.Length)
            {
                foreach (var partNumber in stickersToPrint)
                {
                    if (!parts.Exists(_ => _.PartNumber == partNumber))
                    {
                        Console.WriteLine($"Unknown part number: {partNumber}");
                    }
                }
            }
            
            var doc = new StickerDocument();

            foreach (var part in parts)
            {
                part.PartPicture = Database.PartPicturePath(part);
                doc.AddPart(part);
            }

            doc.Save("stickers.docx");
            doc.Close();
        }
    }
}