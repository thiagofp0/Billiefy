using System.Collections.Generic;

namespace Billify.Models
{
    public class Album
    {
        private int _id;
        private string _title;
        private int _artistId;
        

        private int _releaseYear;

        public Album(){}
        public Album(string title, int artist, int releaseYear)
        {
            _title = title;
            _artistId = artist;
            _releaseYear = releaseYear;
        }
        
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public int ArtistId
        {
            get => _artistId;
            set => _artistId = value;
        }

        public int ReleaseYear
        {
            get => _releaseYear;
            set => _releaseYear = value;
        }
        
    }
}