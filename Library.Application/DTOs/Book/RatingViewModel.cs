using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.Book
{
    public class RatingViewModel
    {
        public RatingViewModel(int value, string description, int idUser, int idBook)
        {
            Value = value;
            Description = description;
            IdUser = idUser;
            IdBook = idBook;
        }

        public int Value { get; private set; }
        public string Description { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
    }
}
