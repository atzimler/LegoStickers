using System;
using System.IO;
using System.Linq;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;

namespace LegoStickers
{
    public static class WTableCellExtensions
    {
        public static void SetContent(this WTableCell cell, string text, float fontSize, Color color)
        {
            var textRange = cell.AddParagraph().AppendText(text);
            textRange.CharacterFormat.FontName = "Calibri";
            textRange.CharacterFormat.Bold = true;
            textRange.CharacterFormat.FontSize = fontSize;
            textRange.CharacterFormat.TextColor = color;
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            ElementIds.Load();
            Database.LoadColors();
            Database.LoadPartCategories();
            Database.LoadPartInformation();
            
            var inventory = Database.LoadInventories().First(_ => _.SetNumber == "75192-1");
            var parts = Database.LoadParts().Where(_ => _.InventoryId == inventory.Id).ToList();
            foreach (var part in parts.Where(_ => _.PartNumber == "2445"))
            {
                Console.WriteLine($"{part.PartNumber}, {part.PartName}, {part.CategoryName}, {part.ColorName}, {part.ElementIds}");
            }

            return;
            
            
            var doc = new WordDocument();

            var section = doc.AddSection();
            var table = section.AddTable();
            table.ResetCells(6, 3);

            table[0, 0].SetContent("2445", 18, Color.Black);
            table[1, 0].SetContent("Plate 2 x 12", 12, Color.FromArgb(112, 173, 71));
            table[2, 0].SetContent("Reddish Brown", 12, Color.FromArgb(68, 114, 196));
            table[3, 0].SetContent("Plates", 12, Color.FromArgb(237, 125, 49));
            table[4, 0].SetContent("4225700", 12, Color.Black);

            using (var fs = File.OpenRead("2445.png"))
            {
                var paragraph = table[5, 0].AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                var picture = paragraph.AppendPicture(fs);
                picture.Height = 142;
                picture.Width = 142;
                table[5, 0].AddParagraph();
                table[5, 0].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
            }

            for (var row = 0; row < 5; row++)
            {
                table[row, 0].CellFormat.Borders.Bottom.BorderType = BorderStyle.Cleared;
            }

            for (var row = 1; row < 6; row++)
            {
                table[row, 0].CellFormat.Borders.Top.BorderType = BorderStyle.Cleared;
            }
            
//            table[0, 0].CellFormat.Borders.Bottom.BorderType = BorderStyle.Cleared;
//            table[1, 0].CellFormat.Borders.Top.BorderType = BorderStyle.Cleared;
            

//            IWTextRange textRange = section.AddParagraph().AppendText("Price Details");
//            textRange.CharacterFormat.FontName = "Arial";
//            textRange.CharacterFormat.FontSize = 12;
//            textRange.CharacterFormat.Bold = true;
//            textRange.CharacterFormat.TextColor = Color.Black;
//            
//section.AddParagraph();
////Adds a new table into Word document
//IWTable table = section.AddTable();
////Specifies the total number of rows & columns
//table.ResetCells(3, 2);
////Accesses the instance of the cell (first row, first cell) and adds the content into cell
//textRange = table[0, 0].AddParagraph().AppendText("Item");
//textRange.CharacterFormat.FontName = "Arial";
//textRange.CharacterFormat.FontSize = 12;
//textRange.CharacterFormat.Bold = true;
////Accesses the instance of the cell (first row, second cell) and adds the content into cell
//textRange = table[0, 1].AddParagraph().AppendText("Price($)");
//textRange.CharacterFormat.FontName = "Arial";
//textRange.CharacterFormat.FontSize = 12;
//textRange.CharacterFormat.Bold = true;
////Accesses the instance of the cell (second row, first cell) and adds the content into cell
//textRange = table[1, 0].AddParagraph().AppendText("Apple");
//textRange.CharacterFormat.FontName = "Arial";
//textRange.CharacterFormat.FontSize = 10;
////Accesses the instance of the cell (second row, second cell) and adds the content into cell
//textRange = table[1, 1].AddParagraph().AppendText("50");
//textRange.CharacterFormat.FontName = "Arial";
//textRange.CharacterFormat.FontSize = 10;
////Accesses the instance of the cell (third row, first cell) and adds the content into cell
//textRange = table[2, 0].AddParagraph().AppendText("Orange");
//textRange.CharacterFormat.FontName = "Arial";
//textRange.CharacterFormat.FontSize = 10;
////Accesses the instance of the cell (third row, second cell) and adds the content into cell
//textRange = table[2, 1].AddParagraph().AppendText("30");
//textRange.CharacterFormat.FontName = "Arial";
//textRange.CharacterFormat.FontSize = 10;

using (var fs = File.OpenWrite("stickers.docx"))
            {
                doc.Save(fs, FormatType.Docx);
                doc.Close();
            }
        }
    }
}