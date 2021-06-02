using System;
using System.Collections.Generic;
using Billiefy.Models;

namespace Billiefy.Dao
{
    public class SongDao
    {
        public static List<Song> _songs = new List<Song>();
        public void Create(Song song)
        {
            try
            {
                _songs.Add(song);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Song> GetByAlbumId(int albumId)
        {
            List<Song> results = new List<Song>();
            try
            {
                foreach (var value in _songs)
                {
                    if (value.AlbumId == albumId)
                    {
                        results.Add(value);
                    }
                }

                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}