﻿using Microsoft.AspNetCore.Components;
using OnlineShop.Models1.Dtos;
using Proiect1.Services.Contracts;

namespace Proiect1.Pages
{
    public class ShoppingCartBase: ComponentBase
    {
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }   
        public List<CartItemDto> ShoppingCartItems { get; set; }

        public string ErrorMessage {  get; set; }

        protected string TotalPrice { get; set; }
        protected int TotalQuantity { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems=await ShoppingCartService.GetItems(FakeLogin.UserId);
                CartChanged();
            }

            catch(Exception ex)
            {
                ErrorMessage=ex.Message;
            }
        }

        protected async Task DeleteCartItem_Click(int id)
        {
            var cartItemDto=await ShoppingCartService.DeleteItem(id);

            RemoveCartItem(id);
            CartChanged();

        }

        protected async Task UpdateQuantCartItem_Click(int id, int quant)
        {
            try
            {
                if(quant>0)
                {
                    var updateItemDto = new CartItemQuantUpdateDto
                    {
                        CartItemId = id,
                        Quantity = quant
                    };

                    var returnedUpdateItemDto=await this.ShoppingCartService.UpdateQuantity(updateItemDto);

                    UpdateItemTotalPrice(returnedUpdateItemDto);

                    CartChanged();
                }

                else
                {
                    var item=this.ShoppingCartItems.FirstOrDefault(i=>i.Id==id);
                    if(item !=null)
                    {
                        item.Quantity = 1;
                        item.TotalPrice = item.Price;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateItemTotalPrice(CartItemDto cartItemDto)
        {
            var item = GetCartItem(cartItemDto.Id);

            if(item != null) 
            { 
                item.TotalPrice=cartItemDto.Price*cartItemDto.Quantity;
            }
        }

        private void CalcFinalPrice()
        {
            CalcTotalPrice();
            CalcTotalQuantity();
        }

        private void CalcTotalPrice()
        {
            TotalPrice=this.ShoppingCartItems.Sum(p=>p.TotalPrice).ToString("C");
        }

        private void CalcTotalQuantity()
        {
            TotalQuantity=this.ShoppingCartItems.Sum(p=>p.Quantity);
        }
        private CartItemDto GetCartItem(int id)
        {
            return ShoppingCartItems.FirstOrDefault(i => i.Id == id);
        }

        private void RemoveCartItem(int id)
        {
            var cartItemDto=GetCartItem(id);
            ShoppingCartItems.Remove(cartItemDto);
        }

        private void CartChanged()
        {
            CalcFinalPrice();
            ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQuantity);
        }
    }
}
