using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;
using src.Utils;

namespace src.Repository
{
    public class GemstonesRepository
    {
        protected DbSet<Gemstones> _gemstones;
        protected DatabaseContext _databaseContext;

        public GemstonesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _gemstones = databaseContext.Set<Gemstones>();
        }

        public async Task<Gemstones> CreateOnAsync(Gemstones newGemstone)
        {
            await _gemstones.AddAsync(newGemstone);
            await _databaseContext.SaveChangesAsync();
            return newGemstone;
        }

        public async Task<List<Gemstones>> GetAllAsync(PaginationOptions options)
        {
            var gemstones = _gemstones.ToList();

            if (!string.IsNullOrEmpty(options.Search))
            {
                gemstones = gemstones
                    .Where(p =>
                        p.GemstoneType.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();
            }

            // min price
            if (options.MinPrice.HasValue && options.MinPrice > 0)
            {
                gemstones = gemstones.Where(p => p.GemstonePrice >= options.MinPrice).ToList();
            }
            // max price
            if (options.MinPrice.HasValue && options.MaxPrice < decimal.MaxValue)
            {
                gemstones = gemstones.Where(p => p.GemstonePrice <= options.MaxPrice).ToList();
            }
            gemstones = gemstones.Skip(options.Offset).Take(options.Limit).ToList();

            return gemstones;
        }

        public async Task<List<Gemstones>> GetAllAsync()
        {
            return await _gemstones.ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _databaseContext.Set<Gemstones>().CountAsync();
        }

        public async Task<Gemstones?> GetByIdAsync(Guid GemstoneId)
        {
            return await _gemstones.FindAsync(GemstoneId);
        }

        public async Task<bool> DeleteOnAsync(Gemstones Gemstone)
        {
            _gemstones.Remove(Gemstone);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(Gemstones updateGemstone)
        {
            _gemstones.Update(updateGemstone);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Gemstones>> GetAllBySearch(PaginationOptions paginationOptions)
        {
            var result = _gemstones.Where(j =>
                j.GemstoneType.ToLower().Contains(paginationOptions.Search.ToLower())
            );
            return await result
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToListAsync();
        }
    }
}
