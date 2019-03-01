namespace CommonModels.Entity
{
    public class Group
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public Account Account { get; set; }
    }
}