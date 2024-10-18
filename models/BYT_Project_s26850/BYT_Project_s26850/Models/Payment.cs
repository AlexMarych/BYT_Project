namespace BYT_Project_s26850.Models;

public class Payment
{
    public long transactionId { get; set; }
    public bool isSucceed { get; set; }
    public DateTime paymentDate { get; set; }
    
    public Student Student { get; set; }
    
    
}