using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dwc.Models
{
    public class Obra
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; } = null!;

        public string Morada { get; set; } = null!;

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public bool Ativa { get; set; }
    }
}
