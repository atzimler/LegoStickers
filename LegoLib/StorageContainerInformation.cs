using System.Collections.Generic;
using System.Linq;

namespace LegoLib
{
    public class StorageContainerInformation
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
        private const string ReddishBrown = "Reddish Brown";
        private const string ReddishBrownContainer = "Reddish Brown {0} - {1}";
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
                ColorName = "Medium Blue",
                From = "00",
                To = "99",
                Name = WhiteMediumBlue,
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
                ColorName = ReddishBrown,
                From = "00",
                To = "49",
                Name = string.Format(ReddishBrownContainer, "00", "49")
            },
            new StorageContainerInformation
            {
                ColorName = ReddishBrown,
                From = "50",
                To = "99",
                Name = string.Format(ReddishBrownContainer, "50", "99")
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
            },
            new StorageContainerInformation
            {
                ColorName = "Bright Light Blue",
                From = "00",
                To = "99",
                Name = WhiteBrightLightBlue
            }
        };

        public static string StorageContainer(PartRecord partRecord)
        {
            var hash = Database.MainPartNumber(partRecord.PartNumber).ToString();
            hash = hash.Substring(hash.Length - 2, 2);

            return Containers.FirstOrDefault(_ => _.ColorName == partRecord.ColorName 
                                                  && string.CompareOrdinal(_.From, hash) <= 0 
                                                  && string.CompareOrdinal(hash, _.To) <= 0)
                ?.Name;
        }
      
        
        public string ColorName { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}