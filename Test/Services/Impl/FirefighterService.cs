using System.Linq;
using Microsoft.EntityFrameworkCore;
using Test.DTOs.Response;
using Test.Exceptions;
using Test.Models;

namespace Test.Services.Impl
{
    public class FirefighterService : IFirefighterService
    {

        private readonly FirefightersDbContext _context;

        public FirefighterService(FirefightersDbContext context)
        {
            _context = context;
        }


        public FirefighterActionsResponseDto GetAllFirefighterActions(int idFireFighter)
        {
            var firefighter = _context.Firefighters
                .Where(f => f.IdFirefighter.Equals(idFireFighter))
                .Include(f => f.FirefighterActions)
                .ThenInclude(fa => fa.Action)
                .FirstOrDefault();

            if (firefighter == null)
            {
                throw new ResourceNotFoundException("Not found");
            }
            
            return new FirefighterActionsResponseDto
            {
                IdFirefighter = firefighter.IdFirefighter,
                Actions = firefighter.FirefighterActions.Select(fa => 
                    new ActionResponseDto
                    {
                        IdAction = fa.Action.IdAction,
                        StartTime = fa.Action.StartTime,
                        EndTime = fa.Action.EndTime
                    }).OrderByDescending(a => a.StartTime).ToList() 
            };
        }
    }
}