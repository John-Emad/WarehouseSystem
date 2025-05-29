using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementSystem.Domain.Models
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string? Landline { get; set; }

        [StringLength(20)]
        public string? Fax { get; set; }

        [StringLength(20)]
        public string? Mobile { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Url]
        [StringLength(300)]
        public string? Website { get; set; }

    }
}
