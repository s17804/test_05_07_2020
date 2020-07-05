using Test.DTOs.Response;

namespace Test.Services
{
    public interface IFirefighterService
    {
        FirefighterActionsResponseDto GetAllFirefighterActions(int idFireFighter);
    }
}