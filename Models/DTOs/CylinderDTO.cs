namespace GasStationApi.Models.DTOs
{
    public class CylinderDTO
    {
        public Guid Id {get;set;}
        public string Type {get;set;} = string.Empty;
        public string Brand {get;set;} = string.Empty;
        public string Status {get;set;} = "available";
    }
}