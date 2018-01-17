using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREWebAPIAppHarbor.Models
{
    public class Marca
    {
        public Marca()
        {
            Modelo = new List<Modelo>();
        }

        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}
