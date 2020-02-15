using System;
using System.Collections.Generic;
using System.Linq;

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

            var inventory = Database.LoadInventories().First(_ => _.SetNumber == "75192-1");
            var parts = Database.LoadParts().Where(_ => _.InventoryId == inventory.Id).ToList();

            var doc = new StickerDocument();

            var printedSets = new HashSet<string>();
            foreach (var part in parts)
            {
                if (printedSets.Contains(part.PartNumber))
                {
                    continue;
                }
                
                part.PartPicture = Database.PartPicturePath(part);
                doc.AddPart(part);
                printedSets.Add(part.PartNumber);
            }

            doc.Save("stickers.docx");
            doc.Close();
        }
    }
}