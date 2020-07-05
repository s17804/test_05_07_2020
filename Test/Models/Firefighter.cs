using System.Collections;
using System.Collections.Generic;

namespace Test.Models
{
    public class Firefighter
    {
        public int IdFirefighter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<FirefighterAction> FirefighterActions { get; set; }
    }
}