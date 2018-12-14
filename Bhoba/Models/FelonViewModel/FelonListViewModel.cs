using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.FelonViewModel
{
    public class FelonListViewModel
    {
        public Felon Felon { get; set; }
        public List<Address> Address { get; set; }
    }
}
