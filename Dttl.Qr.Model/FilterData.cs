using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Model
{
    [Keyless]
    public class FilterData
    {
        public string? TemplateName { get; set; }
        public string? ForeColor { get; set; }
        public string? BackgroundColor { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
    }
}