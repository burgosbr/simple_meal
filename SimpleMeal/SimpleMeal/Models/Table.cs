using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleMeal.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        public string Number { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage ="Este campo deve conter de 5 a 50 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter de 5 a 50 caracteres")]
        public string Description { get; set; }

        public Boolean IsAvaliable { get; set; }
    }
}
