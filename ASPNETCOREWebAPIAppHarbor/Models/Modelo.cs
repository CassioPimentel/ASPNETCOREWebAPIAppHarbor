using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREWebAPIAppHarbor.Models
{
    public class Modelo
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int MarcaCodigo { get; set; }

        [JsonIgnore]
        public virtual Marca Marca { get; set; }
    }
}
