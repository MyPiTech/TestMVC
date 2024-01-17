using System.ComponentModel.DataAnnotations;
using TestMVC.Dtos;

namespace TestMVC.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Event Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Event Location")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start is required.")]
        [Display(Name = "Event Start")]
        public DateTime? Start { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 100, ErrorMessage = "Enter number between 1 to 100")]
        [Display(Name = "Event Duration")]
        public int? Duration { get; set; }

        public EventDto ToDto() => new() { Duration = Duration ?? default, UserId = UserId, Title = Title, Id = Id, Location = Location, Start = Start ?? default};    
    }
}
