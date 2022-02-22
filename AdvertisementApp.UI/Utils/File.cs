using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Utils
{
    public class File
    {
        public void FileUpload(IFormFile file, string fileLocation, out string validation, out string filePath)
        {
            #region Hocanın Yaptığı
            // var fileName = Guid.NewGuid().ToString();
            // var extName = Path.GetExtension(model.CvFile.FileName);
            // string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
            // var stream = new FileStream(path, FileMode.Create);
            // await model.CvFile.CopyToAsync(stream);
            // createdAdvertisementAppUser.CvPath = fileName + extName;
            #endregion

            var result = FileValidation(file);

            if (result == null)
            {
                // fileLocation = cvFiles
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(file.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{fileLocation}/", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);

                filePath = fileName + extName;
                validation = null;
            }
            else
            {
                validation = result;
                filePath = null;
            }

        }

        public string FileValidation(IFormFile file)
        {
            // var extensions = new string[] { "pdf", "jpg", "jpeg", "png" };

            var extName = Path.GetExtension(file.FileName);
            if (file == null || file.Length == 0)
            {
                return "Dosya bulunamadı. Dosya eklemeden işlem yapamazsınız";
            }
            else if (extName.Contains("pdf")
             || extName.Contains("jpg")
             || extName.Contains("jpeg")
             || extName.Contains("png"))
            {
                return null;
            }
            else
            {
                return "Dosya uzantısı pdf, jpg, jpeg veya png olmalıdır";
            }
        }
    }
}
