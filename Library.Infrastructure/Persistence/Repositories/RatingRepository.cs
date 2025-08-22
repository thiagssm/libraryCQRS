using Azure.Core;
using Library.Core.Model;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly LibraryDbContext _dbContext;
        public RatingRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Rating>> GetByBookIdAsync(int bookId)
        {
            var ratings = await _dbContext.Ratings
                .Where(r => r.IdBook == bookId)
                .Include(r => r.User).ToListAsync();

            return ratings;
        }

        public async Task<Rating> GetByIdAsync(int id)
        {
            var rating = await _dbContext.Ratings.SingleAsync(r => r.Id == id);

            return rating;
        }

        public async Task<int> AddAsync(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
            await _dbContext.SaveChangesAsync();

            return rating.Id;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
