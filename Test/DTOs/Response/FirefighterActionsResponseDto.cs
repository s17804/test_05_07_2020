using System.Collections;
using System.Collections.Generic;

namespace Test.DTOs.Response
{
    public class FirefighterActionsResponseDto
    {
        public int IdFirefighter { get; set; }

        public ICollection<ActionResponseDto> Actions { get; set; } 
    }
}