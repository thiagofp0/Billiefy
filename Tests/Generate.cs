using System;
using Billiefy.Controllers;
using Billiefy.Models;
using Billiefy.Views;

namespace Billiefy.Tests
{
    public class Generate
    {
        public static void GenerateAlbum(ref AlbumController _albumController, ref SongController _songController )
        {
            Album album = new Album();
            
            album.Title = "Até Eu Envelhecer";
            album.ReleaseYear = 2006;
            album.Artist = "Resgate";
            
            album = _albumController.Store(album);
        
            Song song = new Song();
            
            song.Title = "Astronauta";
            song.Duration = 4.5;
            song.IsFavorite = true; 
            song.AlbumId = album.Id;
            _songController.Store(song);
            
            song.Title = "Teu Sinal";
            song.Duration = 4.8;
            song.IsFavorite = false; 
            song.AlbumId = album.Id;
            _songController.Store(song);
            
            song.Title = "A saída";
            song.Duration = 3.5;
            song.IsFavorite = true; 
            song.AlbumId = album.Id;
            _songController.Store(song);
            
            song.Title = "Meus pés";
            song.Duration = 4.2;
            song.IsFavorite = false; 
            song.AlbumId = album.Id;
            _songController.Store(song);
            
            song.Title = "Te encontrar";
            song.Duration = 4.5;
            song.IsFavorite = true; 
            song.AlbumId = album.Id;
            _songController.Store(song);
        }
    }
}