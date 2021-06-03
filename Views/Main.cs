using System;
using Billiefy.Util;

namespace Billiefy.Views
{
    public class Main
    {
        private ViewAlbum _viewAlbum = new ViewAlbum();
        private ViewSong _viewSong = new ViewSong();
        private ViewPlaylist _viewPlaylist = new ViewPlaylist();

        public void MainMenu()
        {
            //_viewAlbum.Test();
            int option = 0; //Opção selecionada no menu.
            while (option != 5)
            {
                Console.WriteLine("------------------ Billiefy --------------------");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine(
                
                    "1. Novo álbum \n" +
                    "2. Pesquisar álbuns \n" +
                    "3. Pesquisar Música \n" +
                    "4. Gerar playlist \n" +
                    "5. Sair"
                
                );

                option = Entries.GetInt("");
                SwitchOption(option);
            }
        }
        
        public void SwitchOption(int option)
        {
            try
            {
                switch (option)
                {
                    case 1:
                        _viewAlbum.Create();
                        break;
                    case 2:
                        _viewAlbum.Search();
                        break;
                    case 3:
                        _viewSong.Search();
                        break;
                    case 4:
                        _viewPlaylist.Create();
                        break;
                    case 5:
                        Console.WriteLine("Tchau, Billie!");
                        return;
                    default:
                        Console.WriteLine("Oops! Opção inválida!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}