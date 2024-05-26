
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    public class Korisnik : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePicture { get; set; }

        // Additional properties
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("Korpa")]
        public int Korpa { get; set; } 

        public Korisnik() { }

        public Korisnik(string username, string email, string password, string firstName, string lastName, int korpa)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Korpa = korpa;
        }
    }
}
