using MediatR;
using MoviesRental.Application.Contracts;

namespace MoviesRental.Application.Features.Dvds.Commands.RentDvd
{
    public class RentDvdCommandHandler : IRequestHandler<RentDvdCommand, RentDvdResponse>
    {
        private readonly IDvdsWriteRepository _repository;
        private readonly RentDvdCommandValidator _validator;

        public RentDvdCommandHandler(IDvdsWriteRepository repository, RentDvdCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<RentDvdResponse> Handle(RentDvdCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return default;

            var dvd = await _repository.Get(request.Id);
            if (dvd == null)
                return default;

            dvd.RentCopy();

            var result = await _repository.Update(dvd);
            if (!result)
                return default;

            return new RentDvdResponse(dvd.Id.ToString(), dvd.UpdatedAt);
        }
    }
}
