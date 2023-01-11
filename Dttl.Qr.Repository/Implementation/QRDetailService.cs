using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository.Implementation
{
    public class QRDetailService : IQRDetailService
    {
        private readonly DbContextClass _dbContext;

        public QRDetailService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<QRDetails>> GetQRDetailList()
        {
            return await _dbContext._qRDetails.ToListAsync();
        }

        public async Task<QRDetails> GetQRDetailListById(int Id)
        {
            return await _dbContext._qRDetails.FirstOrDefaultAsync(m => m.QRDetailId == Id);
        }

        public async Task<int> AddQRDetails(QRDetails qRDetails)
        {
            var _qrdetails = new QRDetails();
            _qrdetails.QRCodeId = qRDetails.QRCodeId;
            _qrdetails.QRName = qRDetails.QRName;
            _qrdetails.QRImage = qRDetails.QRImage;
            _qrdetails.CreatedDate = DateTime.UtcNow;

            var result = await _dbContext.AddAsync(_qrdetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity.QRDetailId;
        }

        public async Task<int> UpdateQReDetails(QRDetails qRDetails)
        {
            var _qrdetails = new QRDetails();
            _qrdetails.QRDetailId = qRDetails.QRDetailId;
            _qrdetails.QRCodeId = qRDetails.QRCodeId;
            _qrdetails.QRName = qRDetails.QRName;
            _qrdetails.QRImage = qRDetails.QRImage;

            var result = _dbContext._qRDetails.Update(_qrdetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity.QRDetailId;
        }

        public async Task<int> DeleteQRDetails(int Id)
        {
            var result = await _dbContext._qRDetails.FindAsync(Id);
            _dbContext._qRDetails.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result.QRDetailId;
        }
    }
}