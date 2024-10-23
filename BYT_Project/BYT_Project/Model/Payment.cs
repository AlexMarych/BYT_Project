namespace BYT_Project.Model;

public class Payment
{
    public long TransactionId { get; set; }
    public bool IsSucceed { get; set; }
    public DateTime PaymentDate { get; set; }
    
    public Student Student { get; set; }
    public Course Course { get; set; }

    private static List<Payment> _extent = [];

    public Payment(bool isSucceed, DateTime paymentDate, Student student, Course course)
    {
        IsSucceed = isSucceed;
        PaymentDate = paymentDate;
        Student = student;
        Course = course;

        _extent.Add(this);

        ExtentManager.SaveExtent(_extent);
    }

    public override string ToString()
    {
        return $"TransactionId: {TransactionId}, IsSucceed: {IsSucceed}, PaymentDate: {PaymentDate}";
    }
}