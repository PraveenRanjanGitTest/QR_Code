using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dttl.Qr.Model
{
<<<<<<< HEAD
    [Table("QRCode_Url")]
    public class UrlqrCode
=======
    [Table("URLQRCode")]
    public class URLQRCode
>>>>>>> d62eaafbb20a2a0ef18004aa8aa9c4bc6e1083e8
    {
        [Key]
        public int URLId { get; set; }
        public int QRCodeId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}