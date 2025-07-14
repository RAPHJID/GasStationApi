namespace GasStationApi.Models.DTOs
{
    public class InventoryDTO
    {
        public Guid Id { get; set; }
        public decimal QuantityAvailable { get; set; }
        public DateTime LastUpdated { get; set; }  

        public string CylinderType {get;set;} = string.Empty;
    }
}