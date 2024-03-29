﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using WorldCulture.Api.Dtos;

namespace WorldCulture.Api.Helpers
{
    public class CloudinaryConfiguration : ICloudinaryConfiguration
    {

        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public CloudinaryConfiguration(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(
               _cloudinaryConfig.Value.CloudName,
               _cloudinaryConfig.Value.ApiKey,
               _cloudinaryConfig.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);

        }

        public CloudinaryForReturnDto UploadImage(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            return new CloudinaryForReturnDto
            {
                Url = uploadResult.Uri.ToString(),
                PublicId = uploadResult.PublicId
            };
        }

        public void DeleteImage(string publicId)
        {
            _cloudinary.DeleteResources(publicId);
        }
    }
}
