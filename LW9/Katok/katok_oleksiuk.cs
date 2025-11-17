using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Katok
{
    
    public partial class katok_oleksiuk : UserControl
    {
        
        public Point[] P;
        int[] dx;
        int[] dy;
        Random R = new Random();
        int n;

        
        public katok_oleksiuk(int N)
        {
            InitializeComponent(); 
            
            this.DoubleBuffered = true;

            n = N;
            P = new Point[N];
            dx = new int[N];
            dy = new int[N];

            int w = Math.Max(Width, 100);
            int h = Math.Max(Height, 100);

            
            for (int i = 0; i < N; i++)
            {
                P[i].X = R.Next(w);
                P[i].Y = R.Next(h);
                do { dx[i] = R.Next(6) - 3; } while (dx[i] == 0);
                do { dy[i] = R.Next(6) - 3; } while (dy[i] == 0);
            }

            
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.KatokPaint);

            
            timer1.Start();
        }

        
        private void Timer1Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                P[i].X += dx[i];
                P[i].Y += dy[i];

                if ((P[i].X < 3) || (P[i].X > this.Width - 3))
                    dx[i] = -dx[i];
                if ((P[i].Y < 3) || (P[i].Y > this.Height - 3))
                    dy[i] = -dy[i];

           
                if (P[i].X > this.Width - 3) P[i].X = this.Width - 3;
                if (P[i].Y > this.Height - 3) P[i].Y = this.Height - 3;
                if (P[i].X < 3) P[i].X = 3;
                if (P[i].Y < 3) P[i].Y = 3;
            }
            Invalidate(); 
        }

        
        private void KatokPaint(object sender, PaintEventArgs e)
        {
            if (P != null)
            {
                e.Graphics.DrawPolygon(Pens.Green, P);
            }
        }
    }
}