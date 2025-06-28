namespace VibesAndChill.Shared.Models
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PreferredGender { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
    }

    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
