using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OnlineShop.Models1.Dtos;
using Proiect1.Services.Contracts;

namespace Proiect1.Pages
{
    public class CheckoutBase: ComponentBase
    {
        [Inject]
        public IJSRuntime Js {  get; set; }

        protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
        protected int TotalQuantity { get; set; }
        protected string PaymentDescription { get; set; }
        protected decimal PaymentAmount { get; set; }
        public string ErrorMessage { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems=await ShoppingCartService.GetItems(FakeLogin.UserId);
                if(ShoppingCartItems != null) 
                { 
                  Guid orderGuid=Guid.NewGuid();

                    PaymentAmount=ShoppingCartItems.Sum(p=>p.TotalPrice); 
                    TotalQuantity=ShoppingCartItems.Sum(p=>p.Quantity);
                    PaymentDescription = $"O_{FakeLogin.UserId}_{orderGuid}";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if(firstRender) 
                {
                    await Js.InvokeVoidAsync("initPayPalButton");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
