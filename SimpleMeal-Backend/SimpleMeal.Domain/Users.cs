using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMeal.Domain
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role AccessType { get; set; }
    }
}
