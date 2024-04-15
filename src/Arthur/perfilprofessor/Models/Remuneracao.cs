using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perfilprofessor.Models
{
    [Table("Consumos")]
    public class Remuneracao
    {
        [Key]
        public int Id {  get; set; }

        [Required(ErrorMessage = "Obrigatório informar o valor")]
        public decimal Valor { get; set; }
    }
}
