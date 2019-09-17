using api.Repositories;
using api.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using api.Models;

namespace api.Services
{
    public class ArtistService :IArtistService
    {
        private IArtistRepository _ArtistRepository;
        
        private AppSetting _config;

        public ArtistService(IArtistRepository artistRepo){
            _ArtistRepository = artistRepo;
        }

        public void Store(Artist newArtist)
        {
            try
            {
                _ArtistRepository.Store(newArtist); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public void Delete(int artistID)
        {
            try
            {
                _ArtistRepository.Delete(artistID);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public IEnumerable<Artist> GetAll()
        {   
            try
            {
                return _ArtistRepository.GetAll();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public Artist GetById(int artistID)
        {
            try
            {
                return _ArtistRepository.GetById(artistID);
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }
    }
}