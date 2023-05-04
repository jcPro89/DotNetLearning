using System.ComponentModel.DataAnnotations;

namespace ActivityAwardsApp.Models
{
    public class Award
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
