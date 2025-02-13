namespace c240tube.entity
{
    public class Video : BaseEntity
    {
        public Streamer Streamer { get; set; }
        public string Title { get; set; }
        public double Range { get; set; }
        public string Url { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

        public Video()
        {
            Like = 0;
        }

    }
}
