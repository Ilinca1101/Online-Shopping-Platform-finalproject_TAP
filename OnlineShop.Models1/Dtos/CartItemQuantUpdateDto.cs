using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models1.Dtos
{
    public class CartItemQuantUpdateDto
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
