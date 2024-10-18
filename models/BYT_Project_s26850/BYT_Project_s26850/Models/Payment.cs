namespace BYT_Project_s26850.Models;

public class Payment
{
    public long TransactionId { get; set; }
    public bool IsSucceed { get; set; }
    public DateTime PaymentDate { get; set; }
    
    public Student Student { get; set; }
    
    
}