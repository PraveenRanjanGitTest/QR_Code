using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dttl.Qr.Model
{
    [Table("QRCode_Url")]
    public class UrlqrCode
    {
        [Key]
        public int URLId { get; set; }

        public int QRCodeId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}