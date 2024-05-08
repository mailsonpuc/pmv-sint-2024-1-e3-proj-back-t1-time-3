using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projeto.Models
{
    
        [Table("Professor")]
        public class Professor
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Cpf { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Senha { get; set; }
            [Required]
            public Materias Materias { get; set; }

        }

        public enum Materias
        {
            Matemática,
            Portugês,
            Inglês,
            Biologia,
            Química,
            Física,
            Filosofia,
            Espanhol,
            História,
            Geografia,
            Sociologia,

        }
    }

