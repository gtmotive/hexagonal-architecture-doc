using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Application.DeleteRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.DeleteRental
{
    public class DeleteRentalRequestHandler
        : IRequestHandler<DeleteRentalRequest, IWebApiPresenter>
    {
        private readonly IDeleteRentalUseCase _useCase;
        private readonly IDeleteRentalPresenter _presenter;

        public DeleteRentalRequestHandler(
            IDeleteRentalUseCase useCase,
            IDeleteRentalPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(DeleteRentalRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new DeleteRentalInput(request.Id);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
