namespace c240tube.entity
{
    public class Comment : BaseEntity
    {
        public long CustomerId { get; set; }
        public long VideoId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public string Description { get; set; }
        public Comment()
        {
            Like = 0;
            Dislike = 0;
        }

    }
}
