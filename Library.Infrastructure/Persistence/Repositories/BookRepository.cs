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
    public class BookRepository:IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Book book)
        {
            var bookNew = new Library.Core.Model.Book(
                book.Title,
                book.Description,
                book.Author,
                book.ISBN,
                book.Publisher,
                book.Category,
                book.PublicationYear,
                book.PageCount,
                book.CoverImage
            );

            await _dbContext.Books.AddAsync(bookNew);
            await _dbContext.SaveChangesAsync();

            return bookNew.Id;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync() {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id) {
            var book = await _dbContext.Books
                .Include(b => b.Ratings)
                .SingleAsync(book => book.Id == id);

            return book;
        }

        public async Task<List<Book>> GetByTitleAsync(string title)
        {
            var books = await _dbContext.Books
                .Where(book => book.Title == title)
                .ToListAsync();

            return books;
        }
    }
}
