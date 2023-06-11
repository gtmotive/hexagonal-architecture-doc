using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehiclesUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehiclesUseCase
{
    [ApiController]
    public class GetAllAvailableVehiclesApiEndpoint : ControllerBase
    {
        private readonly IGetAllAvailableVehiclesWebApiPresenter _presenter;
        private readonly IGetAllAvailableVehiclesUseCase _useCase;

        public GetAllAvailableVehiclesApiEndpoint(IGetAllAvailableVehiclesWebApiPresenter presenter, IGetAllAvailableVehiclesUseCase useCase)
        {
            _presenter = presenter;
            _useCase = useCase;
        }

        [HttpGet("/Vehicles/Available")]
        public async Task<IActionResult> GetAllAvailableVehicles()
        {
            await _useCase.Execute();

            return _presenter.ActionResult;
        }
    }
}
