using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
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

    static Payment()
    {
        ExtentManager.LoadExtent<Payment>();
    }

    public Payment(DateTime? paymentDate, Student student, Course course)
    {
        PaymentDate = paymentDate;
        Student = student;
        Course = course;

        CutsomValidator.Validate(this);

        _extent.Add(this);
        ExtentManager.ClearExtent<Payment>();
        ExtentManager.SaveExtent(_extent);
    }

    public override string ToString()
    {
        return $"TransactionId: {TransactionId}, PaymentDate: {PaymentDate}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Payment payment &&
               TransactionId == payment.TransactionId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TransactionId);
    }
}