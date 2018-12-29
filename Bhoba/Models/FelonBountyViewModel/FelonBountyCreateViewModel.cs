using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.FelonBountyViewModel
{
    public class FelonBountyCreateViewModel
    {
        public List<SelectListItem> BailBondsmans { get; set; }
        public int BailBondsmansId { get; set; }
        public FelonBounty FelonBounty {get; set; }
        public Felon Felon { get; set; }
    }
}