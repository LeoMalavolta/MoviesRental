using MoviesRental.Query.Application.Features.Directors.Queries.GetDirector;
using MoviesRental.Query.Domain.Models;

namespace MoviesRental.Query.Application.Contracts
{
    public interface IDvdsQueryRepository : IQueryRepository<Dvd>
    {
    }
}
