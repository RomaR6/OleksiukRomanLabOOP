using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace XO_Oleksiuk
{
    public delegate void FinishEventHandler(char Winner);

    public partial class Pole : UserControl
    {
        GameButton[,] P = new GameButton[3, 3];

        public event FinishEventHandler OnFinish;

        bool active = true;
        int Moves = 0;

        public Pole()
        {
            InitializeComponent();
            this.ClientSizeChanged += new EventHandler(PoleClientSizeChanged);

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    P[r, c] = new GameButton();
                    P[r, c].Parent = this;
                    P[r, c].Click += new EventHandler(GameButtonClick);
                }
        }

        void Control()
        {
            if (P[0, 0].IsCross && P[0, 1].IsCross && P[0, 2].IsCross ||
                P[1, 0].IsCross && P[1, 1].IsCross && P[1, 2].IsCross ||
                P[2, 0].IsCross && P[2, 1].IsCross && P[2, 2].IsCross ||
                P[0, 0].IsCross && P[1, 0].IsCross && P[2, 0].IsCross ||
                P[0, 1].IsCross && P[1, 1].IsCross && P[2, 1].IsCross ||
                P[0, 2].IsCross && P[1, 2].IsCross && P[2, 2].IsCross ||
                P[0, 0].IsCross && P[1, 1].IsCross && P[2, 2].IsCross ||
                P[0, 2].IsCross && P[1, 1].IsCross && P[2, 0].IsCross)
            {
                active = false;
                if (OnFinish != null) OnFinish('X');
            }

            if (P[0, 0].IsZero && P[0, 1].IsZero && P[0, 2].IsZero ||
                P[1, 0].IsZero && P[1, 1].IsZero && P[1, 2].IsZero ||
                P[2, 0].IsZero && P[2, 1].IsZero && P[2, 2].IsZero ||
                P[0, 0].IsZero && P[1, 0].IsZero && P[2, 0].IsZero ||
                P[0, 1].IsZero && P[1, 1].IsZero && P[2, 1].IsZero ||
                P[0, 2].IsZero && P[1, 2].IsZero && P[2, 2].IsZero ||
                P[0, 0].IsZero && P[1, 1].IsZero && P[2, 2].IsZero ||
                P[0, 2].IsZero && P[1, 1].IsZero && P[2, 0].IsZero)
            {
                active = false;
                if (OnFinish != null) OnFinish('O');
            }
        }

        void PoleClientSizeChanged(object sender, EventArgs e)
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    P[r, c].Width = ClientRectangle.Width / 3;
                    P[r, c].Height = ClientRectangle.Height / 3;
                    P[r, c].Left = c * P[r, c].Width;
                    P[r, c].Top = r * P[r, c].Height;
                }
        }

        public void Clear()
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    P[r, c].SetClear();
            active = true;
            Moves = 0;
        }

        void GameButtonClick(object sender, EventArgs e)
        {
            if ((sender as GameButton).IsClear)
                if (active)
                {
                    (sender as GameButton).SetCross();
                    Control();

                    if (++Moves > 8) active = false;

                    if (active)
                    {
                        int kh = 0, nr = 0, ns = 0;

                        for (int r = 0; r < 3; r++)
                            for (int s = 0; s < 3; s++)
                                if (P[r, s].IsClear)
                                {
                                    if (kh != 2) { kh = 0; for (int rr = 0; rr < 3; rr++) if (P[rr, s].IsZero) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                    if (kh != 2) { kh = 0; for (int ss = 0; ss < 3; ss++) if (P[r, ss].IsZero) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                    if ((kh != 2) && (r == s)) { kh = 0; for (int ss = 0; ss < 3; ss++) if (P[ss, ss].IsZero) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                    if ((kh != 2) && (r == 2 - s)) { kh = 0; for (int ss = 0; ss < 3; ss++) if (P[ss, 2 - ss].IsZero) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                }

                        if (kh != 2)
                            for (int r = 0; r < 3; r++)
                                for (int s = 0; s < 3; s++)
                                    if (P[r, s].IsClear)
                                    {
                                        if (kh != 2) { kh = 0; for (int rr = 0; rr < 3; rr++) if (P[rr, s].IsCross) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                        if (kh != 2) { kh = 0; for (int ss = 0; ss < 3; ss++) if (P[r, ss].IsCross) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                        if ((kh != 2) && (r == s)) { kh = 0; for (int ss = 0; ss < 3; ss++) if (P[ss, ss].IsCross) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                        if ((kh != 2) && (r == 2 - s)) { kh = 0; for (int ss = 0; ss < 3; ss++) if (P[ss, 2 - ss].IsCross) { kh++; if (kh == 2) { ns = s; nr = r; } } }
                                    }

                        if (kh != 2)
                        {
                            Random RN = new Random();
                            do { nr = RN.Next(3); ns = RN.Next(3); }
                            while (!P[nr, ns].IsClear);
                        }

                        P[nr, ns].SetNull();
                        Moves++;
                        Control();
                        return;
                    }
                }
        }
    }
}