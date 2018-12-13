using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Bhoba.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public int ApplicationUserRoleId { get; set; }


        [Required]
        public Address Address { get; set; }

        [Required]
        public ApplicationUserRole Role { get; set; }
    }
}
