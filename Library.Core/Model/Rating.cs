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
        }

        public int Value { get; private set; }
        public string Description { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }        

    }
}
