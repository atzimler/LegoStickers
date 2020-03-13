using System.Collections.Generic;
using System.Linq;
using LegoLib;
using MoreLinq;

namespace SetBuilder
{
    public class Inventory
    {
        private readonly Dictionary<string, int> _parts = new Dictionary<string, int>();

//        public Inventory(IEnumerable<PartRecord> partRecords)
//        {
//            partRecords.ForEach(partRecord =>
//            {
//                var quantity = int.Parse(partRecord.Quantity);
//                _parts.Add(partRecord.ElementIds, quantity);
//            });
//        }

        public Inventory()
        {
        }

        public Inventory(Inventory other)
        {
            other._parts.ForEach(kvp => { _parts.Add(kvp.Key, kvp.Value); });
        }

        public Inventory(string setNumber)
        {
            var inventory = Database.Inventories.First(_ => _.SetNumber == setNumber);

            Database
                .Parts
                .Where(_ => _.InventoryId == inventory.Id)
                .ForEach(part => AddParts(part.ElementIds, int.Parse(part.Quantity)));
        }

        private void AddParts(string elementIds, int quantity)
        {
            if (!_parts.ContainsKey(elementIds))
            {
                _parts.Add(elementIds, quantity);
            }
            else
            {
                _parts[elementIds] += quantity;
            }
        }

        public static Inventory operator +(Inventory left, Inventory right)
        {
            var result = new Inventory(left);
            right._parts.ForEach(kvp => result.AddParts(kvp.Key, kvp.Value));

            return result;
        }

        public Inventory MissingFrom(Inventory target)
        {
            var missing = new Inventory();
            target._parts.ForEach(part =>
            {
                if (!_parts.ContainsKey(part.Key))
                {
                    missing._parts.Add(part.Key, part.Value);
                    return;
                }

                var available = _parts[part.Key] - target._parts[part.Key];
                if (available < 0)
                {
                    missing._parts.Add(part.Key, -available);
                }
            });

            return missing;
        }
    }
}