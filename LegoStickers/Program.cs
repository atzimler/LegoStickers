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
            
            foreach (var part in parts)
            {
                doc.AddPart(part);                
            }

            doc.Save("stickers.docx");
            doc.Close();
        }
    }
}