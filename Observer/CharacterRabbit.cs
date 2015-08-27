using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer
{
    public class CharacterRabbit : AbstractMember
    {
        public CharacterRabbit(Controller controller)
        {
            controller.ControllerEventHandler += new EventHandler(this.CopyThat);
            Name = "兔兔";
            LifeValue = 2000;
            Grade = 1;
            IsAlive = true;
        }

        public override void CopyThat(object sender, EventArgs e)
        {
            string who = (e as ControllerEventArgs).Who;

            if (this.IsAlive)
            {
                if (who != this.Name)
                {
                    MessageBox.Show("兔兔收到~~~前往救援中!!");
                }
            }
        }
    }
}