using System.ComponentModel.DataAnnotations;

namespace DropDownListAsp.Models
{
    public class Country
    {
        [Key]
        [MaxLength(3)]
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
