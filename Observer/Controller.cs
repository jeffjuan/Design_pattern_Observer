using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Controller
    {
        public event EventHandler ControllerEventHandler;

        public void Notify(ControllerEventArgs e)
        {
            ControllerEventHandler(this, e);
        }
    }
}