using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dttl.Qr.Model
{
    [Table("QRCodeMaster")]
    public class QrCode
    {
        [Key]
        public int QRCodeId { get; set; }

        public int TemplateId { get; set; }
        public string? QRType { get; set; }
        public bool IsDynamic { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}