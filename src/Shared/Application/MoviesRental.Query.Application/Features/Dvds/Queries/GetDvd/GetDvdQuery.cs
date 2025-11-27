using MediatR;
using MoviesRental.Query.Application.Features.Directors.Queries.GetDirector;

namespace MoviesRental.Query.Application.Features.Dvds.Queries.GetDvd
{
    public record GetDvdQuery(string title) : IRequest<GetDvdResponse>;
}
