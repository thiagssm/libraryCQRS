using Library.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> GetByIdAsync(int id);
        Task<List<Rating>> GetByBookIdAsync(int bookId);
        Task<int> AddAsync(Rating rating);
        Task SaveChangesAsync();
    }
}
