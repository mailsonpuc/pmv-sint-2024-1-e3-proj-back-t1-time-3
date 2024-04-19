using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Obrigatório informar um usuário ou email.")]
    [Display(Name = "Usuário ou email")]
    public required string UsernameOrEmail { get; set; }

    [Required(ErrorMessage = "Obrigatório informar uma senha.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}