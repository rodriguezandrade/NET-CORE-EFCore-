using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Services
{
    public class ImageResourceService : IImageResourceService
    {
        public bool canSaveImage(IFormFile imageFile, out string urlPath)
        {
            urlPath = string.Empty;
            var imageName = string.Empty;
            try
            {
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/Files/Images/";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);

                }

                var ext = imageFile.FileName.Substring(imageFile.FileName.Length - 4);
                imageName = imageFile.FileName;
                var filePath = folderPath + imageName;

                FileStream stream = new FileStream(filePath, FileMode.Create);
                imageFile.CopyTo(stream);
                urlPath = "/Files/Images/" + imageName;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
