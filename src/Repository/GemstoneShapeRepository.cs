using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.GemstoneShape;
using src.Database;
using src.Entity;
using src.Utils;

namespace src.Repository
{
    public class GemstoneShapeRepository
    {
        protected DbSet<GemstoneShape> _gemstoneShap;
        protected DatabaseContext _databaseContext;

        public GemstoneShapeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _gemstoneShap = databaseContext.Set<GemstoneShape>();
        }

        public async Task<GemstoneShape> CreateOnAsync(GemstoneShape newGemstoneShape)
        {
            await _gemstoneShap.AddAsync(newGemstoneShape);
            await _databaseContext.SaveChangesAsync();
            return newGemstoneShape;
        }

        public async Task<List<GemstoneShape>> GetAllAsync(PaginationOptions options)
        {
            var gemstoneShap = _gemstoneShap.ToList();
            if (!string.IsNullOrEmpty(options.Search))
            {
                gemstoneShap = gemstoneShap
                    .Where(p =>
                        p.ShapeName.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();
            }
            if (options.MinPrice.HasValue && options.MinPrice > 0)
            {
                gemstoneShap = gemstoneShap
                    .Where(p => p.GemstoneShapPrice >= options.MinPrice)
                    .ToList();
            }
            // max price
            if (options.MinPrice.HasValue && options.MaxPrice < decimal.MaxValue)
            {
                gemstoneShap = gemstoneShap
                    .Where(p => p.GemstoneShapPrice <= options.MaxPrice)
                    .ToList();
            }
            gemstoneShap = gemstoneShap.Skip(options.Offset).Take(options.Limit).ToList();
            return gemstoneShap;
        }

        public async Task<int> CountAsync()
        {
            return await _databaseContext.Set<GemstoneShape>().CountAsync();
        }

        public async Task<List<GemstoneShape>> GetAllAsync()
        {
            return await _gemstoneShap.ToListAsync();
        }
    }
}
