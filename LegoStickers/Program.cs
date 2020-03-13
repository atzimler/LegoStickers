using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegoLib;

namespace LegoStickers
{
    internal static class Program
    {
        public static void Main()
        {
            ElementIds.Load();
            Database.LoadColors();
            Database.LoadPartCategories();
            Database.LoadPartInformation();

            var stickersToPrint = File.ReadAllLines("/Users/atzimler/LegoStickers/stickerlist.txt");

            var inventory = Database.LoadInventories().First(_ => _.SetNumber == "80105-1");
            var parts = Database
                .LoadParts()
//                .Where(_ => _.InventoryId == inventory.Id)
//                .Where(_ =>_.ElementIds != null && (_.ElementIds.Contains("4549999") || _.ElementIds.Contains("6214560")))
                .Where(_ => stickersToPrint.Contains(_.PartNumber) && _.ColorId == "71")
                .OrderBy(_ => _.ColorName).ThenBy(_ => _.CategoryName).ThenBy(_ => _.PartNumber)
                .ToList();
            
            var doc = new StickerDocument();

            var printed = new Dictionary<string, List<string>>(); 
            foreach (var part in parts)
            {
                if (printed.ContainsKey(part.PartNumber) && printed[part.PartNumber].Contains(part.ColorName))
                {
                    continue;
                }

                if (!printed.ContainsKey(part.PartNumber))
                {
                    printed.Add(part.PartNumber, new List<string>());
                }
                
                part.PartPicture = Database.PartPicturePath(part);
                doc.AddPart(part);
                printed[part.PartNumber].Add(part.ColorName);
            }

            doc.Save("stickers.docx");
            doc.Close();
        }
    }
}