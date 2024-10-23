using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
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

        public Petition(string text, StatusType status)
        {
            Text = text;
            Status = status;

            _extent.Add(this);
            ExtentManager.SaveExtent(_extent);
        }
    }
}