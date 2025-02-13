namespace c240tube.dto.request
{
    public class AuthSaveRequestDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string? surname { get; set; }

    }
}
