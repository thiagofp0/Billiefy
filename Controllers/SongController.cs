using System;
using System.Collections.Generic;
using Billify.Dao;
using Billify.Models;

namespace Billify.Controllers
{
    public class SongController
    {
        private SongDao _songDao = new SongDao();
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

        public Song GetByTitle(string song)
        {
            try
            {
                return _songDao.GetByTitle(song);
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