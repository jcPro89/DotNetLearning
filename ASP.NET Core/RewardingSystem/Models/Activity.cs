using System.ComponentModel.DataAnnotations;

namespace RewardingApp.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public int Points { get; set; }

        public List<Award> Awards { get; set; }
    }
}
