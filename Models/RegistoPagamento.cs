using System;

namespace dwc.Models
{
    public class RegistoPagamento
    {
        public int Id { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; } = null!;

        public string NomePessoa { get; set; } = null!;
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
