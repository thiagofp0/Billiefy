using System;
using System.Collections.Generic;
using Billify.Models;

namespace Billify.Dao
{
    public class AlbumDao
    {
        private List<Album> _albums;
        
        public List<Album> Albums
        {
            get => _albums;
            set => _albums = value;
        }
        public void Create(Album album)
        {
            try
            {
                _albums.Add(album);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}