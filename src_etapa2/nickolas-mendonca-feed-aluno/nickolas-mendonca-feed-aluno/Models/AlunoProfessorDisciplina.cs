using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nickolas_mendonca_feed_aluno.Models
{
    [Table("AlunoProfessoresDisciplinas")]
    public class AlunoProfessorDisciplina
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Codigo do aluno")]
        [Required(ErrorMessage = "Codigo do aluno deve ser informado.")]
        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public Usuario Aluno { get; set; }

        [Display(Name = "Codigo da disciplina")]
        [Required(ErrorMessage = "Codigo deve ser informado.")]
        public int PorfDiscId { get; set; }

        [ForeignKey("PorfDiscId")]
        [Required]
        public ProfessorDisciplina ProfessorDisciplina { get; set; }
    }
}
