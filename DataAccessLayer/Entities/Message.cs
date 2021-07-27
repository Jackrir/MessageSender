using DataAccessLayer.Entities.Base;
using System;

namespace DataAccessLayer.Entities
{
    public class Message : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }
    }
}
