using System;
using System.Collections;
using System.Collections.Generic;

namespace Test.Models
{
    public class Action
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public byte NeedSpecialEquipment { get; set; }

        public ICollection<FirefighterAction> FirefighterActions { get; set; }
        public ICollection<FireTruckAction> FireTruckActions { get; set; }
    }
}