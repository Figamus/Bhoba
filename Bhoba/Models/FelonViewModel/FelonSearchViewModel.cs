using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.FelonViewModel
{
    public class FelonSearchViewModel
    {
        public string Search { get; set; }

        public List<Felon> Felons { get; set; }
    }
}
