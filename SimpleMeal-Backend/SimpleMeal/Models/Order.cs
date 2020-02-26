using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMeal.Models
{
  public class Order
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    /*public Table Table { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int TableId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string ClientName { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string ClientCpf { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Status { get; set; }*/
    public IList<Product> Products { get; set; }
  }
}