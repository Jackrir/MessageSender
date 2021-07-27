using DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public List<Message> Messages { get; set; }
    }
}
