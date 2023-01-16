using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository.Implementation
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

        public async Task<int> AddVCard(VCardQRCode vCardQRCode)
        {
            var _vcardqrcode = new VCardQRCode();
            _vcardqrcode.QRCodeId = vCardQRCode.QRCodeId;
            _vcardqrcode.Title = vCardQRCode.Title;
            _vcardqrcode.EmployeeCode = vCardQRCode.EmployeeCode;
            _vcardqrcode.FirstName = vCardQRCode.FirstName;
            _vcardqrcode.LastName = vCardQRCode.LastName;
            _vcardqrcode.UploadImage = vCardQRCode.UploadImage;
            _vcardqrcode.Designation = vCardQRCode.Designation;
            _vcardqrcode.MobileNo = vCardQRCode.MobileNo;
            _vcardqrcode.EmailId = vCardQRCode.EmailId;
            _vcardqrcode.CompanyName = vCardQRCode.CompanyName;
            _vcardqrcode.Website = vCardQRCode.Website;
            _vcardqrcode.PersonalLinks = vCardQRCode.PersonalLinks;
            _vcardqrcode.CreatedDate = DateTime.UtcNow;

            var result = await _dbContext.AddAsync(_vcardqrcode);
            await _dbContext.SaveChangesAsync();
            return result.Entity.VCardId;
        }

        public async Task<int> UpdateVCarde(VCardQRCode vCardQRCode)
        {
            var _vcardqrcode = _dbContext._vCardQRCodes.FirstOrDefault(t => t.VCardId == vCardQRCode.VCardId);
            _vcardqrcode.QRCodeId = vCardQRCode.QRCodeId;
            _vcardqrcode.Title = vCardQRCode.Title;
            _vcardqrcode.EmployeeCode = vCardQRCode.EmployeeCode;
            _vcardqrcode.FirstName = vCardQRCode.FirstName;
            _vcardqrcode.LastName = vCardQRCode.LastName;
            _vcardqrcode.UploadImage = vCardQRCode.UploadImage;
            _vcardqrcode.Designation = vCardQRCode.Designation;
            _vcardqrcode.MobileNo = vCardQRCode.MobileNo;
            _vcardqrcode.EmailId = vCardQRCode.EmailId;
            _vcardqrcode.CompanyName = vCardQRCode.CompanyName;
            _vcardqrcode.Website = vCardQRCode.Website;
            _vcardqrcode.PersonalLinks = vCardQRCode.PersonalLinks;

            var result = _dbContext._vCardQRCodes.Update(_vcardqrcode);
            await _dbContext.SaveChangesAsync();
            return result.Entity.VCardId;
        }

        public async Task<int> DeleteVCard(int Id)
        {
            var result = await _dbContext._vCardQRCodes.FindAsync(Id);
            _dbContext._vCardQRCodes.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result.VCardId;
        }
    }
}