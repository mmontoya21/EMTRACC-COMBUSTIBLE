using System.ComponentModel.DataAnnotations;

namespace EmtraccWeb.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Ingrese el usuario")]
    [Display(Name = "Usuario")]
    public string Usuario { get; set; } = "";

    [Required(ErrorMessage = "Ingrese la contraseña")]
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    public string Clave { get; set; } = "";
}
