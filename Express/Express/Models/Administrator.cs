
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    //Testnasifra123#
    public class Administrator : Person 
    {
        [Key] public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePicture { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }


        public Administrator() { }

       
    }
}
