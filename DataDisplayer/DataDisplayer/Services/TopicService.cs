using DataDisplayer.Models;
using System.Net.Http.Json;

namespace DataDisplayer.Services;

public class TopicService
{
    private readonly HttpClient _httpClient;
    private List<Topic>? _cachedTopics;

    public TopicService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Topic>> GetTopicsAsync()
    {
        if (_cachedTopics != null)
        {
            return _cachedTopics;
        }

        try
        {
            _cachedTopics = await _httpClient.GetFromJsonAsync<List<Topic>>("data/topics.json");
            return _cachedTopics ?? new List<Topic>();
        }
        catch (Exception)
        {
            _cachedTopics = new List<Topic>();
            return _cachedTopics;
        }
    }

    public async Task<Topic?> GetTopicByIdAsync(long topicId)
    {
        var topics = await GetTopicsAsync();
        return topics.FirstOrDefault(t => t.Id == topicId);
    }
}
