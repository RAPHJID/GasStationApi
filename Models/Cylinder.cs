namespace GasStationApi.Models;

    public class Cylinder
    {
        public Guid Id {get;set;}
        public string Type {get;set;} = string.Empty;//e.g "6kg"
        public string Brand {get;set;} = string.Empty;
        public string Status {get;set;} = "available";
    }
