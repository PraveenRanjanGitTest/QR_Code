using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.Data.SqlClient;
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
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@VCardId", ""));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRCode_VCard"));

            return await _dbContext._vCardQRCodes
                  .FromSqlRaw(@"exec [SP_QRCode_VCard] @VCardId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<List<VCardQRCode>> GetVCardById(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@VCardId", Id));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRCode_VCard"));

            return await _dbContext._vCardQRCodes
                  .FromSqlRaw(@"exec [SP_QRCode_VCard] @VCardId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<int> AddVCard(VCardQRCode vCardQRCode)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@VCardId", ""));
            parameter.Add(new SqlParameter("@QRCodeId", vCardQRCode.QRCodeId));
            parameter.Add(new SqlParameter("@Title", vCardQRCode.Title));
            parameter.Add(new SqlParameter("@EmployeeCode", vCardQRCode.EmployeeCode));
            parameter.Add(new SqlParameter("@FirstName", vCardQRCode.FirstName));
            parameter.Add(new SqlParameter("@LastName", vCardQRCode.LastName));
            parameter.Add(new SqlParameter("@UploadImage", vCardQRCode.UploadImage));
            parameter.Add(new SqlParameter("@Designation", vCardQRCode.Designation));
            parameter.Add(new SqlParameter("@MobileNo", vCardQRCode.MobileNo));
            parameter.Add(new SqlParameter("@EmailId", vCardQRCode.EmailId));
            parameter.Add(new SqlParameter("@CompanyName", vCardQRCode.CompanyName));
            parameter.Add(new SqlParameter("@Website", vCardQRCode.Website));
            parameter.Add(new SqlParameter("@PersonalLinks", vCardQRCode.PersonalLinks));
            parameter.Add(new SqlParameter("@Type", "AddQRCode_VCard"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCode_VCardAddUpdate] @VCardId,@QRCodeId,@Title,@EmployeeCode,@FirstName,@LastName,@UploadImage,@Designation,@MobileNo,@EmailId,@CompanyName,@Website,@PersonalLinks,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> UpdateVCarde(VCardQRCode vCardQRCode)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@VCardId", vCardQRCode.VCardId));
            parameter.Add(new SqlParameter("@QRCodeId", vCardQRCode.QRCodeId));
            parameter.Add(new SqlParameter("@Title", vCardQRCode.Title));
            parameter.Add(new SqlParameter("@EmployeeCode", vCardQRCode.EmployeeCode));
            parameter.Add(new SqlParameter("@FirstName", vCardQRCode.FirstName));
            parameter.Add(new SqlParameter("@LastName", vCardQRCode.LastName));
            parameter.Add(new SqlParameter("@UploadImage", vCardQRCode.UploadImage));
            parameter.Add(new SqlParameter("@Designation", vCardQRCode.Designation));
            parameter.Add(new SqlParameter("@MobileNo", vCardQRCode.MobileNo));
            parameter.Add(new SqlParameter("@EmailId", vCardQRCode.EmailId));
            parameter.Add(new SqlParameter("@CompanyName", vCardQRCode.CompanyName));
            parameter.Add(new SqlParameter("@Website", vCardQRCode.Website));
            parameter.Add(new SqlParameter("@PersonalLinks", vCardQRCode.PersonalLinks));
            parameter.Add(new SqlParameter("@Type", "UpdateQRCode_VCard"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCode_VCardAddUpdate] @VCardId,@QRCodeId,@Title,@EmployeeCode,@FirstName,@LastName,@UploadImage,@Designation,@MobileNo,@EmailId,@CompanyName,@Website,@PersonalLinks,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteVCard(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@VCardId", Id));
            parameter.Add(new SqlParameter("@Type", "DeleteQRCode_VCard"));

            var result = await Task.Run(() => _dbContext.Database
                        .ExecuteSqlRawAsync(@"exec [SP_QRCode_VCard] @VCardId,@Type", parameter.ToArray()));
            return result;
        }
    }
}