namespace LegoLib
{
    public class PartRecord
    {
        public string InventoryId { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string CategoryName { get; set; }
        public string ColorId { get; set; }
        public string ColorName { get; set; }
        public string Quantity { get; set; }
        public bool IsSpare { get; set; }
        public string ElementIds { get; set; }
        public string PartPicture { get; set; }
    }
}
