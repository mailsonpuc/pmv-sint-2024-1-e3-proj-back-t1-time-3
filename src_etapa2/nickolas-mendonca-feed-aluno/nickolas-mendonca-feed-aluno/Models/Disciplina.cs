using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nickolas_mendonca_feed_aluno.Models
{
    [Table("Disciplinas")]
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o nome da disciplina.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatorio adicionar uma pequena descrição da disciplina.")]
        [StringLength(500)]
        public string Resumo { get; set; }

        public ICollection<ProfessorDisciplina> Disciplinas { get; set; }
    }
}
