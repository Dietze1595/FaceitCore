using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFaceitAPI.Models
{
    public class SubscribeModel
    {
        [Required(ErrorMessage = "Please enter your Steam 64 ID.")]
        public string SteamId { get; set; }
    }
}
