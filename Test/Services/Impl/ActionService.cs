using System.Linq;
using Test.DTOs.Request;
using Test.Exceptions;
using Test.Models;

namespace Test.Services.Impl
{
    public class ActionService : IActionService
    {
        private readonly FirefightersDbContext _context;

        public ActionService(FirefightersDbContext context)
        {
            _context = context;
        }

        public bool AddFireTruckToAction(AssignFireTruckToActionRequestDto dto)
        {
            var action = _context.Actions.FirstOrDefault(a => a.IdAction.Equals(dto.IdAction));

            if (action == null)
            {
                throw new ResourceNotFoundException("Not found");
            }

            var fireTruck = _context.FireTrucks.FirstOrDefault(ft => ft.IdFireTruck.Equals(dto.IdFireTruck));

            if (fireTruck == null)
            {
                throw new ResourceNotFoundException("Not found");
            }

            if (!action.NeedSpecialEquipment.Equals(fireTruck.SpecialEquipment))
            {
                throw new ResourceNotFoundException("Track doesnt have required equipment");
            }
            
            var fireTruckAction = new FireTruckAction
            {
                Action =  action,
                FireTruck = fireTruck
            };

            _context.Add(fireTruckAction);
            _context.SaveChanges();

            return true;
        }
    }
}