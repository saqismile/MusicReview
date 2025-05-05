using Moq;
using MusicReview.Application.Interfaces;
using MusicReview.Application.Services;
using MusicReview.Domain.Entities;
using MusicReview.Domain.Interfaces;
namespace MusicReview.Test
{
    [TestClass]
    public sealed class SongTest
    {
        private Mock<ISongRepository> _songRepositoryMock;
        private Mock<IAppLogger> _loggerMock;
        private SongService _songService;


        [TestInitialize]
        public void Setup()
        {
            // Initialize the mocks
            _songRepositoryMock = new Mock<ISongRepository>();
            _loggerMock = new Mock<IAppLogger>();
            
            _songService = new SongService(_songRepositoryMock.Object, _loggerMock.Object);
        }

        /// <summary>
        /// Service Test
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetSongsByGenreAsync_ReturnsSongs_IsValid()
        {
           
            var genre = "pop";
            var songs = new List<Song>
            {
                new Song { Name = "Song1", ArtistName = "pop" },
                new Song { Name = "Song2", ArtistName = "pop" }
            };

           
            _songRepositoryMock
                .Setup(repo => repo.GetSongsByGenreAsync(genre))
                .ReturnsAsync(songs);

           
            var result = await _songService.GetSongsByGenreAsync(genre);

            
            Assert.IsNotNull(result);  
            Assert.AreEqual(songs[1].ArtistName, result[1].ArtistName);

        }
        /// <summary>
        /// Repository Test
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetSongsByGenreAsync_ReturnsEmptyList()
        {
            
            var genre = "rock";
            var songs = new List<Song>(); 

            _songRepositoryMock
                .Setup(repo => repo.GetSongsByGenreAsync(genre))
                .ReturnsAsync(songs);

            
            var result = await _songService.GetSongsByGenreAsync(genre);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);

           
        }

        
    }
}
