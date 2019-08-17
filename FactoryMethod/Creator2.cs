using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    abstract class Creator2
    {
        public abstract Screen ScreenFactory();
    }

    class WinScreenCreator : Creator2
    {
        public override Screen ScreenFactory()
        {
            return new WinScreen();
        }
    }

    class WebScreenCreator : Creator2
    {
        public override Screen ScreenFactory()
        {
            return new WebScreen();
        }
    }

    class MobileScreenCreator : Creator2
    {
        public override Screen ScreenFactory()
        {
            return new MobileScreen();
        }
    }
}
