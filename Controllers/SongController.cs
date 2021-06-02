using System;
using System.Collections.Generic;
using Billiefy.Dao;
using Billiefy.Models;

namespace Billiefy.Controllers
{
    public class SongController
    {
        private SongDao _songDao = new SongDao();

        public List<Song> Index()
        {
            return SongDao._songs;
        }
        public void Store(Song song)
        {
            try
            {
                _songDao.Create(song);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Song> GetByAlbumId(int albumId)
        {
            try
            {
                return _songDao.GetByAlbumId(albumId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}