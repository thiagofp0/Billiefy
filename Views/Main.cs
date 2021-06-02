using System;

namespace Billiefy.Views
{
    public class Main
    {
        private ViewAlbum _viewAlbum = new ViewAlbum();

        public void MainMenu()
        {
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

                option = int.Parse(Console.ReadLine()!);
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