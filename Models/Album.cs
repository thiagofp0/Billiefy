namespace Billiefy.Models
{
    public class Album
    {
        private int _id;
        private string _title;
        private string _artist;
        private int _releaseYear;
        

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

        public string Artist
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