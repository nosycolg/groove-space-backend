using Amazon.S3.Model;

public class S3Service(IAmazonS3 s3Client, IConfiguration configuration)
{
    private readonly IAmazonS3 _s3Client = s3Client;
    private readonly string _bucketName = configuration["AWS:BucketName"];

    public async Task UploadFileAsync(string fileName, Stream fileStream, string contentType)
    {
        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName,
            InputStream = fileStream,
            ContentType = contentType,
        };

        await _s3Client.PutObjectAsync(request);
    }

    public async Task<Stream> GetFileAsync(string fileName)
    {
        var request = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName
        };

        var response = await _s3Client.GetObjectAsync(request);
        return response.ResponseStream;
    }

    public async Task DeleteFileAsync(string fileName)
    {
        var request = new DeleteObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName
        };

        await _s3Client.DeleteObjectAsync(request);
    }

    public async Task<List<string>> ListFilesAsync()
    {
        var request = new ListObjectsV2Request
        {
            BucketName = _bucketName
        };

        var response = await _s3Client.ListObjectsV2Async(request);
        
        var fileNames = response.S3Objects.Select(o => o.Key).ToList();
        
        return fileNames;
    }
}
