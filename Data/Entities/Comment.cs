namespace marketplace.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int AdId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public Ad Ad { get; set; }
    }
}
