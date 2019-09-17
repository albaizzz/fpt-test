using api.Models;
using System.Collections.Generic;

namespace api.Repositories
{
    public interface IArtistRepository
    {
         void Store(Artist newArtist);
         void Delete(int artistID);
         IEnumerable<Artist> GetAll();
         Artist GetById(int artistID);
    }
}