using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class CartRepository
    {
        protected DbSet<Cart> _cart;
        protected DatabaseContext _databaseContext;

        public CartRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _cart = databaseContext.Set<Cart>();
        }

        public async Task<Cart> CreateOneAsync(Cart newCart)
        {
            await _cart.AddAsync(newCart);
            await _databaseContext.SaveChangesAsync();
            return newCart;
        }

        // 🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧 Under construction 🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧
        // Get All carts Asynchronously
        // public async Task<List<Cart>> GetAllAsync()
        // {
        //     return await _cart.ToListAsync(); // Return the list of carts
        // }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await _cart
                .Include(o => o.Orders)
                .ThenInclude(op => op.SingleProduct)
                .ThenInclude(op => op.Jewelry)
                .Include(o => o.Orders)
                .ThenInclude(op => op.SingleProduct)
                .ThenInclude(op => op.GemstoneShape)
                .ToListAsync();
        }

        public async Task<Cart?> GetByIdAsync(Guid id)
        {
            return await _cart.FindAsync(id);
        }

        public async Task<List<Cart>> GetByIdUserAsync(Guid userId)
        {
            return await _cart
                .Where(c => c.UserId == userId)
                .Include(o => o.Orders)
                .ThenInclude(op => op.SingleProduct)
                .ThenInclude(op => op.Jewelry)
                .Include(o => o.Orders)
                .ThenInclude(op => op.SingleProduct)
                .ThenInclude(op => op.GemstoneShape)
                .ToListAsync();
        }

        public async Task<bool> UpdateOneAsync(Cart updateCart)
        {
            _cart.Update(updateCart);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
