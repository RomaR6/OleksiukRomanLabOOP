using Stitch_Oleksiuk;

namespace Stitch_Oleksiuk
{
    partial class Form1
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.polotno1 = new Stitch_Oleksiuk.Polotno();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBNoSym = new System.Windows.Forms.RadioButton();
            this.RBCentr = new System.Windows.Forms.RadioButton();
            this.RBDwi = new System.Windows.Forms.RadioButton();
            this.RBWert = new System.Windows.Forms.RadioButton();
            this.RBGoriz = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // polotno1
            // 
            this.polotno1.ActiveColor = System.Drawing.Color.Red;
            this.polotno1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.polotno1.BackColor = System.Drawing.Color.White;
            this.polotno1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.polotno1.Location = new System.Drawing.Point(198, 12);
            this.polotno1.Name = "polotno1";
            this.polotno1.Size = new System.Drawing.Size(590, 426);
            this.polotno1.symm = 0;
            this.polotno1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Колір";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Очистити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBNoSym);
            this.groupBox1.Controls.Add(this.RBCentr);
            this.groupBox1.Controls.Add(this.RBDwi);
            this.groupBox1.Controls.Add(this.RBWert);
            this.groupBox1.Controls.Add(this.RBGoriz);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Симетрія";
            // 
            // RBNoSym
            // 
            this.RBNoSym.AutoSize = true;
            this.RBNoSym.Location = new System.Drawing.Point(15, 30);
            this.RBNoSym.Name = "RBNoSym";
            this.RBNoSym.Size = new System.Drawing.Size(126, 24);
            this.RBNoSym.TabIndex = 4;
            this.RBNoSym.TabStop = true;
            this.RBNoSym.Text = "Без симетрії";
            this.RBNoSym.UseVisualStyleBackColor = true;
            this.RBNoSym.CheckedChanged += new System.EventHandler(this.RBNoSymCheckedChanged);
            // 
            // RBCentr
            // 
            this.RBCentr.AutoSize = true;
            this.RBCentr.Location = new System.Drawing.Point(15, 150);
            this.RBCentr.Name = "RBCentr";
            this.RBCentr.Size = new System.Drawing.Size(129, 24);
            this.RBCentr.TabIndex = 3;
            this.RBCentr.TabStop = true;
            this.RBCentr.Text = "Центральна";
            this.RBCentr.UseVisualStyleBackColor = true;
            this.RBCentr.CheckedChanged += new System.EventHandler(this.RBCentrCheckedChanged);
            // 
            // RBDwi
            // 
            this.RBDwi.AutoSize = true;
            this.RBDwi.Location = new System.Drawing.Point(15, 120);
            this.RBDwi.Name = "RBDwi";
            this.RBDwi.Size = new System.Drawing.Size(89, 24);
            this.RBDwi.TabIndex = 2;
            this.RBDwi.TabStop = true;
            this.RBDwi.Text = "Дві осі";
            this.RBDwi.UseVisualStyleBackColor = true;
            this.RBDwi.CheckedChanged += new System.EventHandler(this.RBDwiCheckedChanged);
            // 
            // RBWert
            // 
            this.RBWert.AutoSize = true;
            this.RBWert.Location = new System.Drawing.Point(15, 90);
            this.RBWert.Name = "RBWert";
            this.RBWert.Size = new System.Drawing.Size(135, 24);
            this.RBWert.TabIndex = 1;
            this.RBWert.TabStop = true;
            this.RBWert.Text = "Вертикальна";
            this.RBWert.UseVisualStyleBackColor = true;
            this.RBWert.CheckedChanged += new System.EventHandler(this.RBWertCheckedChanged);
            // 
            // RBGoriz
            // 
            this.RBGoriz.AutoSize = true;
            this.RBGoriz.Location = new System.Drawing.Point(15, 60);
            this.RBGoriz.Name = "RBGoriz";
            this.RBGoriz.Size = new System.Drawing.Size(149, 24);
            this.RBGoriz.TabIndex = 0;
            this.RBGoriz.TabStop = true;
            this.RBGoriz.Text = "Горизонтальна";
            this.RBGoriz.UseVisualStyleBackColor = true;
            this.RBGoriz.CheckedChanged += new System.EventHandler(this.RBGorizCheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.polotno1);
            this.Name = "Form1";
            this.Text = "Вишивка хрестиком";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Polotno polotno1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBCentr;
        private System.Windows.Forms.RadioButton RBDwi;
        private System.Windows.Forms.RadioButton RBWert;
        private System.Windows.Forms.RadioButton RBGoriz;
        private System.Windows.Forms.RadioButton RBNoSym;
    }
}