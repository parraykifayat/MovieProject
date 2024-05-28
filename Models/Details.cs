using System.IO;

namespace MovieProject.Models
{
    public class Details
    {
        public int Rank { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Rating { get; set; }
        public string Id { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public string BigImage { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public string TrailerEmbedLink { get; set; }
        public string TrailerYoutubeId { get; set; }
        public List<string> Genre { get; set; }
        public List<string> Director { get; set; }
        public List<string> Writers { get; set; }
        public string Imdbid { get; set; }
        public string ImdbLink { get; set; }
    }
}
