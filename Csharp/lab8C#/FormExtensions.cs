using System.Windows.Forms;

namespace lab6C_
{
    public static class FormExtensions
    {
        
        public static void ClearAllInputs(this Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.Clear();
                }
                else if (c is Panel p)
                {
                    p.ClearAllInputs(); 
                }
            }
        }

        
        public static bool IsEmpty(this TextBox tb)
        {
            return string.IsNullOrWhiteSpace(tb.Text);
        }
    }
}