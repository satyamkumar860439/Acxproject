using System;
using System.ComponentModel.DataAnnotations;

namespace Acxproject.Models
{
    public class Employee
    {
        public int Id { get; set; }

        // Basic Info
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        // Contact Info
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string Phone { get; set; }

        
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

       
    }
}
