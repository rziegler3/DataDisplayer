using DataDisplayer.Models;
using System.Net.Http.Json;

namespace DataDisplayer.Services;

public class FormatService
{
    private readonly HttpClient _httpClient;
    private List<Format>? _cachedFormats;

    public FormatService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Format>> GetFormatsAsync()
    {
        if (_cachedFormats != null)
        {
            return _cachedFormats;
        }

        try
        {
            _cachedFormats = await _httpClient.GetFromJsonAsync<List<Format>>("data/formats.json");
            return _cachedFormats ?? new List<Format>();
        }
        catch (Exception)
        {
            _cachedFormats = new List<Format>();
            return _cachedFormats;
        }
    }

    public async Task<Format?> GetFormatByIdAsync(long formatId)
    {
        var formats = await GetFormatsAsync();
        return formats.FirstOrDefault(f => f.Id == formatId);
    }
}
