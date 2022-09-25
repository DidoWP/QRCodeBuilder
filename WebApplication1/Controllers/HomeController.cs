using QRCodeBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRCodeBuilder.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult CreateQRCode()
        {
            return View(new QRCodeModel());
        }

        [HttpPost]
        public IActionResult CreateQRCode(QRCodeModel qRCode)
        {
            if (qRCode.IsForFacebook && qRCode.OperatingSystem == "ios")
            {
                qRCode.QRCodeText = $"fb://profile/{qRCode.QRCodeText}";
            }
            else if (qRCode.IsForFacebook && qRCode.OperatingSystem == "android")
            {
                qRCode.QRCodeText = $"fb://page/{qRCode.QRCodeText}";
            }

            var QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            var QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));

            qRCode.CodeString = QrUri;
           
            return View(qRCode);
        }
    }

    //Extension method to convert Bitmap to Byte Array
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}