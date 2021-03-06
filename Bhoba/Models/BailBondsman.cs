﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class BailBondsman
    {
        [Key]
        [Display(Name = "Bailbond Agency")]
        public int BailBondsmanId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public Address Address { get; set; }

        public virtual ICollection<RecoveryAgent> RecoveryAgents { get; set; }
        public List<FelonBounty> FelonBounties { get; set; }
    }
}
