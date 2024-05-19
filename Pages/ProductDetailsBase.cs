using Microsoft.AspNetCore.Components;
using OnlineShop.Models1.Dtos;
using Proiect1.Services;
using Proiect1.Services.Contracts;

namespace Proiect1.Pages
{
    public class ProductDetailsBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]

        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product=await ProductService.GetItem(Id);
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/ShoppingCart");

               
            }
            catch (Exception)
            {

                //Log Exception
            }
        }
    }
}
