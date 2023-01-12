using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository.Implementation
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
            return await _dbContext._qrCode.FirstOrDefaultAsync(m => m.TemplateId == Id);
        }

        public async Task<int> AddQRCodes(QrCode qRCode)
        {
            var _qrCode = new QrCode();
            _qrCode.TemplateId = qRCode.TemplateId;
            _qrCode.QRType = qRCode.QRType;
            _qrCode.IsDynamic = qRCode.IsDynamic;
            _qrCode.IsActive = true;
            _qrCode.CreatedBy = qRCode.CreatedBy;
            _qrCode.CreatedDate = DateTime.UtcNow;

            var result = await _dbContext.AddAsync(_qrCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity.QRCodeId;
        }

        public async Task<int> UpdateQRCode(QrCode qRCode)
        {
            var _qrCode = _dbContext._qrCode.FirstOrDefault(t => t.QRCodeId == qRCode.QRCodeId);
            _qrCode.QRType = qRCode.QRType;
            _qrCode.IsActive = qRCode.IsActive;
            _qrCode.ModifiedBy = qRCode.ModifiedBy;
            _qrCode.ModifiedDate = DateTime.UtcNow;

            var result = _dbContext._qrCode.Update(_qrCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity.QRCodeId;
        }

        public async Task<int> DeleteQRCodes(int Id)
        {
            var result = await _dbContext._qrCode.FindAsync(Id);
            _dbContext._qrCode.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result.QRCodeId;
        }
    }
}