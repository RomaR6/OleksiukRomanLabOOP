namespace Stitch_Oleksiuk
{
    partial class Polotno
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Polotno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "Polotno";
            this.Size = new System.Drawing.Size(300, 300);

            
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PolotnoPaint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PolotnoMouseClick);
            this.SizeChanged += new System.EventHandler(this.PolotnoSizeChanged);

            this.ResumeLayout(false);
        }

        #endregion
    }
}