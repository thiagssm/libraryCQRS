namespace Library.Application.DTOs.Book
{
    public class UpdateBookInputModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Publisher { get; set; }
        public string? Category { get; set; }
        public int? PublicationYear { get; set; }
        public int? PageCount { get; set; }
        // Adicionar os bytes criptografados quando for utilizar a CoverImage
        public string? CoverImage { get; set; }
        public bool? Ativo { get; set; }
    }
}
