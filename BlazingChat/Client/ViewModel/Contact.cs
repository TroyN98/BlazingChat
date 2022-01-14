using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels
{
    public class Contact
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Contact()
        {

        }

        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Contact(int userId, string firstName, string lastName)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        

        //operators
        public static implicit operator Contact(User user)
        {
            return new Contact
            {
                UserId = (int)user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
        public static implicit operator User(Contact contact)
        {
            return new User
            {
                UserId = contact.UserId,
                FirstName = contact.FirstName,
                LastName = contact.LastName
            };
        }
    }
}
