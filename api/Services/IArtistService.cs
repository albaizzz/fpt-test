using api.Models;
using System.Collections.Generic;

namespace api.Services
{
    public interface IArtistService
    {
        void Store(Artist newArtist);
        void Delete(int artistID);
        IEnumerable<Artist> GetAll();
        Artist GetById(int artistID);
    }
}