using System;
using System.Collections.Generic;
using Billiefy.Controllers;
using Billiefy.Models;

namespace Billiefy.Views
{
    public class ViewSong
    {
        private SongController _songController = new SongController();
        public void Create(int albumId)
        {
            Song song = new Song();
            int aux;
            
            Console.WriteLine("Qual o nome da música?");
            song.Title = Console.ReadLine();
                
            Console.WriteLine("Qual a duração da música?");
            song.Duration = float.Parse(Console.ReadLine()!);
            
            Console.WriteLine(
                "Essa música é favorita? \n" +
                "1. Sim \n" +
                "2. Não"
            );
            aux = int.Parse(Console.ReadLine()!);
            song.IsFavorite = aux == 1; // Operador ternário
            song.AlbumId = albumId;
            _songController.Store(song);
        }

        public void Search()
        {
            Song song = new Song();
            List<Song> songs = new List<Song>();
            int option;
            
            Console.WriteLine("Procurar música por: ");
            Console.WriteLine(
                    "1. Título \n" +
                    "2. Banda \n" +
                    "3. Voltar"
                );
            option = int.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Qual o título da música?");
                    song.Title = Console.ReadLine();
                    songs = _songController.GetByTitle(song.Title);
                    ShowResults(songs);
                    break;
                case 2:
                    Console.WriteLine("Qual é a banda?");
                    string artist = Console.ReadLine();
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
            Console.Write(song.Title + " --------------- " + song.Duration + " minutos  ");
            Console.WriteLine(song.IsFavorite ? "Favorita" : "Não-Favorita");
        }

        private void ShowResults(List<Song> songs)
        {
            Console.WriteLine("");
            Console.WriteLine("Musicas encontradas: ");
            foreach (var value in songs)
            {
                Show(value);
            }
            Console.WriteLine("");
        }
    }
}