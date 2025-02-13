namespace c240tube.entity
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public Auth Auth { get; set; }


    }
}
