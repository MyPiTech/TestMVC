﻿using System.ComponentModel.DataAnnotations;
using TestMVC.Dtos;

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
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Notes ")]
        public string? Notes { get; set; }

        public UserDto ToDto() => new() { Id = Id, FirstName = FirstName, LastName = LastName, Notes = Notes };
    }
}
