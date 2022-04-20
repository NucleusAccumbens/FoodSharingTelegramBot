using FoodSharing.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer.Entity
{
    public class User : ABaseEntity
    {
        public long UserId { get; set; }
        public long ChatId { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public Cities City { get; set; }
        public string? PhoneNumber { get; set; }
        public Languages? Language { get; set; }
        public bool Notify { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; } = true;
        public int ComandState { get; set; } = 0;

        public List<Food>? Foods { get; set; }
    }
}
