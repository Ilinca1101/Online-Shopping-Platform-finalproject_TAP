using Microsoft.AspNetCore.Components;
using OnlineShop.Models1.Dtos;
using Proiect1.Services.Contracts;

namespace Proiect1.Pages
{
    public class ProductsBase: ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {

                Products = await ProductService.GetItems();

                var shoppingCartItems = await ShoppingCartService.GetItems(FakeLogin.UserId);
                var totalQuantity=shoppingCartItems.Sum(i=>i.Quantity);

                ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQuantity);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            return from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }

        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDtos) 
        {
            return groupedProductDtos.FirstOrDefault(pg => pg.CategoryId == groupedProductDtos.Key).CategoryName;
        }
    }
}
