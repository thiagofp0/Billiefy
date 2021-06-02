using System;
using Billiefy.Views;

namespace Billiefy
{
    class Program
    {
        static void Main(string[] args)
        {
            Main app = new Main();
            try
            {
                app.MainMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
