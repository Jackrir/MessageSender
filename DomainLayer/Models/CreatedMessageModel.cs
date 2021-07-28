using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class CreatedMessageModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
