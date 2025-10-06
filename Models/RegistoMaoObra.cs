using System;

namespace BuildTrackMVC.Models
{
    public class RegistoMaoObra
    {
        public int Id { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; } = null!;

        public string NomePessoa { get; set; } = null!;
        public double HorasTrabalhadas { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
