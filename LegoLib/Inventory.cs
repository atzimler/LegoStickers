using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace LegoLib
{
    public class Inventory
    {
        private readonly Dictionary<string, int> _parts = new Dictionary<string, int>();

        public IReadOnlyDictionary<string, int> Parts => _parts;
        public string SetNumber { get; }
        public int TotalParts { get; private set; }

        public Inventory()
        {
        }

        public Inventory(Inventory other)
        {
            other._parts.ForEach(kvp => { _parts.Add(kvp.Key, kvp.Value); });
        }

        public Inventory(string setNumber)
        {
            SetNumber = setNumber;
            var inventory = Database.Inventories[setNumber];

            if (!Database.Parts.ContainsKey(inventory.Id))
            {
                return;
            }
            
            Database
                .Parts[inventory.Id]
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

            TotalParts += quantity;
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
                    missing.AddParts(part.Key, part.Value);
                    return;
                }

                var available = _parts[part.Key] - target._parts[part.Key];
                if (available < 0)
                {
                    missing.AddParts(part.Key, -available);
                }
            });

            return missing;
        }

        public int PartsCountFrom(Inventory inventory) =>
            _parts
                .Where(_ => inventory._parts.ContainsKey(_.Key))
                .Select(_ => Math.Min(_.Value, inventory._parts[_.Key]))
                .Sum();
    }
}