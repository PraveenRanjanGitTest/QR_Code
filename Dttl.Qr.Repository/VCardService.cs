using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository
{
    public class VCardService : IVCardService
    {
        private readonly DbContextClass _dbContext;

        public VCardService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VCardQRCode>> GetVCardList()
        {
            return await _dbContext._vCardQRCodes.ToListAsync();
        }

        public async Task<VCardQRCode> GetVCardById(int Id)
        {
            return await _dbContext._vCardQRCodes.FirstOrDefaultAsync(m => m.VCardId == Id);
        }

        public async Task<VCardQRCode> AddVCard(VCardQRCode vCardQRCode)
        {
            var result = await _dbContext.AddAsync(vCardQRCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VCardQRCode> UpdateVCarde(VCardQRCode vCardQRCode)
        {
            var result = _dbContext._vCardQRCodes.Update(vCardQRCode);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VCardQRCode> DeleteVCard(int Id)
        {
            var result = await _dbContext._vCardQRCodes.FindAsync(Id);
            _dbContext._vCardQRCodes.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}