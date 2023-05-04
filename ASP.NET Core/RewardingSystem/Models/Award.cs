using System.ComponentModel.DataAnnotations;

namespace RewardingApp.Models
{
    public class Award
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
