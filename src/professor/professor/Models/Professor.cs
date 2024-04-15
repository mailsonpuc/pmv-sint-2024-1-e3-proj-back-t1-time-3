
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace professor.Models
{
    [Table("Professor")]
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cpf {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        


    }
}
