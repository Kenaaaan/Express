
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    public class Zaposlenik : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePicture { get; set; }

        // Additional properties
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Korpa Korpa { get; set; }

        [ForeignKey("Proizvod")]
        public int IdProizvoda { get; set; }

        public Zaposlenik() { }

        public Zaposlenik(string username, string email, string password, string firstName, string lastName, Korpa korpa, int idProizvoda)
        {
            Username = username;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Korpa = korpa;
            IdProizvoda = idProizvoda;
        }
    }
}
