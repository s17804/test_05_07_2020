using System.Collections;
using System.Collections.Generic;

namespace Test.Models
{
    public class FireTruck
    {
        public int IdFireTruck { get; set; }
        public string TruckNumber { get; set; }
        public byte SpecialEquipment { get; set; }

        public ICollection<FireTruckAction> FireTruckActions { get; set; }
    }
}