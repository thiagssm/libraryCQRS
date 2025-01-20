using Library.Application.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Interfaces
{
    public interface IBookService
    {
        BookViewModel GetById(int id);
        List<BookViewModel> GetByTitle(string title);
        List<BookViewModel> GetAll();
        int Create(CreateBookInputModel model);
        void Update(UpdateBookInputModel model);
        void Delete(int id);
        void CreateRating(CreateRatingInputModel model);
        List<RatingViewModel> GetRatings(int bookId);
        List<RatingViewModel> GetRatingById(int bookId, int ratingId);
        void DeleteRating(int bookId, int ratingId);
    }
}
