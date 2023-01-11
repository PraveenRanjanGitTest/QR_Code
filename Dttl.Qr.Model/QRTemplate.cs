using System.ComponentModel.DataAnnotations;

namespace Dttl.Qr.Model
{
    //[Table("QRTemplate")]
    public class QRTemplate
    {
        [Key]
        public int TemplateId { get; set; }

        [Required(ErrorMessage = "The Template Name cannot be blank."), StringLength(100)]
        public string? TemplateName { get; set; }

        [Required(ErrorMessage = "The Template Height cannot be blank.")]
        [Range(0.01, 999, ErrorMessage = "The Template Height must be greater than 0")]
        public decimal? Height { get; set; }

        [Required(ErrorMessage = "The Template Width cannot be blank.")]
        [Range(0.01, 999, ErrorMessage = "The Template Width must be greater than 0")]
        public decimal? Width { get; set; }

        [Required(ErrorMessage = "The Template ForeColor cannot be blank."), StringLength(50)]
        public string? ForeColor { get; set; }

        [Required(ErrorMessage = "The Template BackgroundColor cannot be blank."), StringLength(50)]
        public string? BackgroundColor { get; set; }

        [Required(ErrorMessage = "The Template Logo cannot be blank.")]
        public string? Logo { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}