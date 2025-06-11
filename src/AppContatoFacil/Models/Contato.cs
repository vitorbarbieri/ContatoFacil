using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppContatoFacil.Models
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo {0} deve ser um e-mail válido.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo 100 caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "O campo {0} deve ser um celular válido. Use (XX) XXXXX-XXXX.")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no máximo 15 caracteres.")]
        public string? Celular { get; set; }
    }
}