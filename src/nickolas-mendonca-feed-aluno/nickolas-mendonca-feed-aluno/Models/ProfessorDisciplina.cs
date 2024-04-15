using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nickolas_mendonca_feed_aluno.Models
{
    [Table("ProfessorDisciplinas")]
    public class ProfessorDisciplina
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Codigo do professor")]
        [Required(ErrorMessage = "Codigo do professor deve ser informado.")]
        public int ProfessorId { get; set; }

        [ForeignKey("ProfessorId")]
        public Usuario Professor { get; set; }

        [Display(Name = "Codigo da disciplina")]
        [Required(ErrorMessage = "Codigo da disciplina deve ser informado.")]
        public int DisciplinaId { get; set; }

        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }

        [Display(Name = "Valor da aula")]
        [Required(ErrorMessage = "Valor da hora/aula deve ser informado.")]
        public decimal ValorAula { get; set; }

        [StringLength(200)]
        public string Resumo { get; set; }

        public ICollection<AlunoProfessorDisciplina> ProfessoresDisciplinas { get; set; }

    }
}
