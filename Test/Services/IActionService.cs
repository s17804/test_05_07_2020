using Test.DTOs.Request;

namespace Test.Services
{
    public interface IActionService
    {
        bool AddFireTruckToAction(AssignFireTruckToActionRequestDto dto);
    }
}