using TestMVC.Attributes;

namespace TestMVC.Dtos
{
    [ApiRoute("/Users/{uId}/Events")]
    public class EventDto
    {
        [ApiId("id", true)]
        public int Id { get; set; }
        [ApiId("uId")]
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public DateTime? Start { get; set; }
        public int? Duration { get; set; }
    }
}
