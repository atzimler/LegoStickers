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
        private const string Black = "Black";
        private const string BlackContainer = "Black {0} - {1}";
        private const string BrightGreenDarkOrangeDarkPinkDarkPurpleSandGreen = "Bright Green / Dark Orange / Dark Pink / Dark Purple / Sand Green";
        private const string BrightLightOrangeDarkBrownLavenderMediumAzure = "Bright Light Orange / Dark Brown / Lavender / Medium Azure";
        private const string DarkAzureYellow = "Dark Azure / Yellow";
        private const string DarkBluishGrey = "Dark Bluish Gray";
        private const string DarkBluishGreyContainer = "Dark Bluish Grey {0} - {1}";
        private const string DarkGreenDarkTanGreenMagentaYellowishGreen = "Dark Green / Dark Tan / Green / Magenta / Yellowish Green";
        private const string DarkRedPearlGold = "Dark Red / Pearl Gold";
        private const string LightBluishGrey = "Light Bluish Gray";
        private const string LightBluishGreyContainer = "Light Bluish Grey {0} - {1}";
        private const string LotOfColors = "Bright Light Yellow / Bright Pink / Dark Turquoise / Light Aqua / Lime / Medium Dark Flesh / Medium Lavender / Metallic Gold / Metallic Silver / Olive Green";
        private const string Red = "Red";
        private const string RedContainer = "Red {0} - {1}";
        private const string TransDarkBlueTransGreenTransLightBlueTransOrange = "Trans-Dark Blue / Trans-Green / Trans-Light Blue / Trans-Orange";
        private const string TransparentRest = "Transparent Rest";
        private const string White = "White";
        private const string WhiteBrightLightBlue = "White 40 - 59 / Bright Light Blue";
        private const string WhiteContainer = "White {0} - {1}";
        private const string WhiteMediumBlue = "White 20 - 39 / Medium Blue";
        private const string WhiteSandBlue = "White 00 - 19 / Sand Blue";
        
        private static readonly List<StorageContainerInformation> Containers = new List<StorageContainerInformation>
        {
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "00",
                To = "09",
                Name = string.Format(BlackContainer, "00", "09")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "10",
                To = "19",
                Name = string.Format(BlackContainer, "10", "19")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "20",
                To = "29",
                Name = string.Format(BlackContainer, "20", "29")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "30",
                To = "39",
                Name = string.Format(BlackContainer, "30", "39")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "40",
                To = "49",
                Name = string.Format(BlackContainer, "40", "49")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "50",
                To = "59",
                Name = string.Format(BlackContainer, "50", "59")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "60",
                To = "69",
                Name = string.Format(BlackContainer, "60", "69")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "70",
                To = "79",
                Name = string.Format(BlackContainer, "70", "79")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "80",
                To = "89",
                Name = string.Format(BlackContainer, "80", "89")
            },
            new StorageContainerInformation
            {
                ColorName = Black,
                From = "90",
                To = "99",
                Name = string.Format(BlackContainer, "90", "99")
            },
            new StorageContainerInformation
            {
                ColorName = "Blue",
                From = "00",
                To = "99",
                Name = "Blue"
            },
            new StorageContainerInformation
            {
                ColorName = "Bright Green",
                From = "00",
                To = "99",
                Name = BrightGreenDarkOrangeDarkPinkDarkPurpleSandGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Bright Light Orange",
                From = "00",
                To = "99",
                Name = BrightLightOrangeDarkBrownLavenderMediumAzure
            },
            new StorageContainerInformation
            {
                ColorName = "Bright Light Yellow",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Bright Pink",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Azure",
                From = "00",
                To = "99",
                Name = DarkAzureYellow
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Blue",
                From = "00",
                To = "99",
                Name = "Dark Blue"
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "00",
                To = "09",
                Name = string.Format(DarkBluishGreyContainer, "00", "09")
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "10",
                To = "24",
                Name = string.Format(DarkBluishGreyContainer, "10", "24")
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "25",
                To = "37",
                Name = string.Format(DarkBluishGreyContainer, "25", "37")
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "38",
                To = "49",
                Name = string.Format(DarkBluishGreyContainer, "38", "49")
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "50",
                To = "62",
                Name = string.Format(DarkBluishGreyContainer, "50", "62")
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "63",
                To = "74",
                Name = string.Format(DarkBluishGreyContainer, "63", "74")
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "75",
                To = "87",
                Name = string.Format(DarkBluishGreyContainer, "75", "87")
            },
            new StorageContainerInformation
            {
                ColorName = DarkBluishGrey,
                From = "88",
                To = "99",
                Name = string.Format(DarkBluishGreyContainer, "88", "99")
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Brown",
                From = "00",
                To = "99",
                Name = BrightLightOrangeDarkBrownLavenderMediumAzure
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Green",
                From = "00",
                To = "99",
                Name = DarkGreenDarkTanGreenMagentaYellowishGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Orange",
                From = "00",
                To = "99",
                Name = BrightGreenDarkOrangeDarkPinkDarkPurpleSandGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Pink",
                From = "00",
                To = "99",
                Name = BrightGreenDarkOrangeDarkPinkDarkPurpleSandGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Purple",
                From = "00",
                To = "99",
                Name = BrightGreenDarkOrangeDarkPinkDarkPurpleSandGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Red",
                From = "00",
                To = "99",
                Name = DarkRedPearlGold
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Tan",
                From = "00",
                To = "99",
                Name = DarkGreenDarkTanGreenMagentaYellowishGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Dark Turquoise",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Green",
                From = "00",
                To = "99",
                Name = DarkGreenDarkTanGreenMagentaYellowishGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Lavender",
                From = "00",
                To = "99",
                Name = BrightLightOrangeDarkBrownLavenderMediumAzure
            },
            new StorageContainerInformation
            {
                ColorName = "Light Aqua",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "00",
                To = "08",
                Name = string.Format(LightBluishGreyContainer, "00", "08")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "09",
                To = "19",
                Name = string.Format(LightBluishGreyContainer, "09", "19")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "20",
                To = "29",
                Name = string.Format(LightBluishGreyContainer, "20", "29")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "30",
                To = "39",
                Name = string.Format(LightBluishGreyContainer, "30", "39")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "40",
                To = "49",
                Name = string.Format(LightBluishGreyContainer, "40", "49")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "50",
                To = "59",
                Name = string.Format(LightBluishGreyContainer, "50", "59")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "60",
                To = "69",
                Name = string.Format(LightBluishGreyContainer, "60", "69")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "70",
                To = "79",
                Name = string.Format(LightBluishGreyContainer, "70", "79")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "80",
                To = "89",
                Name = string.Format(LightBluishGreyContainer, "80", "89")
            },
            new StorageContainerInformation
            {
                ColorName = LightBluishGrey,
                From = "90",
                To = "99",
                Name = string.Format(LightBluishGreyContainer, "90", "99")
            },
            new StorageContainerInformation
            {
                ColorName = "Lime",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Magenta",
                From = "00",
                To = "99",
                Name = DarkGreenDarkTanGreenMagentaYellowishGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Medium Azure",
                From = "00",
                To = "99",
                Name = BrightLightOrangeDarkBrownLavenderMediumAzure
            },
            new StorageContainerInformation
            {
                ColorName = "Medium Dark Flesh",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Medium Lavender",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Metallic Gold",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Metallic Silver",
                From = "00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Olive Green",
                From ="00",
                To = "99",
                Name = LotOfColors
            },
            new StorageContainerInformation
            {
                ColorName = "Orange",
                From = "00",
                To = "99",
                Name = "Orange"
            },
            new StorageContainerInformation
            {
                ColorName = "Pearl Gold",
                From = "00",
                To = "99",
                Name = DarkRedPearlGold
            },
            new StorageContainerInformation
            {
                ColorName = Red,
                From = "00",
                To = "49",
                Name = string.Format(RedContainer, "00", "49")
            },
            new StorageContainerInformation
            {
                ColorName = Red,
                From = "50",
                To = "99",
                Name = string.Format(RedContainer, "50", "99")
            },
            new StorageContainerInformation
            {
                ColorName = "Reddish Brown",
                From = "00",
                To = "99",
                Name = "Reddish Brown"
            },
            new StorageContainerInformation
            {
                ColorName = "Sand Green",
                From = "00",
                To = "99",
                Name = BrightGreenDarkOrangeDarkPinkDarkPurpleSandGreen
            },
            new StorageContainerInformation
            {
                ColorName = "Tan",
                From = "00",
                To = "99",
                Name = "Tan"
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Black",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Bright Green",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Clear",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Dark Blue",
                From = "00",
                To = "99",
                Name = TransDarkBlueTransGreenTransLightBlueTransOrange
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Dark Purple",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Green",
                From = "00",
                To = "99",
                Name = TransDarkBlueTransGreenTransLightBlueTransOrange
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Light Blue",
                From = "00",
                To = "99",
                Name = TransDarkBlueTransGreenTransLightBlueTransOrange
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Neon Green",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Neon Orange",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Orange",
                From = "00",
                To = "99",
                Name = TransDarkBlueTransGreenTransLightBlueTransOrange
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Purple",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Red",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = "Trans-Yellow",
                From = "00",
                To = "99",
                Name = TransparentRest
            },
            new StorageContainerInformation
            {
                ColorName = White,
                From = "00",
                To = "19",
                Name = WhiteSandBlue
            },
            new StorageContainerInformation
            {
                ColorName = White,
                From = "20",
                To = "39",
                Name = WhiteMediumBlue,
            },
            new StorageContainerInformation
            {
                ColorName = White,
                From = "40",
                To = "59",
                Name = WhiteBrightLightBlue
            },
            new StorageContainerInformation 
            {
                ColorName = White,
                From = "60",
                To = "79",
                Name = string.Format(WhiteContainer, "60", "79")
            },
            new StorageContainerInformation
            {
                ColorName = White,
                From = "80",
                To = "99",
                Name = string.Format(WhiteContainer, "80", "99")
            },
            new StorageContainerInformation
            {
                ColorName = "Yellow",
                From = "00",
                To = "99",
                Name = DarkAzureYellow
            },
            new StorageContainerInformation
            {
                ColorName = "Yellowish Green",
                From = "00",
                To = "99",
                Name = DarkGreenDarkTanGreenMagentaYellowishGreen
            }
        };
        
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
                    partRecord.StorageContainer = StorageContainer(partRecord);
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

        private static string StorageContainer(PartRecord partRecord)
        {
            var hash = partRecord.PartNumber;
            while (!int.TryParse(hash[^1].ToString(), out var unused))
            {
                hash = hash.Remove(hash.Length - 1);
            }
            
            hash = hash.Substring(hash.Length - 2, 2);

            return Containers.FirstOrDefault(_ => _.ColorName == partRecord.ColorName 
                                                  && string.CompareOrdinal(_.From, hash) <= 0 
                                                  && string.CompareOrdinal(hash, _.To) <= 0)
                ?.Name;
        }
    }
}