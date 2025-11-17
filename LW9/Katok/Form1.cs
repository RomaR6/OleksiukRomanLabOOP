using System;
using System.Drawing;
using System.Windows.Forms;

namespace Katok
{
    
    public partial class Form1 : Form
    {
        
        private katok_oleksiuk K;

        public Form1()
        {
            InitializeComponent();


            Random R = new Random();

            
            K = new katok_oleksiuk(R.Next(3, 8));

            K.Parent = this;
            
            K.Size = this.ClientSize;


            K.Anchor = (AnchorStyles.Bottom |
                         AnchorStyles.Left |
                         AnchorStyles.Right |
                         AnchorStyles.Top);
        }
    }
}