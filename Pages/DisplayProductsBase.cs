using Microsoft.AspNetCore.Components;
using OnlineShop.Models1.Dtos;

namespace Proiect1.Pages
{
    public class DisplayProductsBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
