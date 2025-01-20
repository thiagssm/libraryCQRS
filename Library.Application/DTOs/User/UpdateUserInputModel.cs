using System.ComponentModel;

namespace Library.Application.DTOs.User
{
    public class UpdateUserInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
