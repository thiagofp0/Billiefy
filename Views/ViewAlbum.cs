using System;
using System.Collections.Generic;
using Billiefy.Controllers;
using Billiefy.Models;
using Billiefy.Tests;
using Billiefy.Util;

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
                Generate.GenerateAlbum(ref _albumController, ref _songController);
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
            int aux=0;

            album.Title = Entries.GetString("Qual é o título do álbum?");
            album.ReleaseYear = Entries.GetYear("Qual o ano de lançamento deste álbum?");
            album.Artist = Entries.GetString("Qual o nome da banda?");
            album = _albumController.Store(album);
            
            Console.WriteLine("\n");
            Console.WriteLine("Adicionando as músicas do álbum.");
            
            do
            {
                _viewSong.Create(album.Id);
                aux = Entries.GetInt("Pronto! Música adicionada! Adicionar outra? \n1. Sim \n2. Não \n");
                while (aux != 1 && aux != 2)
                {
                    Console.WriteLine("Valor digitado é inválido! Digite uma opção válida: ");
                    aux = Entries.GetInt("Adicionar outra música? \n1. Sim \n2. Não \n");
                }
            } while (aux == 1);
        }
        
        public void Search()
        {
            Album album = new Album();
            List<Album> albums = new List<Album>();
            int option;
            option = Entries.GetInt("Procurar álbum por: \n1. Título \n2. Ano de lançamento \n3. Banda \n");
            
            switch (option)
            {
                case 1:
                    album.Title = Entries.GetString("Qual é o título do álbum?");
                    albums = _albumController.GetByTitle(album.Title);
                    ShowResults(albums);
                    break;
                case 2:
                    album.ReleaseYear = Entries.GetYear("Qual o ano de lançamento?");
                    albums = _albumController.GetByReleaseYear(album.ReleaseYear);
                    ShowResults(albums);
                    break;
                case 3:
                    album.Artist = Entries.GetString("Qual o nome da banda?");
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
            if (albums.Count == 0)
            {
                Console.WriteLine("Nenhum álbum foi encontrado... "); 
            }
            else
            {
                Console.WriteLine("Álbuns encontrados: ");
                foreach (var value in albums)
                {
                    Show(value);
                }
                Console.WriteLine("");
            }
        }
    }
}