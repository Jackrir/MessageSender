using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.API.Requests
{
    public class EditMessageRequest
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
