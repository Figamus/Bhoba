using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.FelonViewModel
{
    public class FelonDetailsViewModel
    {
        public Felon Felon { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<AddressVM> listOfAvm { get; set; } = new List<AddressVM>();
        public List<BailBondsman> BailBondsmen { get; set; } = new List<BailBondsman>();
        public ApplicationUser User { get; set; }
    }
}
