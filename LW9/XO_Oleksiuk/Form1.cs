using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_Oleksiuk
{
    public partial class Form1 : Form
    {
        int CrossCount = 0, ZeroCount = 0;

        public Form1()
        {
            InitializeComponent();
            
            pole1.OnFinish += new FinishEventHandler(Finish);
        }

        
        void Finish(char Winner)
        {
            switch (Winner)
            {
                case 'X':
                    CrossCount++;
                    label1.Text = Convert.ToString(CrossCount);
                    MessageBox.Show("Ви перемогли!", "Кінець гри");
                    break;
                case 'O':
                    ZeroCount++;
                    label2.Text = Convert.ToString(ZeroCount);
                    MessageBox.Show("Комп'ютер переміг!", "Кінець гри");
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            pole1.Clear();
        }
    }
}