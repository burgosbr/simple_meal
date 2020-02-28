using System.ComponentModel.DataAnnotations;

namespace SimpleMeal.Domain
{
    public enum Role
    {
        Admin = 0,
        Cook = 1,
        Attendante = 2,
        Client = 3
    }
}