using System.ComponentModel.DataAnnotations;

namespace dwc.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        [Range(0, int.MaxValue)]
        public int StockDisponivel { get; set; }
    }
}
