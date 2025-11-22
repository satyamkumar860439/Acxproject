using System.ComponentModel.DataAnnotations;

namespace Acxproject.Models
{
    public class Customer
    {
            [Key]
            public int Id { get; set; }                // Customer ID
            public string Name { get; set; }           // Full name
            public string Phone { get; set; }          // Phone number
            public string Email { get; set; }          // Email address
            public string Password { get; set; }       // Password (should be stored hashed in real applications)
            public string Country { get; set; }        // Country
            public string City { get; set; }           // City
            public string Address { get; set; }        // Street address
            public string Gender { get; set; }         // Gender (e.g., Male, Female, Other)
            public string Image { get; set; }          // Path or URL to profile image
        }
    }
