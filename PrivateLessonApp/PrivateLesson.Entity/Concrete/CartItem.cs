using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
