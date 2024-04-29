using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projeto.Models
{
    [Table("MarcarAula")]
    public class MarcarAula
    {
        [Key]
        public int Id { get; set; }

        public int ProfessorId { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor Professor { get; set; }

        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        public string Conteudo { get; set; }

        public bool Confirmacao { get; set; }
    }
}
