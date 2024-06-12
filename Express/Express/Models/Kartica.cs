using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    public class Kartica
    {
        [Key] public int Id { get; set; }

        public string BrojKartice { get; set; }

        [ForeignKey("Korisnik")] public string IdKorisnika { get; set; }

        public Korisnik korisnik { get; set; }
        public Kartica() { }

    }
}