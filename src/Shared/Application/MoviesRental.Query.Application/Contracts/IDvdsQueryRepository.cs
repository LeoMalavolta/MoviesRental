using MoviesRental.Query.Domain.Models;

namespace MoviesRental.Query.Application.Contracts
{
    public interface IDvdsQueryRepository : IQueryRepository<Dvd>
    {
        Task<Dvd> GetTitle(string title);
    }
}
