
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    public class Korpa
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Korisnik")]
        public int idKorisnika { get; set; }

        public string brojKartice { get; set; }

        public Korpa() { }
        public Korpa(int Id, int IdKorisnika, string BrojKartice)
        {
            id = Id;
            idKorisnika = IdKorisnika;
            brojKartice = BrojKartice;
        }
    }
}
