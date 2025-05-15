using Library.Application.DTOs.Book;
using Library.Application.Services.Interfaces;
using Library.Core.Model;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
            _dbContext.SaveChanges();

            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault( book => book.Id == id );

            book.Desativar();
            _dbContext.SaveChanges();
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
                    b.AverageRating,
                    b.Ratings
                    ))
                .ToList();

            return booksViewModel;
        }

        public BookViewModel GetById(int id)
        {
            var book = _dbContext.Books
                .Include(b => b.Ratings)
                .SingleOrDefault(book => book.Id == id);

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
                book.AverageRating,
                book.Ratings);

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
                b.AverageRating,
                b.Ratings)).ToList();

            return booksViewModel;
        }

        public void Update(UpdateBookInputModel model)
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == model.Id);

            book.Update(model.Title, model.Description, model.Author, model.ISBN, model.Publisher, model.Category, model.PublicationYear, model.PageCount, model.Ativo);
            _dbContext.SaveChanges();
        }

        #region Ratings
        
        public void CreateRating(CreateRatingInputModel model)
        {
            var userExists = _dbContext.Users.Any(u => u.Id == model.IdUser);
            if (!userExists)
            {
                throw new Exception("O usuário informado não foi encontrado.");
            }

            var rating = new Rating(
                model.Value,
                model.Description,
                model.IdUser,
                model.IdBook
            );

            _dbContext.Ratings.Add(rating);

            var book = _dbContext.Books.SingleOrDefault(book => book.Id == model.IdBook);

            List<Rating> ratings = _dbContext.Ratings.Where(r => r.IdBook == book.Id).ToList();

            ratings.Add(rating);

            book.RecalculateAverageRating(ratings);
            _dbContext.SaveChanges();
        }

        public List<RatingViewModel> GetRatings(int bookId)
        {
            var ratings = _dbContext.Ratings
                .Where(r => r.IdBook == bookId)
                .Include(r => r.User)
                .Select(r =>
                    new RatingViewModel(
                        r.Value,
                        r.Description,
                        r.IdUser,
                        r.IdBook,
                        r.User.Name
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
                        r.IdBook,
                        r.User.Name
                    )
                ).ToList();

            return ratings;
        }

        public void DeleteRating(int bookId, int ratingId)
        {
            var rating = _dbContext.Ratings.SingleOrDefault(r => r.Id == ratingId && r.IdBook == bookId);

            rating.Desativar();
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
