namespace Features.Song.Upload;

public class Request
{
    public required IFormFile File { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.File)
            .Must(file => file.ContentType == "audio/mpeg" || file.ContentType == "audio/wav")
            .WithMessage("The file must be a valid audio file (MP3 or WAV).");
    }
}
