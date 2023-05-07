using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Core
{
    public static class Jobs
    {
        public static string GetUrl(string text)
        {
            #region Sorunlu T�rk�e Karakterler D�zeltiliyor
            text = text.Replace("I", "i");
            text = text.Replace("�", "i");
            text = text.Replace("�", "i");
            #endregion
            #region K���k Harfe D�n��t�r�l�yor
            text = text.ToLower();
            #endregion
            #region T�rk�e Karakterler D�zeltiliyor
            text = text.Replace("�", "o");
            text = text.Replace("�", "u");
            text = text.Replace("�", "s");
            text = text.Replace("�", "c");
            text = text.Replace("�", "g");
            #endregion
            #region Sorunlu Karakterler D�zeltiliyor
            text = text.Replace(".", "");
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace("'", "");
            text = text.Replace("`", "");
            text = text.Replace("\"", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("?", "");
            text = text.Replace(",", "");
            text = text.Replace("-", "");
            text = text.Replace("_", "");
            text = text.Replace("$", "");
            text = text.Replace("&", "");
            text = text.Replace("%", "");
            text = text.Replace("^", "");
            text = text.Replace("#", "");
            text = text.Replace("+", "");
            text = text.Replace("!", "");
            text = text.Replace("=", "");
            text = text.Replace(";", "");
            text = text.Replace(">", "");
            text = text.Replace("<", "");
            text = text.Replace("|", "");
            text = text.Replace("*", "");
            #endregion
            #region Bo�luklar Tire �le De�i�tiriliyor
            text = text.Replace(" ", "-");
            #endregion
            return text;
        }

        public static string UploadImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var randomName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return randomName;
        }

        public static string CreateMessage(string title, string message, string alertType)
        {
            AlertMessage msg = new AlertMessage
            {
                Title = title,
                Message = message,
                AlertType = alertType
            };
            string result = JsonConvert.SerializeObject(msg);
            return result;
        }


    }
}
