using Microsoft.AspNetCore.Components;
using OnlineShop.Models1.Dtos;
using Proiect1.Services.Contracts;

namespace Proiect1.Layout
{
    public class ProdCatNavMenuBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductCategoryDto> ProductCategoryDtos { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ProductCategoryDtos = await ProductService.GetProductCategories();
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }

        }
    }
}
