using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please enter a street address")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please enter a state")]
        public string State { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please enter a zipcode")]
        public string ZipCode { get; set; }

        public float? Latitude { get; set; }
        public float? Longitude { get; set; }

        public List<FelonAddress> FelonAddresses { get; set; }
    }
}