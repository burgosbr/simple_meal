using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleMeal.Models {
  public class Product {
    [Key]
    public int Id { get; set; }

    [Required (ErrorMessage = "Este campo é obrigatório")]
    [MaxLength (20, ErrorMessage = "Este campo deve conter entre 3 e 20 Caracteres!")]
    [MinLength (3, ErrorMessage = "Este campo deve conter entre 3 e 20 Caracteres!")]
    public string Name { get; set; }

    [MaxLength (120, ErrorMessage = "Este campo deve conter entre 5 e 120 Caracteres!")]
    [MinLength (5, ErrorMessage = "Este campo deve conter entre 5 e 120 Caracteres!")]
    public string Description { get; set; }

    [Required (ErrorMessage = "Este campo é obrigatório")]
    [Range (1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public double Price { get; set; }

    [Required (ErrorMessage = "Este campo é obrigatório")]
    [Range (1, int.MaxValue, ErrorMessage = "O tempo deve ser maior que zero")]
    public int TempoPreparo { get; set; }

    public string URLImagem { get; set; }

    public Boolean IsAvaliable { get; set; }
  }
}