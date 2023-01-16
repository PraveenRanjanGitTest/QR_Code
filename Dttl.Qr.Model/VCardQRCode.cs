using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dttl.Qr.Model
{
    [Table("QRCode_VCard")]
    public class VCardQRCode
    {
        [Key]
        public int VCardId { get; set; }

        public int QRCodeId { get; set; }
        public string? Title { get; set; }
        public string? EmployeeCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UploadImage { get; set; }
        public string? Designation { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? CompanyName { get; set; }
        public string? Website { get; set; }
        public string? PersonalLinks { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}