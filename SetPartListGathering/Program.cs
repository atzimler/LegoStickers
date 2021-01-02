using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegoLib;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;

namespace SetPartListGathering
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ElementIds.Load();
            Database.LoadColors();
            Database.LoadInventories();
            
            // TODO: There is a hidden dependency on ElementIds.Load(). That should be eliminated or handled automatically.
            Database.LoadParts();

            var parts = new Inventory("80105-1")
                .Parts
                .Select(_ =>
                {
                    var partRecord = ElementIds.Lookup(_.Key);
                    partRecord.ColorName = Database.ColorName(partRecord.ColorId);
                    partRecord.Quantity = _.Value.ToString();
                    partRecord.StorageContainer = StorageContainerInformation.StorageContainer(partRecord);
                    partRecord.PartPicture = Database.PartPicturePath(partRecord);

                    return partRecord;
                })
                .OrderBy(_ => _.StorageContainer)
                .ThenBy(_ => _.ColorName)
                .ToList();

            parts.ForEach(_ => Console.WriteLine($"{_.StorageContainer}, {_.ColorName}, {_.PartNumber}, {_.Quantity}"));

            var document = new WordDocument();
            var section = document.AddSection();
            for (var idx = 0; idx < parts.Count; ++idx)
            {
                var currentStorageContainer = parts[idx].StorageContainer;
                var partsInCurrentStorageContainer = new List<PartRecord>();
                while (idx < parts.Count && currentStorageContainer == parts[idx].StorageContainer)
                {
                    partsInCurrentStorageContainer.Add(parts[idx++]);
                }

                var paragraph = section.AddParagraph();
                var textRange = paragraph.AppendText(currentStorageContainer ?? "");
                textRange.CharacterFormat.FontName = "Calibri";
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.FontSize = 24;
                textRange.CharacterFormat.TextColor = Color.Black;

                var table = section.AddTable();
                table.TableFormat.IsAutoResized = true;
                table.TableFormat.IsBreakAcrossPages = false;
                table.ResetCells(partsInCurrentStorageContainer.Count + 1, 4);
                table[0, 0].SetContent("Gathered", 12, Color.Black);
                table[0, 1].SetContent("Picture", 12, Color.Black);
                table[0, 2].SetContent("Color", 12, Color.Black);
                table[0, 3].SetContent("Part Number", 12, Color.Black);

                for (var partIdx = 0; partIdx < partsInCurrentStorageContainer.Count; partIdx++)
                {
                    var part = partsInCurrentStorageContainer[partIdx];
                    table[partIdx + 1, 2].SetContent(part.ColorName, 12, Color.Black);
                    table[partIdx + 1, 3].SetContent(part.PartNumber, 12, Color.Black);

                    var cell = table[partIdx + 1, 1];
                    cell.AddParagraph();
                    var p = cell.AddParagraph();
                    p.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                    cell.CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    if (File.Exists(part.PartPicture))
                        using (var pictureFile = File.OpenRead(part.PartPicture))
                        {
                            var picture = p.AppendPicture(pictureFile);
                            picture.Height = 56;
                            picture.Width = 56;
                        }

                    cell.AddParagraph();
                }

                section.AddParagraph();
                section.AddParagraph();
            }

            using var fs = File.OpenWrite("/tmp/x.docx");
            document.Save(fs, FormatType.Docx);
            
            document.Close();
        }

    }
}