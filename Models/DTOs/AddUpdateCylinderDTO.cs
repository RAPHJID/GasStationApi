namespace GasStationApi.Models.DTOs
{
    public class AddUpdateCylinderDTO
    {
        public string Type {get;set;} = string.Empty;
        public string Brand {get;set;} = string.Empty;
        public string Status {get;set;} = "available";
    }
}