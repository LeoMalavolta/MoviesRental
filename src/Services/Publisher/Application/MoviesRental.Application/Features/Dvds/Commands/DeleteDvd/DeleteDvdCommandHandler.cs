using MediatR;
using MoviesRental.Application.Contracts;

namespace MoviesRental.Application.Features.Dvds.Commands.DeleteDvd
{
    public class DeleteDvdCommandHandler : IRequestHandler<DeleteDvdCommand, DeleteDvdResponse>
    {
        private IDvdsWriteRepository _repository;
        private readonly DeleteDvdCommandValidator _validator;

        public DeleteDvdCommandHandler(IDvdsWriteRepository repository, DeleteDvdCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<DeleteDvdResponse> Handle(DeleteDvdCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return default;

            var Dvd = await _repository.Get(request.Id);
            if (Dvd is null)
                return default;

            Dvd.DeleteDvd();

            var result = await _repository.Update(Dvd);
            if (!result)
                return default;

            return new DeleteDvdResponse(Dvd.Id.ToString(), Dvd.DeletedAt);
        }
    }
}
