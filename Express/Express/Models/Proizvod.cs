using System;
using System.ComponentModel.DataAnnotations;

namespace Express.Models
{
    public class Proizvod
    {
        [Key] public int id { get; set; }

        public string Proizvodjac { get; set; }
        public string Model { get; set; }   
        public double Cijena { get; set; } = 0;
        //[Display(Name = "In stock")]

        public string Slika { get; set; }
        public string Opis { get; set; }
        public int Kilometraza { get; set; }
        public Proizvod() { }
        public Proizvod(int Id, string proizvodjac, string model, double cijena, string slika, int kilometraza)
        {
            id = Id;
            Kilometraza = kilometraza;
            Slika = slika;
            Proizvodjac = proizvodjac;
            Model = model;
            Cijena = cijena;
        }
    }
}