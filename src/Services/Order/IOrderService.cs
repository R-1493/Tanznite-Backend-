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
//     }
// }