namespace Features.Song.Upload;

public class Endpoint(S3Service s3Service) : Endpoint<Request>
{
    private readonly S3Service _s3Service = s3Service;

    public override void Configure()
    {
        Put("song/upload");
        Summary(s =>
        {
            s.Summary = "Upload a new song to the S3 storage.";
            s.Description = "This endpoint allows users to upload a new song file to the S3 bucket.";
        });
        AllowAnonymous();
        AllowFileUploads();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        using (var stream = req.File.OpenReadStream())
        {
            await _s3Service.UploadFileAsync(req.File.FileName, stream, "audio/mpeg");
        }

        await SendOkAsync(ct);
    }
}