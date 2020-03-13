using System;
using System.Collections.Generic;
using LegoLib;

namespace SetBuilder
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ElementIds.Load();
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
            
            var inventoryToBuild = new Inventory("75252-1");

            Console.WriteLine("Calculating current inventory");
            var currentInventory = new Inventory();
            foreach (var setNumber in setNumbersOwned)
            {
                Console.WriteLine($"Adding set: {setNumber}");
                currentInventory += new Inventory(setNumber);
            }

            var missingInventory = currentInventory.MissingFrom(inventoryToBuild);
        }
    }
}