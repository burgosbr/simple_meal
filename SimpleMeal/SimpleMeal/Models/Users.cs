using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMeal.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo deve ser obrigadório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter de 4 a 50 caracteres")]
        [MinLength(4, ErrorMessage = "Este campo deve conter de 4 a 50 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Este campo é obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter de 4 a 15 caracteres")]
        [MinLength(4, ErrorMessage = "Este campo deve conter de 4 a 15 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(12, ErrorMessage = "Este campo deve conter de 4 a 12 caracteres")]
        [MinLength(4, ErrorMessage = "Este campo deve conter de 4 a 12 caracteres")]
        public string  Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Role Type { get; set; }
    }
}
