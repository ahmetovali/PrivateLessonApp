using PrivateLesson.Business.Abstract;
using PrivateLesson.Data.Abstract;
using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Concrete
{
    public class AdvertManager : IAdvertService
    {
        private IAdvertRepository _advertRepository;
        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        public async Task CreateAsync(Advert advert)
        {
            await _advertRepository.CreateAsync(advert);
        }

        public void Delete(Advert advert)
        {
            _advertRepository.Delete(advert);
        }

        public async Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus)
        {
            return await _advertRepository.GetAdvertsFullDataAsync(id, approvedStatus);
        }

        public async Task<List<Advert>> GetAllAsync()
        {
            return await _advertRepository.GetAllAsync();
        }

        public async Task<Advert> GetByIdAsync(int id)
        {
            return await _advertRepository.GetByIdAsync(id);
        }

        public void Update(Advert advert)
        {
            _advertRepository.Update(advert);
        }
    }
}
