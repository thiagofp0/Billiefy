namespace Billiefy.Models
{
    public class Song
    {
        private int _id;
        private string _title;
        private float _duration;
        private bool _isFavorite;
        private int _albumId;

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

        public float Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public bool IsFavorite
        {
            get => _isFavorite;
            set => _isFavorite = value;
        }

        public int AlbumId
        {
            get => _albumId;
            set => _albumId = value;
        }
    }
}