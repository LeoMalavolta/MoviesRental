using MediatR;
using MoviesRental.Query.Application.Contracts;

namespace MoviesRental.Query.Application.Features.Directors.Queries.GetDirector
{
    public class GetDirectorQueryHandler : IRequestHandler<GetDirectorQuery, GetDirectorQueryResponse>
    {
        private readonly IDirectorsQueryRepository _repository;

        public GetDirectorQueryHandler(IDirectorsQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDirectorQueryResponse> Handle(GetDirectorQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.fullName))
                return default;

            var director = await _repository.GetByName(request.fullName);
            if (director is null)
                return default;

            return new GetDirectorQueryResponse(director.Id, director.FullName);
        }
    }
}
