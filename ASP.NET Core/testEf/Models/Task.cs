using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testEf.Models
{

    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaskId { get; set; }

        [ForeignKey("CategoriaId")]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority TaskPriority { get; set; }
        public DateTime CreationDate { get; set; }                
        public virtual Category? Category { get; set; } // Will enable retrieving the associated category to get the remaining attributes if needed

        [NotMapped] // Won't create the item in the database
        public string Resumen { get; set; } 
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}