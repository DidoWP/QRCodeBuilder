using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class QRCodeModel
    {
        [Display(Name = "QRCode Text")]
        public string QRCodeText { get; set; }
        public string CodeString { get; set; }
        public bool IsForFacebook { get; set; }
        public string OperatingSystem { get; set; }

        public QRCodeModel()
        {
            QRCodeText = "";
            CodeString = "";
            IsForFacebook = false;
            OperatingSystem = "";
        }
    }
}
