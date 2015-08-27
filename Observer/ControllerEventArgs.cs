using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class ControllerEventArgs : EventArgs
    {
        public string Who { get; set; }

        public bool IsAlive { get; set; }
    }
}