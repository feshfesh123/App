using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Game.Entities
{
    public class Joiner
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
