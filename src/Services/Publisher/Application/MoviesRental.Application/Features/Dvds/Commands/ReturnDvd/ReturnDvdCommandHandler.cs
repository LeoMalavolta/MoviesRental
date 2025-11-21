using MediatR;
using MoviesRental.Application.Contracts;
using MoviesRental.Application.Features.Dvds.Commands.RentDvd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.ReturnDvd
{
    public class ReturnDvdCommandHandler : IRequestHandler<ReturnDvdCommand, ReturnDvdResponse>
    {
        private readonly IDvdsWriteRepository _repository;
        private readonly ReturnDvdCommandValidator _validator;

        public ReturnDvdCommandHandler(IDvdsWriteRepository repository, ReturnDvdCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<ReturnDvdResponse> Handle(ReturnDvdCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return default;

            var dvd = await _repository.Get(request.Id);
            if (dvd == null)
                return default;

            dvd.ReturnCopy();

            var result = await _repository.Update(dvd);
            if (!result)
                return default;

            return new ReturnDvdResponse(dvd.Id.ToString(), dvd.UpdatedAt);
        }
    }
}
