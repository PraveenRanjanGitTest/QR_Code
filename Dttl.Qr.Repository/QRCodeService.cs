using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository
{
    public class QRCodeService : IQRCodeService
    {
        private readonly DbContextClass _dbContext;

        public QRCodeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QrCode>> GetQRCodeList()
        {
            return await _dbContext._qrCode.ToListAsync();
        }

        public async Task<QrCode> GetQRCodeListById(int Id)
        {
            return await _dbContext._qrCode.FirstOrDefaultAsync(m => m.QRCodeId == Id);
        }

        public async Task<QrCode> AddQRCodes(QrCode qRCode)
        {
            var result = await _dbContext.AddAsync(qRCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QrCode> UpdateQRCode(QrCode qRCode)
        {
            var result = _dbContext._qrCode.Update(qRCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QrCode> DeleteQRCodes(int Id)
        {
            var result = await _dbContext._qrCode.FindAsync(Id);
            _dbContext._qrCode.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}