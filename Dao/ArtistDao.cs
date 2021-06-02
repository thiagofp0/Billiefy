using System;
using System.Collections.Generic;
using Billify.Models;

namespace Billify.Dao
{
    public class ArtistDao
    {
        private List<Artist> _artists = new List<Artist>();

        public List<Artist> Artists
        {
            get => _artists;
            set => _artists = value;
        }
        
        public void Create(Artist artist)
        {
            try
            {
                _artists.Add(artist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Artist GetById(int artistId)
        {
            try
            {
                return _artists[artistId];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}