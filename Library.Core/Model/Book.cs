using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace Library.Core.Model
{
    public class Book : BaseModel
    {
        public Book(string title, string description, string author, string iSBN, string publisher, string category, int publicationYear, int pageCount, string coverImage)
        {
            Title = title;
            Description = description;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            Category = category;
            PublicationYear = publicationYear;
            PageCount = pageCount;
            CoverImage = coverImage;
            AverageRating = 0;
            Ratings = new List<Rating>();
            Ativo = true;
            CreationDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public string Category { get; private set; }
        public int PublicationYear { get; private set; }
        public int PageCount { get; private set; }
        // Adicionar os bytes criptografados quando for utilizar a CoverImage
        public string CoverImage { get; private set; }
        public decimal AverageRating { get; private set; }
        public List<Rating> Ratings { get; private set; }

        public void Update(string? title, string? description, string? author, string? isbn, string? publisher, string? category, int? publicationYear, int? pageCount, bool? ativo)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Title = title;
            }
            if (!string.IsNullOrEmpty(description))
            {
                Description = description;
            }
            if (!string.IsNullOrEmpty(author))
            {
                Author = author;
            }
            if (!string.IsNullOrEmpty(isbn))
            {
                ISBN = isbn;
            }
            if (!string.IsNullOrEmpty(publisher))
            {
                Publisher = publisher;
            }

            if (!string.IsNullOrEmpty(category))
            {
                Category = category;
            }

            if (publicationYear.HasValue)
            {
                PublicationYear = publicationYear.Value;
            }

            if (pageCount.HasValue)
            {
                PageCount = pageCount.Value;
            }

            if (ativo.HasValue)
            {
                Ativo = ativo.Value;
            }

        }

        public void PopulateRatings(List<Rating> ratings)
        {
            Ratings = ratings;
        }

        public void RecalculateAverageRating(List<Rating> ratings)
        {
            PopulateRatings(ratings);

            var dividedNumber = 1;
            if(ratings.Count > 0)
            {
                dividedNumber = ratings.Count;
            }

            AverageRating = ratings.Select(r => r.Value).Sum()/dividedNumber;
        }
    }
}
