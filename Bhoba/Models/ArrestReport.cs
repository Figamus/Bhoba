using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class ArrestReport
    {
        [Key]
        public int ArrestReportId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrestDate { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please specify the type of violation")]
        public string CrimeType { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please enter a brief description of the violation")]
        public string Description { get; set; }
    }
}