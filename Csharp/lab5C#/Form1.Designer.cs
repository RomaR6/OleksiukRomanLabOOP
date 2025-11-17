using System.Drawing;
using System.Windows.Forms;

namespace lab5C_ 
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.tabDelete = new System.Windows.Forms.TabPage();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.tabcalculate = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalInfo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.panelBoiler = new System.Windows.Forms.Panel();
            this.textBoxPower = new System.Windows.Forms.TextBox();
            this.labelPower = new System.Windows.Forms.Label();
            this.textBoxVolume = new System.Windows.Forms.TextBox();
            this.labelVolume = new System.Windows.Forms.Label();
            this.panelSiphon = new System.Windows.Forms.Panel();
            this.textBoxSiphonType = new System.Windows.Forms.TextBox();
            this.labelSiphonType = new System.Windows.Forms.Label();
            this.panelSink = new System.Windows.Forms.Panel();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelBoiler.SuspendLayout();
            this.panelSiphon.SuspendLayout();
            this.panelSink.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1425, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.відкритиToolStripMenuItem,
            this.зберегтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // відкритиToolStripMenuItem
            // 
            this.відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            this.відкритиToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.відкритиToolStripMenuItem.Text = "Відкрити";
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.зберегтиToolStripMenuItem.Text = "Зберегти";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAdd);
            this.tabControl1.Controls.Add(this.tabDelete);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Controls.Add(this.tabcalculate);
            this.tabControl1.Location = new System.Drawing.Point(12, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(353, 30);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAdd
            // 
            this.tabAdd.Location = new System.Drawing.Point(4, 29);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Size = new System.Drawing.Size(345, 0);
            this.tabAdd.Text = "додавання";
            // 
            // tabDelete
            // 
            this.tabDelete.Location = new System.Drawing.Point(4, 29);
            this.tabDelete.Name = "tabDelete";
            this.tabDelete.Size = new System.Drawing.Size(345, 0);
            this.tabDelete.Text = "Видалення";
            // 
            // tabSearch
            // 
            this.tabSearch.Location = new System.Drawing.Point(4, 29);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(345, 0);
            this.tabSearch.Text = "Пошук";
            // 
            // tabcalculate
            // 
            this.tabcalculate.Location = new System.Drawing.Point(4, 29);
            this.tabcalculate.Name = "tabcalculate";
            this.tabcalculate.Size = new System.Drawing.Size(345, 0);
            this.tabcalculate.Text = "обрахувати";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 132);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 27);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 172);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 27);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(129, 212);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(220, 27);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(129, 252);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(220, 27);
            this.textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(129, 292);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(220, 27);
            this.textBox5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.Text = "Артикул";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.Text = "Назва";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.Text = "Бренд";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.Text = "Ціна";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.Text = "Рік випуску";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.AdditionalInfo});
            this.dataGridView1.Location = new System.Drawing.Point(400, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1003, 259);
            this.dataGridView1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Артикул";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Назва";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Бренд";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Ціна";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Рік випуску";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // AdditionalInfo
            // 
            this.AdditionalInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AdditionalInfo.HeaderText = "Додаткова інформація";
            this.AdditionalInfo.Name = "AdditionalInfo";
            this.AdditionalInfo.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.AdditionalInfo2});
            this.dataGridView2.Location = new System.Drawing.Point(400, 340);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1003, 261);
            this.dataGridView2.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Артикул";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Назва";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Бренд";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Ціна";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Рік випуску";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // AdditionalInfo2
            // 
            this.AdditionalInfo2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AdditionalInfo2.HeaderText = "Додаткова інформація";
            this.AdditionalInfo2.Name = "AdditionalInfo2";
            this.AdditionalInfo2.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(90, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.Text = "+";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(90, 513);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.Text = "-";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(90, 543);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(90, 573);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.Text = "/";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(129, 480);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 27);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(129, 510);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 27);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(129, 540);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 27);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(129, 570);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 27);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(124, 610);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 31);
            this.button2.Text = "Обрахувати";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(35, 95);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(86, 20);
            this.labelType.Text = "Тип товару";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(129, 92);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(220, 28);
            this.comboBoxType.TabIndex = 1;
            // 
            // panelBoiler
            // 
            this.panelBoiler.Controls.Add(this.textBoxPower);
            this.panelBoiler.Controls.Add(this.labelPower);
            this.panelBoiler.Controls.Add(this.textBoxVolume);
            this.panelBoiler.Controls.Add(this.labelVolume);
            this.panelBoiler.Location = new System.Drawing.Point(12, 335);
            this.panelBoiler.Name = "panelBoiler";
            this.panelBoiler.Size = new System.Drawing.Size(350, 80);
            this.panelBoiler.TabIndex = 7;
            // 
            // textBoxPower
            // 
            this.textBoxPower.Location = new System.Drawing.Point(117, 42);
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.Size = new System.Drawing.Size(220, 27);
            // 
            // labelPower
            // 
            this.labelPower.AutoSize = true;
            this.labelPower.Location = new System.Drawing.Point(4, 49);
            this.labelPower.Name = "labelPower";
            this.labelPower.Size = new System.Drawing.Size(116, 20);
            this.labelPower.Text = "Потужність (Вт)";
            // 
            // textBoxVolume
            // 
            this.textBoxVolume.Location = new System.Drawing.Point(117, 7);
            this.textBoxVolume.Name = "textBoxVolume";
            this.textBoxVolume.Size = new System.Drawing.Size(220, 27);
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(23, 10);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(72, 20);
            this.labelVolume.Text = "Об'єм (л)";
            // 
            // panelSiphon
            // 
            this.panelSiphon.Controls.Add(this.textBoxSiphonType);
            this.panelSiphon.Controls.Add(this.labelSiphonType);
            this.panelSiphon.Location = new System.Drawing.Point(12, 335);
            this.panelSiphon.Name = "panelSiphon";
            this.panelSiphon.Size = new System.Drawing.Size(350, 40);
            this.panelSiphon.TabIndex = 8;
            this.panelSiphon.Visible = false;
            // 
            // textBoxSiphonType
            // 
            this.textBoxSiphonType.Location = new System.Drawing.Point(117, 7);
            this.textBoxSiphonType.Name = "textBoxSiphonType";
            this.textBoxSiphonType.Size = new System.Drawing.Size(220, 27);
            // 
            // labelSiphonType
            // 
            this.labelSiphonType.AutoSize = true;
            this.labelSiphonType.Location = new System.Drawing.Point(23, 10);
            this.labelSiphonType.Name = "labelSiphonType";
            this.labelSiphonType.Size = new System.Drawing.Size(91, 20);
            this.labelSiphonType.Text = "Тип сифона";
            // 
            // panelSink
            // 
            this.panelSink.Controls.Add(this.textBoxMaterial);
            this.panelSink.Controls.Add(this.labelMaterial);
            this.panelSink.Location = new System.Drawing.Point(12, 335);
            this.panelSink.Name = "panelSink";
            this.panelSink.Size = new System.Drawing.Size(350, 40);
            this.panelSink.TabIndex = 9;
            this.panelSink.Visible = false;
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(117, 7);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(220, 27);
            // 
            // labelMaterial
            // 
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.Location = new System.Drawing.Point(15, 10);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(73, 20);
            this.labelMaterial.Text = "Матеріал";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1425, 653);
            this.Controls.Add(this.panelSink);
            this.Controls.Add(this.panelSiphon);
            this.Controls.Add(this.panelBoiler);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Магазин сантехніки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelBoiler.ResumeLayout(false);
            this.panelBoiler.PerformLayout();
            this.panelSiphon.ResumeLayout(false);
            this.panelSiphon.PerformLayout();
            this.panelSink.ResumeLayout(false);
            this.panelSink.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabDelete;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabcalculate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalInfo;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalInfo2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Panel panelBoiler;
        private System.Windows.Forms.TextBox textBoxPower;
        private System.Windows.Forms.Label labelPower;
        private System.Windows.Forms.TextBox textBoxVolume;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Panel panelSiphon;
        private System.Windows.Forms.TextBox textBoxSiphonType;
        private System.Windows.Forms.Label labelSiphonType;
        private System.Windows.Forms.Panel panelSink;
        private System.Windows.Forms.TextBox textBoxMaterial;
        private System.Windows.Forms.Label labelMaterial;
    }
}