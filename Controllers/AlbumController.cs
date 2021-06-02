using System;
using System.Collections.Generic;
using Billify.Dao;
using Billify.Models;

namespace Billify.Controllers
{
    public class AlbumController
    {
        private AlbumDao _albumDao = new AlbumDao();

        public List<Album> Index()
        {
            return _albumDao.Albums;
        }
        public void Store(Album album)
        {
            try
            {
                album.Id = (_albumDao.Albums.Count) + 1;
                _albumDao.Create(album);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}