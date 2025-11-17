using System;
using System.Drawing;
using System.Windows.Forms;

namespace XO_Oleksiuk
{
    class GameButton : Button
    {
        public bool IsClear,
                     IsCross,
                     IsZero;

        public GameButton()
        {
            Text = "";
            Font = new Font(Font.Name, 30, Font.Style);
            IsClear = true;
            IsCross = IsZero = false;
        }

        public void SetCross()
        {
            Text = "X";
            IsCross = true;
            IsClear = IsZero = false;
        }

        public void SetNull()
        {
            Text = "O";
            IsClear = IsCross = false;
            IsZero = true;
        }

        public void SetClear()
        {
            Text = "";
            IsClear = true;
            IsCross = IsZero = false;
        }
    }
}