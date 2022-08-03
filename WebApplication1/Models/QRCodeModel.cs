using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class QRCodeModel
    {
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }
        public string CodeString { get; set; }
    }
}
