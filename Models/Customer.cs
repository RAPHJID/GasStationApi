namespace GasStationApi.Models;

    public class Customer
    {
        public Guid Id {get;set;}
        public string FullName {get;set;} = string.Empty;
        public string Phone {get;set;} = string.Empty;
        public string Address {get;set;} = string.Empty;
        public string Type{get;set;} = "walk-in";
        
    }
