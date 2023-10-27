#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace SessionWorkshop.Models;

public class User
{
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [MinLength(4, ErrorMessage = "El nombre debe contener minimo 4 caracteres")]
    public string Name { get; set; }
}