using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projeto.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Obrigatório!"))]
        public string Name { get; set; }
        [Required(ErrorMessage = ("Obrigatório!"))]
        public string Email { get; set; }
        [Required(ErrorMessage = ("Obrigatório!"))]
        public string Senha { get; set; }

        public ICollection<MarcarAula> MarcarAulas { get; set; }
    }
}
