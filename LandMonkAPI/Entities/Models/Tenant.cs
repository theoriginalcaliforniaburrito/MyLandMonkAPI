using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   [Table("tenants")]
   public class Tenant : IEntity
   {
       [Key]
       [Column("TenantId")]
       public int Id { get; set; }

       [Required(ErrorMessage = "First name is required")]
       public string FirstName { get; set; }

       [Required(ErrorMessage = "Last name is required")]
       public string LastName { get; set; }

       [Required(ErrorMessage = "Email is required")]
       public string Email { get; set; }

       [Required(ErrorMessage = "CellPhone is required")]
       public string CellPhone { get; set; }
   }
}