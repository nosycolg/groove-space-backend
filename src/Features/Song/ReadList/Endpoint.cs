namespace Features.Song.ReadList
{
    public class ListFilesEndpoint(S3Service s3Service) : EndpointWithoutRequest
    {
        private readonly S3Service _s3Service = s3Service;

        public override void Configure()
        {
            Get("song/list");
            Summary(s =>
            {
                s.Summary = "List all songs in the S3 bucket.";
                s.Description = "This endpoint retrieves the list of all audio files available in the S3 bucket.";
            });
            AllowAnonymous();
            Description(x => x.Produces<List<string>>(200));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var fileNames = await _s3Service.ListFilesAsync();

            await SendOkAsync(fileNames, ct);
        }
    }
}
