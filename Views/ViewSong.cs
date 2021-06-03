using System;
using System.Collections.Generic;
using Billiefy.Controllers;
using Billiefy.Models;
using Billiefy.Util;

namespace Billiefy.Views
{
    public class ViewSong
    {
        private SongController _songController = new SongController();
        public void Create(int albumId)
        {
            Song song = new Song();
            int aux;
            
            song.Title = Entries.GetString("Qual o nome da música?");
            song.Duration = Entries.GetDouble("Qual a duração da música?");
            aux = Entries.GetInt("Essa música é favorita? \n1. Sim \n2. Não");
            song.IsFavorite = aux == 1; // Operador ternário
            song.AlbumId = albumId;
            _songController.Store(song);
        }

        public void Search()
        {
            Song song = new Song();
            List<Song> songs = new List<Song>();
            int option;
            
            option = Entries.GetInt("Procurar música por: \n1. Título \n2. Banda \n3. Voltar");

            switch (option)
            {
                case 1:
                    song.Title = Entries.GetString("Qual o título da música?");
                    songs = _songController.GetByTitle(song.Title);
                    ShowResults(songs);
                    break;
                case 2:
                    string artist = Entries.GetString("Qual é a banda?");
                    songs = _songController.GetByArtist(artist);
                    ShowResults(songs);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Oops! Opção Inválida!");
                    break;
            }
        }
        public void Show(Song song)
        {
            Console.Write(song.Title + " --------------- " + Math.Round(song.Duration, 2) + " minutos  ");
            Console.WriteLine(song.IsFavorite ? "Favorita" : "Não-Favorita");
        }

        private void ShowResults(List<Song> songs)
        {
            Console.WriteLine("");
            Console.WriteLine("Músicas encontradas: ");
            foreach (var value in songs)
            {
                Show(value);
            }
            Console.WriteLine("");
        }
    }
}