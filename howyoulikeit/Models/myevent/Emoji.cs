using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace howyoulikeit.Models.myevent
{
    public class Emoji
    {
        [Key]
        public int EmojiId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image Path is required")]
        public string ImagePath { get; set; }
        public virtual List<MyEvent> Events { get; set; }
    }
}
