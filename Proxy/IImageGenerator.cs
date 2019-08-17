using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    //Subject
    interface IImageGenerator
    {
        void ShowImage();
    }

    //Real Subject
    class ImageGenerator : IImageGenerator
    {
        private string _fullPath;
        public ImageGenerator(string fullPath)
        {
            _fullPath = fullPath;
        }
        public void ShowImage()
        {
            Console.WriteLine("{0} gösteriliyor.", _fullPath);
        }
    }

    //Proxy
    class ImageGeneratorProxy : IImageGenerator
    {
        private ImageGenerator _generator;
        private string _fullPath;
        public ImageGeneratorProxy(string fullPath)
        {
            _fullPath = fullPath;
        }

        public void ShowImage()
        {
            if (_generator == null)
            {
                //işlem gerçekleşene kadar client tarafında geçici bir görsel gösterilebilir(farklı thread)
                _generator = new ImageGenerator(_fullPath);
            }

            _generator.ShowImage();
        }
    }
}
