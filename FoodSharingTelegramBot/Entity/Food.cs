using FoodSharing.DataAccessLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer.Entity
{
    public class Food : ABaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodCategory Category { get; set; }
        public DateTime? ShelfLife { get; set; }
        public bool InStoke { get; set; }
        public long ChatId { get; set; }
    }
}
