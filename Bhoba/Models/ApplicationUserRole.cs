using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class ApplicationUserRole
    {
        [Key]
        public int ApplicationUserRoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
