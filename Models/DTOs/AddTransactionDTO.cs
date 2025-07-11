namespace GasStationApi.Models.DTOs
{
    public class AddTransactionDTO
    {
        public Guid CustomerId {get;set;}
        public Guid CylinderId {get;set;}
        public decimal AmountPaid {get;set;}
        public string PaymentMethod {get;set;} = "cash";
        
    }
}