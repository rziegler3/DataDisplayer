using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataDisplayer.Models;

namespace DataDisplayer.Services
{
    public class TopicImageService
    {
        private readonly HttpClient _httpClient;
        private List<TopicImage> _images;

        public TopicImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TopicImage>> GetImagesAsync()
        {
            if (_images == null)
            {
                _images = await _httpClient.GetFromJsonAsync<List<TopicImage>>("data/topicImages.json");
            }
            return _images;
        }

        public async Task<List<TopicImage>> GetImagesForTopicAsync(int topicId)
        {
            var images = await GetImagesAsync();
            return images.FindAll(img => img.TopicId == topicId);
        }
    }
}
