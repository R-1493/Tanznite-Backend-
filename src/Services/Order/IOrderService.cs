using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static src.DTO.OrderDTO;

namespace src.Services.Order
{
     public interface IOrderService
{
    Task<OrderReadDto> CreateOneAsync(Guid userId, OrderCreateDto createDto);
    Task<List<OrderReadDto>> GetAllAsync();
    Task<OrderReadDto> GetByIdAsync(Guid orderId);
    Task<bool> UpdateOnAsync(Guid orderId, OrderUpdateDto updateDto);
    Task<bool> DeleteOnAsync(Guid orderId);
        Task<ActionResult<IEnumerable<Entity.Order>>> GetAllOrders();
        Task<ActionResult<Entity.Order>> GetOrder(int id);
        Task<ActionResult<Entity.Order>> CreateOrder(Entity.Order order);
        Task<IActionResult> UpdateOrder(int id, Entity.Order order);
        Task<IActionResult> DeleteOrder(int id);
    }
}

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using static src.DTO.OrderDTO;


// namespace src.Services.Order
// {
//     public class IOrderService
//     {
//         Task<OrderReadDto> CreateOnAsync(OrderCreateDto createDto);//create new order
//         Task<List<OrderReadDto>> GetAllAsync(); //get all
//         Task<OrderReadDto> GetByIdAsync(Guid OrderId);//get by id
//         Task<bool> DeleteOneAsync(Guid OrderId);
//         Task<bool> UpdateOneAsync(Guid OrderId, OrderUpdateDto updateDto);
