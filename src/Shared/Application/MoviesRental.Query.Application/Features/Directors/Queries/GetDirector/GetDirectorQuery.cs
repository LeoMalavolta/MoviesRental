using MediatR;

namespace MoviesRental.Query.Application.Features.Directors.Queries.GetDirector
{
    public record GetDirectorQuery(string fullName) : IRequest<GetDirectorQueryResponse>;
}
