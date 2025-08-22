using Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetByTitleAsync(string title);
        Task<int> AddAsync(Book book);
        Task SaveChangesAsync();
    }
}
