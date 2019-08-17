using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageGeneratorProxy proxy1 = new ImageGeneratorProxy("Resimler/devops.jpeg");

            ImageGeneratorProxy proxy2 = new ImageGeneratorProxy("Resimler/iskender.jpg");

            proxy1.ShowImage();
            proxy2.ShowImage();
            proxy1.ShowImage();

            Console.ReadKey();
        }
    }
}
