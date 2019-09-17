using System.Linq;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using api.Models;
using System.Data;
using System.Data.SqlClient;

namespace api.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly AppSetting _config;
        public ArtistRepository(AppSetting config)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.ConnectionStrings.sqlserverconn);
            }
        }

        public void Store(Artist newArtist)
        {
            try
            {
                int rowAffected =0;
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    string qry = "";
                    DynamicParameters param = new DynamicParameters();
                    if (newArtist.ID > 0)
                    {
                        qry = @"update artists 
                set artist_name=@artistName,
                    album_name=@albumName,
                    image_url=@imageUrl,
                    release_date=@releaseDate,
                    price=@price,
                    sample_url=@sampleUrl
                where id=@id";
                        param.Add("@id", newArtist.ID);
                    }
                    else
                    {
                        //insert new data
                        qry = @"insert into artists (artist_name, album_name, image_url, release_date, price, sample_url)
                    values (@artistName, @albumName, @imageUrl, @releaseDate, @price, @sampleUrl)";

                    }
                    param.Add("@artistName", newArtist.ArtistName);
                    param.Add("@albumName", newArtist.AlbumName);
                    param.Add("@imageUrl", newArtist.ImageURL);
                    param.Add("@releaseDate", newArtist.ReleaseDate);
                    param.Add("@price", newArtist.Price);
                    param.Add("@sampleUrl", newArtist.SampleURL);

                    rowAffected = con.Execute(qry, param);
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public void Delete(int artistID)
        {
            try
            {
                
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
                using(IDbConnection con = Connection){
                    con.Open();
                    var qry = "select id, artist_name, image_url, album_name, release_date, price, sample_url from artists";
                    var result = con.Query<Artist>(qry);
                    return result.ToList();
                }
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
                using(IDbConnection con = Connection)
                {
                    var qry = @"select id, artist_name, album_name, image_url, release_date, price, sample_url from artists where id =@id";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", artistID);
                    var result = con.QueryFirstOrDefault<Artist>(qry, param);
                    return result;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}