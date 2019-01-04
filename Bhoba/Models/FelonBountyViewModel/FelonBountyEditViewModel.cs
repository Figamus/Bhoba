using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models.FelonBountyViewModel
{
    public class FelonBountyEditViewModel
    {
        public string PoliceReportNumber { get; set; }
        public string CrimeType { get; set; }
        public string Description { get; set; }
        public double BountyAmount { get; set; }
        public bool BondClosed { get; set; }
    }
}