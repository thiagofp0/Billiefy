namespace Billify.Models
{
    public class Album
    {
        private string _title;
        private Artist _artist;
        private int _releaseYear;

        public Album(string title, Artist artist, int releaseYear)
        {
            _title = title;
            _artist = artist;
            _releaseYear = releaseYear;
        }
        
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public Artist Artist
        {
            get => _artist;
            set => _artist = value;
        }

        public int ReleaseYear
        {
            get => _releaseYear;
            set => _releaseYear = value;
        }
    }
}