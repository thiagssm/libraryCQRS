using Library.Application.DTOs.Book;
using Library.Application.Services.Interfaces;
using Library.Core.Model;
using Library.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;
        public BookService(LibraryDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public int Create(CreateBookInputModel model)
        {
            var book = new Book(
                model.Id,
                model.Title, 
                model.Description, 
                model.Author, 
                model.ISBN, 
                model.Publisher, 
                model.Category, 
                model.PublicationYear, 
                model.PageCount, 
                model.CoverImage
                );

            _dbContext.Books.Add( book );

            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault( book => book.Id == id );

            book.Desativar();
        }

        public List<BookViewModel> GetAll()
        {
            var booksViewModel = _dbContext.Books
                .Select(b => new BookViewModel(
                    b.Title,
                    b.Description,
                    b.Author,
                    b.ISBN,
                    b.Publisher,
                    b.Category,
                    b.PublicationYear,
                    b.PageCount,
                    b.CoverImage,
                    b.AverageRating
                    ))
                .ToList();

            return booksViewModel;
        }

        public BookViewModel GetById(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == id);

            if (book == null) return null;

            var bookView = new BookViewModel(
                book.Title,
                book.Description,
                book.Author,
                book.ISBN,
                book.Publisher,
                book.Category,
                book.PublicationYear,
                book.PageCount,
                book.CoverImage,
                book.AverageRating);

            return bookView;
        }

        public List<BookViewModel> GetByTitle(string title)
        {
            var books = _dbContext.Books
                .Where(book => book.Title == title)
                .ToList();

            var booksViewModel = books
                .Select(b => new BookViewModel(
                b.Title,
                b.Description,
                b.Author,
                b.ISBN,
                b.Publisher,
                b.Category,
                b.PublicationYear,
                b.PageCount,
                b.CoverImage,
                b.AverageRating)).ToList();

            return booksViewModel;
        }

        public void Update(UpdateBookInputModel model)
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == model.Id);

            book.Update(model.Title, model.Category);
        }

        #region Ratings
        
        public void CreateRating(CreateRatingInputModel model)
        {
            var rating = new Rating(
                model.Value,
                model.Description,
                model.IdUser,
                model.IdBook
            );

            _dbContext.Ratings.Add(rating);

            var book = _dbContext.Books.SingleOrDefault(book => book.Id == model.IdBook);

            List<Rating> ratings = _dbContext.Ratings.Where(r => r.IdBook == book.Id).ToList();

            book.RecalculateAverageRating(ratings);
        }

        public List<RatingViewModel> GetRatings(int bookId)
        {
            var ratings = _dbContext.Ratings.Where(r => r.IdBook == bookId)
                .Select(r =>
                    new RatingViewModel(
                        r.Value,
                        r.Description,
                        r.IdUser,
                        r.IdBook
                    )
                ).ToList();

            return ratings;
        }

        public List<RatingViewModel> GetRatingById(int bookId, int ratingId)
        {
            var ratings = _dbContext.Ratings.Where(r => r.IdBook == bookId && r.Id == ratingId)
                .Select(r =>
                    new RatingViewModel(
                        r.Value,
                        r.Description,
                        r.IdUser,
                        r.IdBook
                    )
                ).ToList();

            return ratings;
        }

        public void DeleteRating(int bookId, int ratingId)
        {
            var rating = _dbContext.Ratings.SingleOrDefault(r => r.Id == ratingId && r.IdBook == bookId);

            rating.Desativar();
        }

        #endregion
    }
}
