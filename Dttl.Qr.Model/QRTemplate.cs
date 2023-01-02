using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dttl.Qr.Model
{
    [Table("QRTemplate")]
    public class QRTemplate
    {
        [Key]
        public int TemplateId { get; set; }

        public string? TemplateName { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public string? ForeColor { get; set; }
        public string? BackgroundColor { get; set; }
        public byte[]? Logo { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}