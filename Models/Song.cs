using System;

namespace Billify.Models
{
    public class Song
    {
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