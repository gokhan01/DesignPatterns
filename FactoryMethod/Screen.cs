using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Product class
    /// </summary>
    public abstract class Screen
    {
        public abstract void Draw();
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class WinScreen : Screen
    {
        public override void Draw()
        {
            Console.WriteLine("Windows Ekranı");
        }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class WebScreen : Screen
    {
        public override void Draw()
        {
            Console.WriteLine("Web Ekranı");
        }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class MobileScreen : Screen
    {
        public override void Draw()
        {
            Console.WriteLine("Mobile Ekranı");
        }
    }
}
