using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Entity.Concrete
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public decimal? Price { get; set; }
        public int Amount { get; set; }
    }
}
