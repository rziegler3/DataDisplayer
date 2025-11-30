using DataDisplayer.Models;
using System.Net.Http.Json;

namespace DataDisplayer.Services;

public class TextService
{
    private readonly HttpClient _httpClient;
    private List<Text>? _cachedTexts;

    public TextService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Text>> GetTextsAsync()
    {
        if (_cachedTexts != null)
        {
            return _cachedTexts;
        }

        try
        {
            _cachedTexts = await _httpClient.GetFromJsonAsync<List<Text>>("data/texts.json");
            return _cachedTexts ?? new List<Text>();
        }
        catch (Exception)
        {
            _cachedTexts = new List<Text>();
            return _cachedTexts;
        }
    }

    public async Task<List<Text>> GetTextsByTopicIdAsync(long topicId)
    {
        var allTexts = await GetTextsAsync();
        return allTexts
            .Where(t => t.Topic?.Id == topicId)
            .OrderBy(t => t.Position)
            .ToList();
    }
}
