namespace Test.Models
{
    public class FirefighterAction    
    {

        public int IdFirefighter { get; set; }

        public int IdAction { get; set; }
        
        public Firefighter Firefighter { get; set; }
        public Action Action { get; set; }
    }
}