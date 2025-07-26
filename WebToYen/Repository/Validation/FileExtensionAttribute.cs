using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace WebToYen.Repository.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName); // ".jpg"
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };

                if (!allowedExtensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult("Chỉ chấp nhận các định dạng ảnh: .jpg, .jpeg, .png, .webp");
                }
            }

            return ValidationResult.Success;
        }
    }
}
