using System.ComponentModel.DataAnnotations;

namespace BuildTrackMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; } = null!;

        [StringLength(9)]
        public string NIF { get; set; } = null!;

        public string Morada { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string Telefone { get; set; } = null!;
    }
}
