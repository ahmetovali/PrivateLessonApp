using PrivateLesson.Business.Abstract;
using PrivateLesson.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        ICartItemRepository _cartItemRepository;

        public CartItemManager(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
    
    }
}
