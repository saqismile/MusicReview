using MusicReview.Domain.Entities;
using MusicReview.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicReview.Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IAppConfiguration _appConfig;

        public SongRepository(HttpClient httpClient, IAppConfiguration appConfig)
        {
            _httpClient = httpClient;
            _appConfig = appConfig;
        }

        public async Task<List<Song>> GetSongsByGenreAsync(string genre)
        {
            var url = $"{_appConfig.SmdbUrl}?genre={genre}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _appConfig.SmdbToken);

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return new List<Song>();

            }

            var content = await response.Content.ReadAsStringAsync();
            var songs = JsonSerializer.Deserialize<List<Song>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return songs ?? new List<Song>();
        }
    }
}
