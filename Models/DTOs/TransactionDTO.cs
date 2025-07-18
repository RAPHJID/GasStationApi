namespace GasStationApi.Models.DTOs
{
    public class TransactionDTO
    {
        public Guid Id {get;set;}
        public string CustomerName {get;set;}
        public string CylinderType {get;set;}
        public string CylinderBrand {get;set;}
        public decimal AmountPaid {get;set;}
        public string PaymentMethod {get;set;} 
        public DateTime Date{get;set;}
    }
}