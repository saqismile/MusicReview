using MusicReview.Application.Interfaces;
using MusicReview.Domain.Entities;
using MusicReview.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicReview.Application.Services
{
    public class SongService : ISongService
    {

        private readonly ISongRepository _songRepository;
        private readonly IAppLogger _logger;

        public SongService(ISongRepository songRepository, IAppLogger logger)
        {
            _songRepository = songRepository;
            _logger = logger;
        }

        public async Task<List<Song>> GetSongsByGenreAsync(string genre)
        {
            _logger.LogInfo($"Fetching songs for genre: {genre}");
            return await _songRepository.GetSongsByGenreAsync(genre);
        }
    }
}
