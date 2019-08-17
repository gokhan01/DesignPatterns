using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    enum ScreenModel
    {
        Windows,
        Web,
        Mobile
    }

    /// <summary>
    /// Creator Class
    /// </summary>
    class Creator
    {
        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="screenModel">Ekran Tipi</param>
        /// <returns>Asıl ürünü taşıyan referans</returns>
        public Screen ScreenFactory(ScreenModel screenModel)
        {
            Screen screen = null;

            switch (screenModel)
            {
                case ScreenModel.Windows:
                    screen = new WinScreen();
                    break;
                case ScreenModel.Web:
                    screen = new WebScreen();
                    break;
                case ScreenModel.Mobile:
                    screen = new MobileScreen();
                    break;
                default:
                    break;
            }

            return screen;
        }
    }
}
