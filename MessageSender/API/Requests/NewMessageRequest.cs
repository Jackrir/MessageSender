using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.API.Requests
{
    public class NewMessageRequest
    {
        [Required]
        public string Text { get; set; }
    }
}
