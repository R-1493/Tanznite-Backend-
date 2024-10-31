using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class OrderRepository
    {
        protected DbSet<Order> _order;
        private readonly DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _order = databaseContext.Set<Order>();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await _order
                .Include(o => o.SingleProduct)
                .ThenInclude(op => op.Jewelry)
                .Include(o => o.SingleProduct)
                .ThenInclude(op => op.GemstoneShape)
                .ToListAsync();
            // Calculate FinalPrice for each order product
            foreach (var order in orders)
            {
                foreach (var product in order.SingleProduct)
                {
                    product.CalculateFinalPrice();
                    Console.WriteLine(
                        $"OrderProductId: {product.SingleProductId}, FinalPrice: {product.FinalPrice}"
                    );
                }
            }
            return orders;
        }

        public async Task<Order?> CreateOnAsync(Order newOrder)
        {
            await _order.AddAsync(newOrder);
            await _databaseContext.SaveChangesAsync();

            await _order.Entry(newOrder).Collection(o => o.SingleProduct).LoadAsync();

            foreach (var detail in newOrder.SingleProduct)
            {
                await _databaseContext.Entry(detail).Reference(od => od.Jewelry).LoadAsync();
                await _databaseContext.Entry(detail).Reference(od => od.GemstoneShape).LoadAsync();

                detail.CalculateFinalPrice();
            }

            return newOrder;
        }

        // 🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧 Under construction 🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧
        //     public async Task<List<Order>> GetAllAsync()
        //     {
        //         return await _databaseContext.Orders
        // .Include(o => o.OrderProducts) // Include OrderProducts
        // .ToListAsync();
        //     }
        // //update
        // public async Task<bool> UpdateOnAsync(Order updateOrder)
        // {
        //     _order.Update(updateOrder);
        //     await _databaseContext.SaveChangesAsync();
        //     return true;
        // }

        // //Delete
        // public async Task<bool> DeleteOnAsync(Order deleteOrder)
        // {
        //     _order.Remove(deleteOrder);
        //     await _databaseContext.SaveChangesAsync();
        //     return true;
        // }
    }
}
