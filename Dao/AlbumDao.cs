using System;
using System.Collections.Generic;
using Billiefy.Models;

namespace Billiefy.Dao
{
    public class AlbumDao
    {
        public static List<Album> _albums = new List<Album>();

        public List<Album> Albums
        {
            get => _albums;
            set => _albums = value;
        }

        public Album Create(Album album)
        {
            try
            {
                album.Id = (_albums.Count) + 1;
                _albums.Add(album);
                return _albums[_albums.Count - 1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        

        public List<Album> GetByTitle(string title)
        {
            List<Album> results = new List<Album>();
            try
            {
                foreach (var value in _albums)
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

        public List<Album> GetByRealeseYear(int year)
        {
            List<Album> results = new List<Album>();
            try
            {
                foreach (var value in _albums)
                {
                    if (value.ReleaseYear == year)
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

        public List<Album> GetByArtist(string artist)
        {
            List<Album> results = new List<Album>();
            try
            {
                foreach (var value in _albums)
                {
                    if (value.Artist.Equals(artist))
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