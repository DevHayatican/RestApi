namespace c240tube.entity
{
    public class Streamer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public decimal? Amount { get; set; }
        public Auth Auth { get; set; }

    }
}
