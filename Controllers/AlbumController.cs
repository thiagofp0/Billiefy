using System;
using System.Collections.Generic;
using Billiefy.Dao;
using Billiefy.Models;

namespace Billiefy.Controllers
{
    public class AlbumController
    {
        private AlbumDao _albumDao = new AlbumDao();

        public Album Store(Album album)
        {
            try
            {
                return _albumDao.Create(album);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        

        public Album GetByTitle(string title)
        {
            try
            {
                return _albumDao.GetByTitle(title);
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
                return _albumDao.GetByRealeseYear(year);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Album> GetByArtist(string artist)
        {
            try
            {
                return _albumDao.GetByArtist(artist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}