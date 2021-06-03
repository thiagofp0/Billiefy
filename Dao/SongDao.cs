using System;
using System.Collections.Generic;
using Billiefy.Controllers;
using Billiefy.Models;

namespace Billiefy.Dao
{
    public class SongDao
    {
        public static List<Song> _songs = new List<Song>();
        private AlbumController _albumController = new AlbumController();
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

        public List<Song> GetByTitle(string title)
        {
            List<Song> results = new List<Song>();
            try
            {
                foreach (var value in _songs)
                {
                    if (value.Title.Equals(title))
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

        public List<Song> GetByArtist(string artist)
        {
            List<Song> results = new List<Song>();
            List<Album> albums = new List<Album>();
            try
            {
                albums = _albumController.GetByArtist(artist);
                Console.WriteLine(albums.Count);
                foreach (var value in albums)
                {
                    foreach (var key in _songs)
                    {
                        if (value.Id == key.AlbumId)
                        {
                            results.Add(key);
                        }
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