using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    class CreatedMessageWithUserModel : CreatedMessageModel
    {
        public int UserId { get; set; }
    }
}
