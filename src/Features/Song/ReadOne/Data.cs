namespace Features.Song.ReadOne;

public static class Data
{
    internal static async Task<List<Domain.Entities.Song>> GetSongsAsync()
    {
        return await DB.Find<Domain.Entities.Song>().ExecuteAsync();
    }
}