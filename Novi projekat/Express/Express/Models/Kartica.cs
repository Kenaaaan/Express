using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    public class Kartica
    {
        [Key]
        public int Id { get; set; }

        public string BrojKartice { get; set; }

        [ForeignKey("Korisnik")]
        public int IdKorisnika { get; set; }

        // Parameterless constructor required by EF Core
        public Kartica() { }

        public Kartica(int id, string brojKartice, int idKorisnika)
        {
            Id = id;
            BrojKartice = brojKartice;
            IdKorisnika = idKorisnika;
        }
    }
}