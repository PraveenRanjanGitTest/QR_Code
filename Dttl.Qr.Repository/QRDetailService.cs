using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository
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
        public async Task<QRDetails> AddQRDetails(QRDetails qRDetails)
        {
            var result = await _dbContext.AddAsync(qRDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QRDetails> UpdateQReDetails(QRDetails qRDetails)
        {
            var result = _dbContext._qRDetails.Update(qRDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<QRDetails> DeleteQRDetails(int Id)
        {
            var result = await _dbContext._qRDetails.FindAsync(Id);
            _dbContext._qRDetails.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
