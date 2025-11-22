using Microsoft.EntityFrameworkCore;
using MoviesRental.Application.Contracts;
using MoviesRental.Domain.Entities;
using MoviesRental.Infrastructure.Context;

namespace MoviesRental.Infrastructure.Repositories
{
    public class DirectorsWriteRepository : IDirectorsWriteRepository
    {
        public readonly MoviesRentalWriteContext _context;

        public DirectorsWriteRepository(MoviesRentalWriteContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Director entity)
        {
            await _context.Directors.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid Id)
        {
            await _context.Directors
                .Where(d => d.Id == Id)
                .ExecuteDeleteAsync();

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Director> Get(Guid Id)
             => await _context.Directors.FindAsync(Id);

        public async Task<Director> GetDirectorWithMovies(Guid Id)
            => await _context.Directors
            .AsNoTracking()
            .Include(d => d.Dvds)
            .FirstOrDefaultAsync(d => d.Id == Id);

        public async Task<bool> Update(Director entity)
        {
            _context.Directors.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
