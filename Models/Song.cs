using System;

namespace Billify.Models
{
    public class Song
    {
        private int _id;
        private string _title;
        private float _duration;
        private Boolean _isFavorite;
        
        public Song(){}
        public Song(string title, float duration, DateTime releaseDate, bool isFavorite, Artist bandName)
        {
            this._title = title;
            this._duration = duration;
            this._isFavorite = isFavorite;
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
        
    }
}