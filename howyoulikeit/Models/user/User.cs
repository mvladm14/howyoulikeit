using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using howyoulikeit.Models.myevent;

namespace howyoulikeit.Models.user
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public virtual List<MyEvent> Events { get; set; }

    }
}