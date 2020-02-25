using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMeal.Models
{
  public class Order
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int Number { get; set; }

    [Required(ErrorMessage = "Para fazer um pedido é necessário haver pelo menos um produto")]
    public IList<Product> Products { get; set; }
  }
}