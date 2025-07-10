namespace GasStationApi.Models;

    public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public Guid CylinderId { get; set; }
    public Cylinder? Cylinder { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; } = "cash";
    public bool IsPaid { get; set; } = true;
}

