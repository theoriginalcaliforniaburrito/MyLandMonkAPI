using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   [Table("properties")]
   public class Properties : IEntity
   {
       [Key]
       [Column("PropertyId")]
       public Guid PropertyId { get; set; }

       [Required(ErrorMessage = "Date created is required")]
       public DateTime DateCreated { get; set; }

       [Required(ErrorMessage = "Account type is required")]
       public string AccountType { get; set; }

       [Required(ErrorMessage = "Owner Id is required")]
       public Guid OwnerId { get; set; }
   }
}