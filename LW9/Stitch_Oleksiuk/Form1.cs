using Stitch_Oleksiuk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Stitch_Oleksiuk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            RBNoSym.Checked = true;
        }

        void Button1Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                
                polotno1.ActiveColor = colorDialog1.Color;
            }
        }

        void RBGorizCheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 1; 
        }

        void RBWertCheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 2; 
        }
        void RBDwiCheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 3; 
        }

        void RBCentrCheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 4; 
        }

        void RBNoSymCheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 0; 
        }

        void Button2Click(object sender, EventArgs e)
        {
            polotno1.Clear(); 
        }
    }
}