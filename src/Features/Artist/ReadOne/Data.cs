namespace Features.Artist.ReadOne;

public static class Data
{
    internal static async Task<List<Domain.Entities.Artist>> GetArtistsAsync()
    {
        return await DB.Find<Domain.Entities.Artist>().ExecuteAsync();
    }
}