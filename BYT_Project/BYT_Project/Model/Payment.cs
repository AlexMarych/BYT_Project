namespace BYT_Project.Model;

public class Payment
{
    public long TransactionId { get; set; }
    public bool IsSucceed { get; set; }
    public DateTime PaymentDate { get; set; }
    
    public required Student Student { get; set; }
    public required Course Course { get; set; }

    private static List<Payment> _extent = [];

    public Payment(long transactionId, bool isSucceed, DateTime paymentDate, Student student, Course course)
    {
        TransactionId = transactionId;
        IsSucceed = isSucceed;
        PaymentDate = paymentDate;
        Student = student;
        Course = course;

        _extent.Add(this);

        ExtentManager.SaveExtent(_extent);
    }
}