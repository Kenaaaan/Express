using System;
using System.ComponentModel.DataAnnotations;

namespace Express.Models
{
    public class Proizvod
    {
        [Key]
        public int id { get; set; }

        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public double Cijena { get; set; }

        public Proizvod() { }
        public Proizvod(int Id, string proizvodjac, string model, double cijena)
        {
            id = Id;
            Proizvodjac = proizvodjac;
            Model = model;
            Cijena = cijena;
        }
    }
}