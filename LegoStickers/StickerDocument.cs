using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;

namespace LegoStickers
{
    public class StickerDocument
    {
        private int _currentColumn;
        private IWTable _currentTable;
        private readonly WordDocument _document = new WordDocument();
        private readonly IWSection _section;
        
        public StickerDocument()
        {
            _section = _document.AddSection();
        }

        private void AddTable()
        {
            _currentTable = _section.AddTable();
            _currentTable.ResetCells(6, 3);

            for (var col = 0; col < 3; col++)
            {
                for (var row = 0; row < 5; row++)
                {
                    _currentTable[row, col].CellFormat.Borders.Bottom.BorderType = BorderStyle.Cleared;
                    _currentTable[row + 1, col].CellFormat.Borders.Top.BorderType = BorderStyle.Cleared;
                }
            }
        }

        public void AddPart(PartRecord part)
        {
            if (_currentColumn == 0)
            {
                AddTable();
            }
            
            _currentTable[0, _currentColumn].SetContent(part.PartNumber, 18, Color.Black);
            _currentTable[1, _currentColumn].SetContent(part.PartName, 12, Color.FromArgb(112, 173, 71));
            _currentTable[2, _currentColumn].SetContent(part.ColorName, 12, Color.FromArgb(68, 114, 196));
            _currentTable[3, _currentColumn].SetContent(part.CategoryName, 12, Color.FromArgb(237, 125, 49));
            _currentTable[4, _currentColumn].SetContent(part.ElementIds, 12, Color.Black);

            if (File.Exists(part.PartPicture))
                using (var fs = File.OpenRead(part.PartPicture))
                {
                    var cell = _currentTable[5, _currentColumn];
                    var paragraph = cell.AddParagraph();
                    paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                    var picture = paragraph.AppendPicture(fs);
                    picture.Height = 142;
                    picture.Width = 142;
                    cell.AddParagraph();
                    cell.CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                }

            _currentColumn = ++_currentColumn % 3;
        }

        public void Close()
        {
            _document.Close();
        }

        public void Save(string fileName)
        {
            using (var fs = File.OpenWrite(fileName))
            {
                _document.Save(fs, FormatType.Docx);
            }
        }
    }
}