using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.FelonViewModel
{
    public class FelonIndexViewModel
    {
        public List<Felon> Felons { get; set; }
        public ApplicationUser User { get; set; }
    }
}