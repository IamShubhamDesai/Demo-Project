using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Errors.Model;

namespace JobApplication.Core.Service.Helper
{
    internal class FileUploadHelper
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IConfiguration _configuration;

        public FileUploadHelper(IAmazonS3 s3Client,IConfiguration configuration)
        {
            _s3Client = s3Client;
            _configuration = configuration;
        }

        //public async Task<string> UploadFileToS3(IFormFile file)
        //{
        //    try
        //    {
        //        var stream = file.OpenReadStream();

        //        var Key = file.FileName + Guid.NewGuid().ToString();
        //        var putRequest = new PutObjectRequest
        //        {
        //            BucketName = _configuration["AWS:S3:BucketName"],
        //            Key = Key,
        //            ContentType = file.ContentType,
        //            InputStream = stream
        //        };

        //        PutObjectResponse response = await _s3Client.PutObjectAsync(putRequest);
        //        if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
        //        {
        //            throw new BadRequestException();
        //        }
        //    }
        //}
    }
}
