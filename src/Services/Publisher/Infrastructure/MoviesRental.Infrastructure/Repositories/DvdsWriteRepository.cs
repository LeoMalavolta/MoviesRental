using MoviesRental.Application.Contracts;
using MoviesRental.Domain.Entities;


namespace MoviesRental.Infrastructure.Repositories
{
    public class DvdsWriteRepository : IDvdsWriteRepository
    {
        public Task<bool> Create(Dvd entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Dvd> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Dvd entity)
        {
            throw new NotImplementedException();
        }
    }
}
