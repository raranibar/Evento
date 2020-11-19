using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IVideoService
    {
        IEnumerable<Video> GetVideos();

        Task<Video> GetVideo(int id);

        Task PostVideo(Video o);

        Task<bool> PutVideo(Video o);

        Task<bool> DeleteVideo(int id);
    }
}
