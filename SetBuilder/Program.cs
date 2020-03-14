﻿using System;
using System.Collections.Generic;
using System.Linq;
using LegoLib;
using MoreLinq;

namespace SetBuilder
{
    internal static class Program
    {
        private static List<(Inventory, int)> GetMissingPartSources(Inventory missingInventory, List<InventoryRecord> inventories)
        {
            var missingPartSources = inventories
                .Select(_ =>
                {
                    var inventory = new Inventory(_.SetNumber);
                    var partsCount = inventory.PartsCountFrom(missingInventory);

                    return (inventory, partsCount);
                })
                .Where(_ => _.Item2 > 0)
                .ToList();

            missingPartSources.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            return missingPartSources;
        }
        
        public static void Main(string[] args)
        {
            ElementIds.Load();
            Database.LoadColors();
            Database.LoadInventories();
            
            // TODO: There is a hidden dependency on ElementIds.Load(). That should be eliminated or automatically handled.
            Database.LoadParts();
            
            var setNumbersOwned = new List<string>
            {
                "60195-1",
                "76144-1",
                "76126-1",
                "10717-1",
                "80105-1",
                "60228-1",
                "76898-1",
                "76125-1",
                "76899-1",
                "70677-1",
                "60227-1",
                "42078-1",
                "75267-1",
                "60226-1",
                "60197-1",
                "60224-1",
                "60224-1",
                "60224-1",
                "75268-1",
                "75192-1",
                "40355-1"
            };

            var setsNotToBuy = new List<string>
            {
                "75192-1",
                "45680-1"

            };

            var retiredSets = new List<string>
            {
                "75827-1",
                "10221-1",
                "76042-1",
                "10179-1",
                "75190-1",
                "75095-1",
                "75222-1",
                "70840-1",
                "10143-1",
                "75055-1",
                "75101-1",
                "75211-1",
                "10177-1",
                "42043-1",
                "42009-1",
                "70922-1",
                "10178-1",
                "10247-1",
                "75144-1",
                "70657-1",
                "42030-1",
                "76057-1",
                "4000026-1",
                "4000024-1",
                "75104-1",
                "10197-1",
                "LLCA31-1",
                "75054-1",
                "75091-1",
                "10185-1",
                "10199-1",
                "71016-1",
                "60022-1",
                "75150-1",
                "76107-1",
                "45804-1",
                "10227-1",
                "70165-1",
                "4002018-1",
                "40338-1",
                "75919-1",
                "21309-1",
                "4000025-1",
                "10249-1",
                "42053-1",
                "75105-1",
                "10257-1",
                "45809-1",
                "10225-1",
                "70839-1",
                "970009-1",
                "70620-1",
                "21137-1",
                "60076-1",
                "10131-1",
                "45802-1",
                "75098-1",
                "10234-1",
                "10244-1",
                "75060-1",
                "70357-1",
                "31011-1",
                "70641-1",
                "10189-1",
                "60097-1",
                "75187-1",
                "75189-1",
                "10134-1",
                "10219-1",
                "31053-1",
                "71006-1",
                "4002017-1",
                "3300001-1",
                "LLCABR2-1",
                "10059-1",
                "60169-1",
                "21127-1",
                "76035-1",
                "79013-1",
                "10151-1",
                "31026-1",
                "4000005-1",
                "70912-1",
                "60176-1",
                "40362-1",
                "45807-1",
                "10251-1",
                "70613-1",
                "10174-1",
                "10030-1",
                "21315-1",
                "60059-1",
                "10218-1",
                "40346-1",
                "41187-1",
                "76021-1",
                "75154-1",
                "75883-1",
                "70914-1",
                "10697-1",
                "70658-1",
                "45805-1",
                "71042-1",
                "70317-1",
                "21125-1",
                "4000011-1",
                "75156-1",
                "75245-1",
                "45810-1",
                "75153-1",
                "4000020-1",
                "10229-1",
                "21301-1",
                "75259-1",
                "60074-1",
                "76006-1",
                "45801-1",
                "21108-1",
                "60165-1",
                "10235-1",
                "60047-1",
                "45100-1",
                "60204-1",
                "77903-1",
                "8096-1",
                "41347-1",
                "75042-1",
                "10937-1",
                "10253-1",
                "76054-1",
                "llca10-1",
                "31012-1",
                "4000034-1",
                "75082-1",
                "70814-1",
                "60096-1",
                "20010-1",
                "70631-1",
                "42007-1",
                "70916-1",
                "41195-1",
                "70810-1",
                "31085-1",
                "40253-1",
                "75145-1",
                "60049-1",
                "75186-1",
                "76049-1",
                "41318-1",
                "75913-1",
                "75053-1",
                "75157-1",
                "42029-1",
                "76026-1",
                "75200-1",
                "40360-1",
                "60085-1",
                "70731-1",
                "70356-1",
                "75019-1",
                "20001-1",
                "76028-1",
                "70618-1",
                "LIT2009-1",
                "10214-1",
                "10405-1",
                "79016-1",
                "41153-1",
                "70917-1",
                "60026-1",
                "70626-1",
                "10211-1",
                "75151-1",
                "60050-1",
                "60130-1",
                "76013-1",
                "10195-1",
                "41122-1",
                "70322-1",
                "75168-1",
                "75051-1",
                "7915-1",
                "41074-1",
                "10747-1",
                "76075-1",
                "10187-1",
                "75904-1",
                "70169-1",
                "21038-1",
                "76108-1",
                "75917-1",
                "76040-1",
                "76055-1",
                "70632-1",
                "75886-1",
                "10723-1",
                "41173-1",
                "70604-1",
                "75177-1",
                "50003-1",
                "4002019-1",
                "70014-1",
                "10248-1",
                "40303-1",
                "911842-1",
                "75106-1",
                "76052-1",
                "42039-1",
                "75100-1",
                "60079-1",
                "75233-1",
                "10223-1",
                "70162-1",
                "21130-1",
                "70614-1",
                "40334-1",
                "4000007-1",
                "60060-1",
                "10686-1",
                "75201-1",
                "70611-1",
                "70013-1",
                "75902-1",
                "75915-1",
                "76087-1",
                "10746-1",
                "79122-1",
                "60131-1",
                "75226-1",
                "75207-1",
                "76045-1",
                "10222-1",
                "41056-1",
                "42069-1",
                "75092-1",
                "75059-1",
                "41319-1",
                "70170-1",
                "76046-1",
                "30121-1",
                "41155-1",
                "40433-1",
                "75184-1",
                "60193-1",
                "42036-1",
                "41541-1",
                "71251-1",
                "70167-1",
                "76082-1",
                "75083-1",
                "75103-1",
                "70114-1",
                "72006-1",
                "7044-1",
                "45102-1",
                "60115-1",
                "70803-1",
                "20203-1",
                "10236-1",
                "75018-1",
                "75039-1",
                "75099-1",
                "70732-1",
                "60167-1",
                "42076-1",
                "75048-1",
                "30056-1",
                "75149-1",
                "42022-1",
                "75916-1",
                "76076-1",
                "76071-1",
                "70615-1",
                "120438-1",
                "75530-1",
                "LLPlane-1",
                "42028-1",
                "60018-1",
                "20007-1",
                "70809-1",
                "70002-1",
                "30302-1",
                "70327-1",
                "70224-1",
                "21105-1",
                "10673-1",
                "75043-1",
                "60009-1",
                "60101-1",
                "70010-1",
                "70012-2",
                "21136-1",
                "42000-1",
                "76079-1",
                "70355-1",
                "10156-1",
                "75262-1",
                "21041-1",
                "70610-1",
                "70591-1",
                "70006-1",
                "40165-1",
                "Minneapolis-2",
                "75172-1",
                "70812-1",
                "31036-1",
                "60098-1",
                "10072-1",
                "41067-1",
                "CAPTAINMARVEL-1",
                "10024-1",
                "41077-1",
                "70627-1",
                "60179-1",
                "42037-1",
                "31044-1",
                "60013-1",
                "41007-1",
                "70816-1",
                "21102-1",
                "79104-1",
                "71300-1",
                "60110-1",
                "31043-1",
                "70139-1",
                "60175-1",
                "30277-1",
                "30350-1",
                "42057-1",
                "970098-1",
                "comcon019-1",
                "70596-1",
                "21133-1",
                "21030-1",
                "K8761-1",
                "60173-1",
                "75050-1",
                "70410-1",
                "10018-1",
                "60140-1",
                "31052-1",
                "79007-1",
                "42045-1",
                "53850009-1",
                "41184-1",
                "5004590-1",
                "70923-1",
                "30383-1",
                "30228-1",
                "70660-1",
                "70594-1",
                "75212-1",
                "75010-1",
                "10175-1",
                "30315-1",
                "79120-1",
                "31028-1",
                "77902-1",
                "41579-1",
                "40366-1",
                "70601-1",
                "70740-1",
                "60154-1",
                "41339-1",
                "10217-1",
                "75007-1",
                "41300-1",
                "75196-1",
                "10765-1",
                "41097-1",
                "4679b-2",
                "911617-1",
                "75158-1",
                "912056-1",
                "75147-1",
                "21146-1",
                "852741-1",
                "31042-1",
                "60166-1",
                "31010-1",
                "20208-1",
                "70904-1",
                "10259-1",
                "10734-1",
                "75030-1",
                "60162-1",
                "75193-1",
                "4002016-1"
            };

            var currentlyAvailable = new List<string>
            {
                "76127-1",
                "60226-1",
                "76143-1",
                "31097-1",
                "70431-1",
                "76113-1",
                "10770-1",
                "10220-1",
                "76126-1",
                "31094-1",
                "76146-1",
                "75894-1",
                "42101-1",
                "70679-1",
                "71699-1",
                "41164-1",
                "71710-1",
                "853687-1",
                "76120-1",
                "75955-1",
                "41379-1",
                "76125-1",
                "76122-1",
                "76131-1",
                "21316-1",
                "70421-1",
                "76148-1",
                "80105-1",
                "60254-1",
                "75937-1",
                "70653-1",
                "31105-1",
                "40359-1",
                "70829-1",
                "75251-1",
                "31058-1",
                "31098-1",
                "41252-1",
                "75976-1",
                "71044-1",
                "60244-1",
                "41381-1",
                "60246-1",
                "21051-1",
                "60203-1",
                "80103-1",
                "21039-1",
                "60228-1",
                "31090-1",
                "60233-1",
                "75929-1",
                "75973-1",
                "21321-1",
                "41375-1",
                "41395-1",
                "76139-1",
                "70830-1",
                "31096-1",
                "75938-1",
                "60216-1",
                "70654-1",
                "17101-1",
                "75935-1",
                "21046-1",
                "10260-1",
                "31104-1",
                "42077-1",
                "60257-1",
                "11005-1",
                "21317-1",
                "10261-1",
                "60229-1",
                "10255-1",
                "75936-1",
                "75159-1",
                "75181-1",
                "10258-1",
                "71040-1",
                "10270-1",
                "42100-1",
                "71043-1",
                "75244-1",
                "10264-1",
                "75243-1",
                "42082-1",
                "60198-1",
                "10272-1",
                "75257-1",
                "42098-1",
                "70670-1",
                "75253-1",
                "10265-1",
                "70425-1",
                "42097-1",
                "10266-1",
                "10256-1",
                "10269-1",
                "75242-1",
                "10717-1"
            };

            var outOfStockSets = new List<string>
            {
                "21311-1",
                "21319-1",
                "70849-1",
                "70668-1",
                "21318-1",
                "75234-1",
                "70669-1",
                "76116-1",
                "75254-1",
                "70684-1",
                "21143-1",
                "42083-1",
                "75220-1",
                "70841-1",
                "75248-1",
                "60194-1",
                "76016-1",
                "31063-1",
                "70312-1",
                "41075-1",
                "60043-1",
            };
            
            var inventoryToBuild = new Inventory("75252-1");

            Console.WriteLine("Calculating current inventory");
            var currentInventory = new Inventory();
            foreach (var setNumber in setNumbersOwned)
            {
                currentInventory += new Inventory(setNumber);
            }

            var missingInventory = currentInventory.MissingFrom(inventoryToBuild);
            var missingParts = missingInventory.TotalParts;

            var setsToIgnore = new List<string>();
            setsToIgnore.AddRange(setsNotToBuy);
            setsToIgnore.AddRange(retiredSets);
            setsToIgnore.Add(inventoryToBuild.SetNumber);
            setsToIgnore.AddRange(outOfStockSets);

            var initialList = Database
                .Inventories
                .Values
                .Where(_ => _.SetNumber.Split('-')[0].Length > 4)
                .Where(_ => !setsToIgnore.Contains(_.SetNumber))
                .ToList();
            var missingPartSources = 
                GetMissingPartSources(missingInventory, initialList)
                    .Select(_ => _.Item1)
                    .ToList();

            var whatToBuy = new Dictionary<string, int>();
            var buyingOrder = new List<string>();
            while (missingParts > 0 && missingPartSources.Count > 0)
            {
                var setToBuy = missingPartSources.First();
                if (!whatToBuy.ContainsKey(setToBuy.SetNumber))
                {
                    whatToBuy.Add(setToBuy.SetNumber, 0);
                    buyingOrder.Add(setToBuy.SetNumber);
                }

                whatToBuy[setToBuy.SetNumber]++;
                currentInventory += setToBuy;

                missingInventory = currentInventory.MissingFrom(inventoryToBuild);
                missingParts = missingInventory.TotalParts;

                var inventories = missingPartSources.Select(_ => Database.Inventories[_.SetNumber]).ToList();
                missingPartSources = GetMissingPartSources(missingInventory, inventories)
                    .Select(_ => _.Item1)
                    .ToList();
            }
            
            Console.WriteLine("Sets to buy:");
            buyingOrder.ForEach(_ =>
            {
                var verificationUrl = currentlyAvailable.Contains(_) ? "" : $": https://www.lego.com/en-au/search?q={_} https://rebrickable.com/sets/{_}"; 
                Console.WriteLine($"Set {_} {whatToBuy[_]}{verificationUrl}");
            });
            
            Console.WriteLine($"Missing parts: {missingParts}");
            var inventoryId = Database.Inventories[inventoryToBuild.SetNumber].Id;
            missingInventory.Parts.ForEach(kvp =>
            {
                var partRecord = Database.Parts[inventoryId].First(_ => _.ElementIds == kvp.Key);
                Console.WriteLine($"Missing item: {kvp.Key} => {kvp.Value} https://rebrickable.com/parts/{partRecord.PartNumber}, {partRecord.ColorName}");
            });
//            while (missingParts > 0)
//            {
//                
//            }
            
//            missingPartSources.Take(10).ForEach(_ =>
//            {
//                Console.WriteLine($"{_.Item1.SetNumber}: {_.Item2}");
//            });
            
//            foreach (var inventoryRecord in Database.Inventories)
//            {
//                var inventory = new Inventory(inventoryRecord.SetNumber);
//                Console.WriteLine($"{inventory.SetNumber}: {inventory.PartsCountFrom(missingInventory)}");
//            }
//            while (missingParts > 0)
            {
//                var bestSet = Database
//                    .Inventories
//                    .Select(_ => new Inventory(_.SetNumber))
//                    .OrderBy(_ => _.PartsCountFrom(missingInventory))
//                    .First()
//                    .SetNumber;
//                
//                Console.WriteLine(bestSet);
            }
        }
    }
}