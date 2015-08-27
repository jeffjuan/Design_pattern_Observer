using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer
{
    public partial class Form1 : Form
    {
        private Controller ControllerEventHandler = new Controller();
        private ControllerEventArgs ControllerEventArgs = new ControllerEventArgs();
        private CharacterJames James;
        private CharacterBear Bear;
        private CharacterBread Bread;
        private CharacterRabbit Rabbit;
        private List<AbstractMember> MemberList = new List<AbstractMember>();

        public Form1()
        {
            InitializeComponent();
            //腳色加入清單
            MemberList.Add(James = new CharacterJames(ControllerEventHandler));
            MemberList.Add(Bear = new CharacterBear(ControllerEventHandler));
            MemberList.Add(Bread = new CharacterBread(ControllerEventHandler));
            MemberList.Add(Rabbit = new CharacterRabbit(ControllerEventHandler));
            timer1.Start();
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
        }

        //更新生命值
        private void timer1_Tick(object sender, EventArgs e)
        {
            //James
            LifeValTxtA.Text = James.LifeValue.ToString();
            GradeTxtA.Text = James.Grade.ToString();
            //Bread
            LifeValTxtB.Text = Bread.LifeValue.ToString();
            GradeTxtB.Text = Bread.Grade.ToString();
            //Rabbit
            LifeValTxtC.Text = Rabbit.LifeValue.ToString();
            GradeTxtC.Text = Rabbit.Grade.ToString();
            //Bear
            LifeValTxtD.Text = Bear.LifeValue.ToString();
            GradeTxtD.Text = Bear.Grade.ToString();
        }

        private void AttactBtn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int x = r.Next(0, 4);           //隨機指定被攻擊的腳色
            CheckLife(MemberList[x]);
        }

        //檢查生命值與扣點數
        protected void CheckLife(AbstractMember m)
        {
            // 還活著
            if (m.IsAlive != false)
            {
                if (m.Grade >= 0)
                {
                    if (m.LifeValue == 0)
                    {
                        m.Grade -= 1;       //扣等級點數 1
                        m.LifeValue = 2000; //補充生命值 2000
                    }
                    m.LifeValue -= 1000;   //扣生命點數 1000
                    if (m.LifeValue == 0 && m.Grade == 0)
                    {
                        m.IsAlive = false;
                        ResultTxt.Text = m.Name + " 已經掛了~";
                    }
                    else
                    {
                        ResultTxt.Text = "我是" + m.Name + "，我被攻擊了，" + GetHelperList(m) + "快來救我，我的生命值只剩餘" + m.LifeValue +
                         "；等級剩餘 " + m.Grade;
                        CallHelp(m); //通知所有夥伴來救援
                    }
                }
            }
            else
            {
                ResultTxt.Text = m.Name + " 已經掛了~";
            }
        }

        //通知所有夥伴來救援(觀察者)
        protected void CallHelp(AbstractMember m)
        {
            //加入參數值
            ControllerEventArgs.Who = m.Name;

            //通知所有訂閱者
            ControllerEventHandler.Notify(ControllerEventArgs);
        }

        //找出未被攻擊的夥伴請單
        protected string GetHelperList(AbstractMember m)
        {
            string tmpNames = "";
            IEnumerable<AbstractMember> query =
               from member in MemberList
               where member.Name != m.Name
               select member;

            foreach (var list in query)
            {
                tmpNames += list.Name + "，";
            }

            return tmpNames;
        }
    }
}