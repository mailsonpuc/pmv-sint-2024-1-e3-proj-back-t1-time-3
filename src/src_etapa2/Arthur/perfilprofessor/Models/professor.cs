using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perfilprofessor.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome de usuário!")]
        [Display(Name = "Nome de Usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o E-mail!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        public string Senha { get; set; }

    }
}
