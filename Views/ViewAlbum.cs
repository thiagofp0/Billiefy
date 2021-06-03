using System;
using System.Collections.Generic;
using Billiefy.Controllers;
using Billiefy.Models;
using Billiefy.Tests;

namespace Billiefy.Views
{
    public class ViewAlbum
    {
        private AlbumController _albumController = new AlbumController();
        private SongController _songController = new SongController();
        private ViewSong _viewSong = new ViewSong();

        public void Test()
        {
            try
            {
                Generate generate = new Generate();
                generate.GenerateAlbum(ref _albumController, ref _songController);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create()
        {
            Album album = new Album();
            int aux;
            
            Console.WriteLine("Qual é o título do álbum?");
            album.Title = Console.ReadLine();
            
            Console.WriteLine("Qual o ano de lançamento deste álbum?");
            album.ReleaseYear = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Qual o nome da banda?");
            album.Artist = Console.ReadLine();
            
            album = _albumController.Store(album);
            
            Console.WriteLine("\n");
            Console.WriteLine("Adicionando as músicas do álbum.");

            do
            {
                _viewSong.Create(album.Id);
                Console.WriteLine(
                    "Pronto! Música adicionada! Adicionar outra? \n" +
                    "1. Sim \n" +
                    "2. Não \n"
                );
                aux = int.Parse(Console.ReadLine()!);
            } while (aux != 2);
        }
        
        public void Search()
        {
            Album album = new Album();
            List<Album> albums = new List<Album>();
            int option;
            
            Console.WriteLine("Procurar álbum por:");
            Console.WriteLine(
                "1. Título \n" +
                "2. Ano de lançamento \n" +
                "3. Banda \n"
            );
            option = int.Parse(Console.ReadLine()!);
            
            switch (option)
            {
                case 1:
                    Console.WriteLine("Qual é o título do álbum?");
                    album.Title = Console.ReadLine();
                    album = _albumController.GetByTitle(album.Title);
                    Show(album);
                    break;
                case 2:
                    Console.WriteLine("Qual o ano de lançamento?");
                    album.ReleaseYear = int.Parse(Console.ReadLine()!);
                    albums = _albumController.GetByReleaseYear(album.ReleaseYear);
                    ShowResults(albums);
                    break;
                case 3:
                    Console.WriteLine("Qual o nome da banda?");
                    album.Artist = Console.ReadLine();
                    albums = _albumController.GetByArtist(album.Artist);
                    ShowResults(albums);
                    break;
                default:
                    Console.WriteLine("Oops! Opção Inválida!");
                    break;
            }
        }

        private void Show(Album album)
        {
            List<Song> songs = new List<Song>();
            
            //Mostra as informações do álbum
            Console.WriteLine("");
            Console.WriteLine("Aqui está o seu Álbum! ");
            Console.WriteLine("Nome do álbum: " + album.Title);
            Console.WriteLine("Ano de lançamento: " + album.ReleaseYear);
            Console.WriteLine("Banda: " + album.Artist);
            Console.WriteLine("Músicas: ");
            
            //Mostra as músicas do álbum
            songs = _songController.GetByAlbumId(album.Id);
            foreach (var value in songs)
            {
                _viewSong.Show(value);
            }
            Console.WriteLine("\n");
        }

        private void ShowResults(List<Album> albums)
        {
            foreach (var value in albums)
            {
                Show(value);
            }
        }
    }
}