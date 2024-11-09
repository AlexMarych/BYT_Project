using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    [Serializable]
    public class Petition
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }

        public enum StatusType
        {
            Opened,
            Closed
        }
        public StatusType Status { get; set; }
        private static List<Petition> _extent = [];

        static Petition()
        {
            _extent = ExtentManager.LoadExtent<Petition>();
        }

        public Petition(string text, StatusType status)
        {
            Text = text;
            Status = status;

            CutsomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Petition>();
            ExtentManager.SaveExtent(_extent);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Text: {Text}, Status: {Status}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Petition petition &&
                   Id == petition.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}