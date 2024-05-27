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
            [RegularExpression(@"^[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}$", 
             ErrorMessage = "cpf invalido digite no padrão com ponto Ex: 205.729.940-60")]
            public string Cpf { get; set; }
            [Required]
            public string Name { get; set; }

            [Required]
            [RegularExpression(@"^([a-z0-9]+[_a-z0-9\.-]*[a-z0-9]+)@([a-z0-9-]+(?:\.[a-z0-9-]+)*\.[a-z]{2,4})$", 
             ErrorMessage = "E-mail invalido, digite um e-mail valido  Ex: fulano@email.com")]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Senha { get; set; }
            [Required]
            public Materias Materias { get; set; }

        }

        public enum Materias
        {
            Matemática,
            Português,
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

