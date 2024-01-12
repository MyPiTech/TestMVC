using TestMVC.Attributes;

namespace TestMVC.Dtos
{
    [ApiRoute("/Users")]
    public class UserDto
    {
        [ApiId("id", true)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Notes { get; set; }
    }
}
