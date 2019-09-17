
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("artists")]
    public class Artist
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("artist_name")]
        public string ArtistName { get; set; }
        [Column("album_name")]
        public string AlbumName { get; set; }
        [Column("image_url")]
        public string ImageURL { get; set; }
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
        [Column("price")]
        public Decimal Price { get; set; }
        [Column("sample_url")]
        public string SampleURL { get; set; }
    }
}