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

        public async Task<List<GemstoneShape>> GetAllAsync()
        {
            return await _gemstoneShap.ToListAsync();
        }
    }
}
