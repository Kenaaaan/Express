using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    public class Korisnik : IdentityUser, Person, User
    {
        [Key] override public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePicture { get; set; }
        public Korpa? Korpa { get; set; } = null!;
        public ICollection<Kartica>? MogucnostiPlacanja { get; set; } = new List<Kartica>();

        public Korisnik() { }
    }
}
