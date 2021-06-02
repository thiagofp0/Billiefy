using System;
using System.Collections.Generic;
using Billify.Models;

namespace Billify.Dao
{
    public class AlbumDao
    {
        private List<Album> _albums = new List<Album>();
        
        public List<Album> Albums
        {
            get => _albums;
            set => _albums = value;
        }
        public int Create(Album album)
        {
            try
            {
                album.Id = (_albums.Count) + 1;
                _albums.Add(album);
                return album.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Album GetByTitle(string album)
        {
            foreach (var value in _albums)
            {
                if (album.Equals(value.Title))
                {
                    return value;
                }
            }

            return null;
        }

        public List<Album> GetByReleaseYear(int year)
        {
            List<Album> results = new List<Album>();
            try
            {
                foreach (var value in _albums)
                {
                    if (year == value.ReleaseYear)
                    {
                        results.Add(value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return results;
        }

        public List<Album> GetByArtist(int artistId)
        {
            List<Album> results = new List<Album>();
            try
            {
                foreach (var value in _albums)
                {
                    if (artistId == value.Id)
                    {
                        results.Add(value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return results;
        }
    }
}