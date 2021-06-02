using System;
using System.Collections.Generic;
using System.Linq;
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
                artist.Id = (_artists.Count) + 1;
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
            foreach (var value in _artists)
            {
                if (artistId == value.Id)
                {
                    return value;
                }
            }
            return null;
           
        }
    }
}