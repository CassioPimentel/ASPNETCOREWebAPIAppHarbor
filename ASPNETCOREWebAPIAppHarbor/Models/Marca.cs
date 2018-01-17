using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREWebAPIAppHarbor.Models
{
    public class Marca
    {
        public Marca()
        {
            ModeloCarro = new List<ModeloCarro>();
        }

        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ModeloCarro> ModeloCarro { get; set; }
    }
}
