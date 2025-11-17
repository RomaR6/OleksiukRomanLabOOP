using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Stitch_Oleksiuk
{
    public partial class Polotno : UserControl
    {
        public Polotno()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public Color ActiveColor = Color.Red;
        public string protokol = "";
        public int symm = 0;
        public int CWid, CHig;
        int CrossWidth = 8;

        void AddCross(int x, int y)
        {
            int X = x / CrossWidth * CrossWidth;
            int Y = y / CrossWidth * CrossWidth;

            for (int p = 0; p < protokol.Length; p += 26)
            {
                if ((X == int.Parse(protokol.Substring(p, 5))) && (Y == int.Parse(protokol.Substring(p + 5, 5))))
                {
                    protokol = protokol.Remove(p, 26);
                    break;
                }
            }

            protokol += string.Format("{0,5}{1,5}{2,4}{3,4}{4,4}{5,4}",
                X, Y,
                ActiveColor.A.ToString("D4"),
                ActiveColor.R.ToString("D4"),
                ActiveColor.G.ToString("D4"),
                ActiveColor.B.ToString("D4"));
        }

        private void PolotnoMouseClick(object sender, MouseEventArgs e)
        {
            int cX = CWid * CrossWidth;
            int cY = CHig * CrossWidth;

            int x1 = e.X;
            int y1 = e.Y;

            int x2 = cX - e.X - 1;
            int y2 = cY - e.Y - 1;

            AddCross(x1, y1);

            switch (symm)
            {
                case 0:
                    break;
                case 1:
                    AddCross(x2, y1);
                    break;
                case 2:
                    AddCross(x1, y2);
                    break;
                case 3:
                    AddCross(x2, y1);
                    AddCross(x1, y2);
                    AddCross(x2, y2);
                    break;
                case 4:
                    AddCross(x2, y2);
                    break;
            }

            Invalidate();
        }

        private void PolotnoPaint(object sender, PaintEventArgs e)
        {
            SolidBrush B = new SolidBrush(ActiveColor);

            for (int x = 0; x < protokol.Length; x += 26)
            {
                try
                {
                    B.Color = Color.FromArgb(
                        int.Parse(protokol.Substring(x + 10, 4)),
                        int.Parse(protokol.Substring(x + 14, 4)),
                        int.Parse(protokol.Substring(x + 18, 4)),
                        int.Parse(protokol.Substring(x + 22, 4))
                    );

                    e.Graphics.FillRectangle(B,
                        int.Parse(protokol.Substring(x, 5)),
                        int.Parse(protokol.Substring(x + 5, 5)),
                        CrossWidth - 1, CrossWidth - 1);
                }
                catch
                {
                }
            }
        }

        public void Clear()
        {
            protokol = "";
            Invalidate();
        }

        private void PolotnoSizeChanged(object sender, EventArgs e)
        {
            CWid = Width / CrossWidth;
            CHig = Height / CrossWidth;
        }
    }
}