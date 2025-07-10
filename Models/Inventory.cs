namespace GasStationApi.Models;

    public class Inventory
    {
        public Guid Id {get;set;}
        public decimal QuantityAvailable {get;set;}
        public DateTime LastUpdated {get;set;} = DateTime.Now;
        
    }
