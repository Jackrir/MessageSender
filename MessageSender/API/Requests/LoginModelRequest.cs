using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.API.Requests
{
    public class LoginModelRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
