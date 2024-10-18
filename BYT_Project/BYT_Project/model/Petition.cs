namespace BYT_Project.Model
{
    public class Petition
    {
        public long Id { get; set; }
        public required string Text { get; set; }
        public required StatusType Status { get; set; }
    }
}