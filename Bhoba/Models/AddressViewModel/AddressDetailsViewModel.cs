using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.AddressViewModel
{
    public class AddressDetailsViewModel
    {
        public Address Address { get; set; }
        public List<Felon> Felons { get; set; } = new List<Felon>();
    }
}
