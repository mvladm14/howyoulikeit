using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace howyoulikeit.Models.myevent
{
    public class MyEvent
    {
        [Key]
        public int MyEventId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<Emoji> Emojis { get; set; }
    }
}
