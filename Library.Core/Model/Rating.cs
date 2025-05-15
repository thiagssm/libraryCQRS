namespace Library.Core.Model
{
    public class Rating:BaseModel
    {
        public Rating(int value, string description, int idUser, int idBook)
        {
            Value = value;
            Description = description;
            IdUser = idUser;
            IdBook = idBook;
            Ativo = true;
            CreationDate = DateTime.Now;
        }

        public int Value { get; private set; }
        public string Description { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }        
        public Book Book { get; private set; }        

    }
}
