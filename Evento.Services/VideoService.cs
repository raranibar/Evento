using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VideoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public  Task<Video> GetVideo(int id)
        {
            return  this._unitOfWork.VideoRepository.GetById(id);
        }

        public IEnumerable<Video> GetVideos()
        {
            return this._unitOfWork.VideoRepository.GetAll().Where(q => q.Estado == true);
        }

        public async Task PostVideo(Video o)
        {
            await this._unitOfWork.VideoRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutVideo(Video o)
        {
            this._unitOfWork.VideoRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteVideo(int id)
        {
            await this._unitOfWork.VideoRepository.Delete(id);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
