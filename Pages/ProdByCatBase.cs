using Microsoft.AspNetCore.Components;
using OnlineShop.Models1.Dtos;
using Proiect1.Services.Contracts;

namespace Proiect1.Pages
{
    public class ProdByCatBase: ComponentBase
    {
        [Parameter]
        public int CategoryId { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
        public string CategoryName { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Products=await ProductService.GetItemsByCategory(CategoryId);
                if(Products !=null && Products.Count()>0)
                {
                    var productDto=Products.FirstOrDefault(p=>p.CategoryId==CategoryId);
                    if (productDto !=null) 
                    { 
                      CategoryName=productDto.CategoryName;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage= ex.Message;
            }
        }
    }
}
