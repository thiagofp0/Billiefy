using System;
using System.Collections.Generic;
using Billify.Dao;
using Billify.Models;

namespace Billify.Controllers
{
    public class AlbumController
    {
        private AlbumDao _albumDao = new AlbumDao();
        private ArtistController _artistController = new ArtistController();
        private Album _album = new Album();

        public List<Album> Index()
        {
            return _albumDao.Albums;
        }
        public void Store(Album album, Artist artist)
        {
            try
            {
                if (_artistController.VerifyArtist(artist.Name) != 0)
                {
                    album.ArtistId = _artistController.VerifyArtist(artist.Name);
                }
                else
                {
                    _artistController.Store(artist);
                    album.ArtistId = _artistController.VerifyArtist(artist.Name);
                }

                _albumDao.Create(album);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Album GetByTitle(string album)
        {
            try
            {
                return _albumDao.GetByTitle(album);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Album> GetByReleaseYear(int year)
        {
            try
            {
                return _albumDao.GetByReleaseYear(year);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Album> GetByArtist(int artistId)
        {
            try
            {
                return _albumDao.GetByArtist(artistId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}