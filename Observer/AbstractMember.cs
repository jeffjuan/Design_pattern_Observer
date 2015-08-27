using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public abstract class AbstractMember
    {
        public string Name;
        public int LifeValue;
        public int Grade;
        public bool IsAlive;

        public abstract void CopyThat(object sender, EventArgs e);
    }
}