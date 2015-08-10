using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace howyoulikeit.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
