using System;
using System.Collections.Generic;
using System.ComponentModel;
using Billify.Models;

namespace Billify.Dao
{
    public class SongDao
    {
        private List<Song> _songs = new List<Song>();
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

        public Song GetByTitle(string song)
        {
            try
            {
                foreach (var value in _songs)
                {
                    if (song.Equals(value.Title))
                    {
                        return value;
                    }
                }

                return null;
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
                    if (albumId == value.AlbumId)
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