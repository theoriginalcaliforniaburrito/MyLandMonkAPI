using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("properties")]
    public class Property : IEntity
    {
        [Key]
        [Column("PropertyId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Property name is required")]
        [StringLength(100, ErrorMessage = "Property name can't be longer than 100 characters")]
        public string PropertyName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address can't be longer than 100 characters")]
        public string Address { get; set; }

          [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

          [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

          [Required(ErrorMessage = "Zip code is required")]
        public string ZipCode { get; set; }
    }
}