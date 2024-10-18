namespace BYT_Project.Model;

public class Payment
{
    public long TransactionId { get; set; }
    public bool IsSucceed { get; set; }
    public DateTime PaymentDate { get; set; }
    
    public required Student Student { get; set; }
}