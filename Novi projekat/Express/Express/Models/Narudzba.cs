using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    public class Narudzba
    {
        [Key]
        public int id { get; set; }
        public int cijena { get; set; }
        public string adresaDostave { get; set; }
        public DateTime datumNarudzbe { get; set; }

        [ForeignKey("Proizvod")]
        public int idProizvoda { get; set; }

        public Narudzba() { }

        public Narudzba(int Cijena, string AdresaDostave, DateTime DatumNarudzbe, int IdProizvoda)
        {
            cijena = Cijena;
            adresaDostave = AdresaDostave;
            datumNarudzbe = DatumNarudzbe;
            idProizvoda = IdProizvoda;
        }
    }
}