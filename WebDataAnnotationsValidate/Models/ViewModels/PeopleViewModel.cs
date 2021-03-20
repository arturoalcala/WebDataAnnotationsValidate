using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDataAnnotationsValidate.Models.ViewModels
{
    public class PeopleViewModel
    {
        [Display(Name="Usuario")]
        [Required]
        [UsernameExists(ErrorMessage ="El usuario es incorrecto")]
        public string Username { get; set; }

        [Display(Name="Contraseña")]
        [Required]
        [DataType(DataType.Password)]
        [PasswordExists(ErrorMessage ="La contraseña es incorrecta")]
        public string Password { get; set; }

        [Display(Name="Nombre")]
        [Required]
        [StringLength(maximumLength:20, ErrorMessage ="No debe sobrepasar 20 caracteres")]
        [NameExists(ErrorMessage ="El nombre capturado ya existe en la base de datos")]
        public string Name { get; set; }

        [Display(Name="Correo electrónico")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name="Edad")]
        [Required]
        [Range(18, 55, ErrorMessage = "La edad debes estar en el rango de 18 y 55 años")]
        public int Age { get; set; }

        [Display(Name="Código")]
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="Solo se permiten letras")]
        public string Code { get; set; }
    }

    public class NameExistsAttribute : ValidationAttribute
    {
        List<string> dbNames = new List<string>
        {
            "Arturo",
            "José"
        };

        public override bool IsValid(object value)
        {
            return !dbNames.Contains(value);
        }
    }

    public class UsernameExists : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var configJSON = new ConfigurationBuilder().AddUserSecrets("866bd201-03e5-42fb-b028-8e7bceae5ad6").Build();
            var username = configJSON["Username"];
            return username == Convert.ToString(value);
        }
    }
    public class PasswordExists : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var configJSON = new ConfigurationBuilder().AddUserSecrets("866bd201-03e5-42fb-b028-8e7bceae5ad6").Build();
            var password = configJSON["Password"];
            return password == Convert.ToString(value);
        }
    }
}