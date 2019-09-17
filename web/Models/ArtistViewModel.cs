using System;
using Newtonsoft.Json;

namespace Models {
    public class ArtistViewModel
    {
        public int ID { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string ImageURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Decimal Price { get; set; }
        public string SampleURL { get; set; }
    }
}