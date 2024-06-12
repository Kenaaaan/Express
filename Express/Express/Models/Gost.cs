using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Models
{
    [NotMapped]
    public class Gost : User
    {
        public Korpa Korpa { get; set; }

        public Gost()
        {
            Korpa = new Korpa();
        }
    }
}
