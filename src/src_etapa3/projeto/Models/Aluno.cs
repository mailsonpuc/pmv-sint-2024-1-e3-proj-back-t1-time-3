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
        [Display(Name = "Nome Completo" )] 
        public string Name { get; set; }
        

        [Required(ErrorMessage = ("Obrigatório!"))]
        [Display(Name = "Endereço de E-mail" )]
        public string Email { get; set; }

        
        [Required(ErrorMessage = ("Obrigatório!"))]
        public string Senha { get; set; }

    }
}
