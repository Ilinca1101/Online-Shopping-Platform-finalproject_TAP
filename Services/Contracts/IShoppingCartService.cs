using OnlineShop.Models1.Dtos;

namespace Proiect1.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);

        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> UpdateQuantity(CartItemQuantUpdateDto cartItemQuantUpdateDto);

        event Action<int> OnShoppingCartChanged;
        void RaiseEventOnShoppingCartChanged(int totalQuantity);
    }
}
