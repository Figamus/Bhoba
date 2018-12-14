using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.FelonViewModel
{
    public class FelonCreateViewModel
    {
        public Felon Felon { get; set; }
        public Address Address { get; set; }
        public int BailBondsmansId { get; set; }
        public List<SelectListItem> BailBondsmans { get; set; }
    }
}