namespace Library.Application.DTOs.Book
{
    public class CreateRatingInputModel
    {
        public int Value { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
    }
}
