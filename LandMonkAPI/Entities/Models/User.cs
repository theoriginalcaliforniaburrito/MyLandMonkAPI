using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   [Table("users")]
   public class User : IEntity
   {
       [Key]
       [Column("UserId")]
       public int Id { get; set; }

       [Required(ErrorMessage = "First name is required")]
       public string FirstName { get; set; }

       [Required(ErrorMessage = "Last name is required")]
       public string LastName { get; set; }

       [Required(ErrorMessage = "Email is required")]
       public string Email { get; set; }

       [Required(ErrorMessage = "Username is required")]
       public string Username { get; set; }

       [Required(ErrorMessage = "Password is required")]
       public string Password { get; set; }
   }
}