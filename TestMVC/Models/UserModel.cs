using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class UserModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Nmae")]
        public string? LastName { get; set; }

        public string? Notes { get; set; }


    }
}
