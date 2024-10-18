namespace BYT_Project.model
{
    public class Petition
    {
        public long Id { get; set; }
        public required string Text { get; set; }
        public required StatusType Status { get; set; }
    }
}