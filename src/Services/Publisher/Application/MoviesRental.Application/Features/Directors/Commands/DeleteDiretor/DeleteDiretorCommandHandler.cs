using MediatR;
using MoviesRental.Application.Contracts;

namespace MoviesRental.Application.Features.Directors.Commands.DeleteDiretor
{
    public class DeleteDiretorCommandHandler : IRequestHandler<DeleteDiretorCommand, bool>
    {
        public readonly IDirectorsWriteRepository _repository;
        public readonly DeleteDiretorCommandValidator _validator;

        public DeleteDiretorCommandHandler(IDirectorsWriteRepository repository, DeleteDiretorCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteDiretorCommand request, CancellationToken cancellationToken)
        {
           var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return false;

            var director = await _repository.GetDirectorWithMovies(request.Id);
            if (director == null || director.Dvds.Any(x => x.Available))
                return false;

            return await _repository.Delete(director.Id);
        }
    }
}
