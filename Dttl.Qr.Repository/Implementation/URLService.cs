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
<<<<<<< HEAD
        public async Task<List<UrlqrCode>> GetURLQRCodelList()
=======

        public async Task<List<URLQRCode>> GetURLQRCodelList()
>>>>>>> d62eaafbb20a2a0ef18004aa8aa9c4bc6e1083e8
        {
            return await _dbContext._uRLQRCodes.ToListAsync();
        }
<<<<<<< HEAD
        public async Task<UrlqrCode> GetURLQRCodeListById(int Id)
=======

        public async Task<List<URLQRCode>> GetURLQRCodeListById(int Id)
>>>>>>> d62eaafbb20a2a0ef18004aa8aa9c4bc6e1083e8
        {
            return await _dbContext._uRLQRCodes.FirstOrDefaultAsync(m => m.URLId == Id);
        }

        public async Task<int> AddURLQRCode(URLQRCode uRLQRCode)
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

        public async Task<int> UpdateURLQRCode(URLQRCode uRLQRCode)
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