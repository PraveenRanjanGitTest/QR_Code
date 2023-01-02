using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository
{
    public class URLService : IURLService
    {
        private readonly DbContextClass _dbContext;

        public URLService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<URLQRCode>> GetURLQRCodelList()
        {
            return await _dbContext._uRLQRCodes.ToListAsync();
        }

        public async Task<URLQRCode> GetURLQRCodeListById(int Id)
        {
            return await _dbContext._uRLQRCodes.FirstOrDefaultAsync(m => m.URLId == Id);
        }

        public async Task<URLQRCode> AddURLQRCode(URLQRCode uRLQRCode)
        {
            var result = await _dbContext.AddAsync(uRLQRCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<URLQRCode> UpdateURLQRCode(URLQRCode uRLQRCode)
        {
            var result = _dbContext._uRLQRCodes.Update(uRLQRCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<URLQRCode> DeleteURLQRCode(int Id)
        {
            var result = await _dbContext._uRLQRCodes.FindAsync(Id);
            _dbContext._uRLQRCodes.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}