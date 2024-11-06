using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model;

[Serializable]
public class Payment
{
    public long TransactionId { get; set; }
    public DateTime? PaymentDate { get; set; }
    [Required]
    public Student Student { get; set; }
    [Required]
    public Course Course { get; set; }

    private static List<Payment> _extent = [];

    public Payment(DateTime? paymentDate, Student student, Course course)
    {
        PaymentDate = paymentDate;
        Student = student;
        Course = course;

        CutsomValidator.Validate(this);

        _extent.Add(this);
    }

    public override string ToString()
    {
        return $"TransactionId: {TransactionId}, PaymentDate: {PaymentDate}";
    }
}