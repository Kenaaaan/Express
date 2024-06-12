using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Express.Models
{
    public class Korpa
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdKorisnika { get; set; }
        public IdentityUser Korisnik { get; set; }

        public ICollection<Proizvod> Products { get; set; } = new List<Proizvod>();

        public double UkupnaCijena { get; set; } = 0;

        [Required]
        public string BrojKartice { get; set; } = "0000-0000-0000-0000"; // Default value

        public void DodajProizvod(Proizvod newProduct)
        {
            if (!Products.Contains(newProduct))
            {
                Products.Add(newProduct);
                UkupnaCijena += newProduct.Cijena;
            }
        }

        public void ObrisiProizvod(Proizvod newProduct)
        {
            if (Products.Contains(newProduct))
            {
                Products.Remove(newProduct);
                UkupnaCijena -= newProduct.Cijena;
            }
        }

        public Korpa() { }
    }
}
