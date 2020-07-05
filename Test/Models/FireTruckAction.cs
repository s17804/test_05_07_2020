using System;

namespace Test.Models
{
    public class FireTruckAction
    {
        public int IdFireTruckAction { get; set; }
        public DateTime AssignmentDate { get; set; }
        
        public Action Action { get; set; }
        public FireTruck FireTruck { get; set; }
    }
}