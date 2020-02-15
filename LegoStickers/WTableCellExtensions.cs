using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;

namespace LegoStickers
{
    public static class WTableCellExtensions
    {
        public static void SetContent(this WTableCell cell, string text, float fontSize, Color color)
        {
            if (text == null)
            {
                return;
            }
            
            var textRange = cell.AddParagraph().AppendText(text);
            textRange.CharacterFormat.FontName = "Calibri";
            textRange.CharacterFormat.Bold = true;
            textRange.CharacterFormat.FontSize = fontSize;
            textRange.CharacterFormat.TextColor = color;
        }
    }
}