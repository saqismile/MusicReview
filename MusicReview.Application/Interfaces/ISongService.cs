using MusicReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicReview.Application.Interfaces
{
    public interface ISongService
    {        Task<List<Song>> GetSongsByGenreAsync(string genre);
    }
}
