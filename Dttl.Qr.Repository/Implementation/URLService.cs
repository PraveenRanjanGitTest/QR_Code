using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository.Implementation
{
    public class URLService : IURLService
    {
        private readonly DbContextClass _dbContext;

        public URLService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UrlqrCode>> GetURLQRCodelList()
        {
            return await _dbContext._uRLQRCodes.ToListAsync();
        }
        public async Task<UrlqrCode> GetURLQRCodeListById(int Id)
        {
            return await _dbContext._uRLQRCodes.FirstOrDefaultAsync(m => m.URLId == Id);
        }

        public async Task<int> AddURLQRCode(UrlqrCode uRLQRCode)
        {
            var _urlqrCode = new UrlqrCode();
            _urlqrCode.QRCodeId = uRLQRCode.QRCodeId;
            _urlqrCode.Title = uRLQRCode.Title;
            _urlqrCode.Url = uRLQRCode.Url;
            _urlqrCode.CreatedDate = DateTime.UtcNow;

            var result = await _dbContext.AddAsync(_urlqrCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity.URLId;
        }

        public async Task<int> UpdateURLQRCode(UrlqrCode uRLQRCode)
        {
            var _urlqrCode = new UrlqrCode();
            _urlqrCode.URLId = uRLQRCode.URLId;
            _urlqrCode.QRCodeId = uRLQRCode.QRCodeId;
            _urlqrCode.Title = uRLQRCode.Title;
            _urlqrCode.Url = uRLQRCode.Url;

            var result = _dbContext._uRLQRCodes.Update(_urlqrCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity.URLId;
        }

        public async Task<int> DeleteURLQRCode(int Id)
        {
            var result = await _dbContext._uRLQRCodes.FindAsync(Id);
            _dbContext._uRLQRCodes.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result.URLId;
        }
    }
}