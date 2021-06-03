using System;
using System.Collections.Generic;
using Billiefy.Controllers;
using Billiefy.Models;

namespace Billiefy.Views
{
    public class ViewPlaylist
    {
        private PlaylistController _playlistController = new PlaylistController();
        private ViewSong _viewSong = new ViewSong();
        public void Create()
        {
            List<Song> playlist = _playlistController.Create();
            Console.WriteLine("Aqui está a sua playlist:");
            foreach (var song in playlist)
            {
                _viewSong.Show(song);
            }
            
        }
    }
}