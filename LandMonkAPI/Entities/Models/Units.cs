using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   [Table("units")]
   public class Units : IEntity
   {
       [Key]
       [Column("UnitId")]
       public int Id { get; set; }

       [Required(ErrorMessage = "Unit name is required")]
       public string UnitName { get; set; }

       [Required(ErrorMessage = "Bedroom count type is required")]
       public int BedroomCount { get; set; }

       [Required(ErrorMessage = "Bathroom count is required")]
       public float BathroomCount { get; set; }

       [Required(ErrorMessage = "Square footage is required")]
       public int SquareFootage { get; set; }

       [Required(ErrorMessage = "Property Id is required")]
       public int PropertyId { get; set; }
   }
}