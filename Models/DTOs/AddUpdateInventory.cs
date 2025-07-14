namespace GasStationApi.Models.DTOs
{
    public class AddUpdateInventory
    {
        public Guid CylinderId { get; set; }
        public decimal QuantityAvailable { get; set; }
        
    }
}