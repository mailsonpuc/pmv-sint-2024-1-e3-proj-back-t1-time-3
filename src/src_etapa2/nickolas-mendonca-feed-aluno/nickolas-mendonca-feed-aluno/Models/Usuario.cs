using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nickolas_mendonca_feed_aluno.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o nome do aluno.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o e-mail.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar senha do usuário.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o tipo do perfil.")]
        [Display(Name="Tipo de usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        public ICollection<ProfessorDisciplina> Disciplinas { get; set; }
        public ICollection<AlunoProfessorDisciplina> ProfessoresDisciplinas { get; set; }
    }

    public enum TipoUsuario
    {
        Aluno,
        Professor,
        Admin
    }
}
