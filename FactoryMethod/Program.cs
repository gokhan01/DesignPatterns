using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new Creator();
            Screen screen = creator.ScreenFactory(ScreenModel.Windows);
            screen.Draw();

            Creator2[] creators =
            {
                new WinScreenCreator(),
                new WebScreenCreator(),
                new MobileScreenCreator()
            };

            foreach (var item in creators)
            {
                Screen screen2 = item.ScreenFactory();
                screen2.Draw();
            }

            Console.ReadKey();
        }
    }
}
