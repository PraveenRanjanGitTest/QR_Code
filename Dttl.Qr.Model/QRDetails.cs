using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dttl.Qr.Model
{
    [Table("QRDetails")]
    public class QRDetails
    {
        [Key]
        public int QRDetailId { get; set; }

        public int QRCodeId { get; set; }
        public string? QRName { get; set; }
        public byte[]? QRImage { get; set; }
        public string? TargetUrl { get; set; }
        public string? FormatType { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}