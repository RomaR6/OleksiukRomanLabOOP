namespace OPP_lab1_oleksiuk_C_
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabDelete;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5;
        private System.Windows.Forms.TextBox textBoxArticle, textBoxName, textBoxBrand, textBoxPrice, textBoxYear;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.DataGridView dataGridViewSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabAdd = new TabPage();
            tabDelete = new TabPage();
            tabSearch = new TabPage();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxArticle = new TextBox();
            textBoxName = new TextBox();
            textBoxBrand = new TextBox();
            textBoxPrice = new TextBox();
            textBoxYear = new TextBox();
            buttonOk = new Button();
            dataGridViewMain = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewSearch = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearch).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 28);
            menuStrip1.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(59, 24);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(155, 26);
            openToolStripMenuItem.Text = "Відкрити";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(155, 26);
            saveToolStripMenuItem.Text = "Зберегти";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabAdd);
            tabControl1.Controls.Add(tabDelete);
            tabControl1.Controls.Add(tabSearch);
            tabControl1.Location = new Point(20, 40);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(350, 120);
            tabControl1.TabIndex = 1;
            // 
            // tabAdd
            // 
            tabAdd.Location = new Point(4, 29);
            tabAdd.Name = "tabAdd";
            tabAdd.Size = new Size(342, 87);
            tabAdd.TabIndex = 0;
            tabAdd.Text = "Додавання";
            // 
            // tabDelete
            // 
            tabDelete.Location = new Point(4, 29);
            tabDelete.Name = "tabDelete";
            tabDelete.Size = new Size(342, 87);
            tabDelete.TabIndex = 1;
            tabDelete.Text = "Видалення";
            // 
            // tabSearch
            // 
            tabSearch.Location = new Point(4, 29);
            tabSearch.Name = "tabSearch";
            tabSearch.Size = new Size(342, 87);
            tabSearch.TabIndex = 2;
            tabSearch.Text = "Пошук";
            // 
            // label1
            // 
            label1.Location = new Point(20, 180);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 2;
            label1.Text = "Артикул";
            // 
            // label2
            // 
            label2.Location = new Point(20, 220);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 4;
            label2.Text = "Назва";
            // 
            // label3
            // 
            label3.Location = new Point(20, 260);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 6;
            label3.Text = "Бренд";
            // 
            // label4
            // 
            label4.Location = new Point(20, 300);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 8;
            label4.Text = "Ціна";
            // 
            // label5
            // 
            label5.Location = new Point(20, 340);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 10;
            label5.Text = "Рік випуску";
            // 
            // textBoxArticle
            // 
            textBoxArticle.Location = new Point(120, 180);
            textBoxArticle.Name = "textBoxArticle";
            textBoxArticle.Size = new Size(100, 27);
            textBoxArticle.TabIndex = 3;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(120, 220);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 27);
            textBoxName.TabIndex = 5;
            // 
            // textBoxBrand
            // 
            textBoxBrand.Location = new Point(120, 260);
            textBoxBrand.Name = "textBoxBrand";
            textBoxBrand.Size = new Size(100, 27);
            textBoxBrand.TabIndex = 7;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(120, 300);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(100, 27);
            textBoxPrice.TabIndex = 9;
            // 
            // textBoxYear
            // 
            textBoxYear.Location = new Point(120, 340);
            textBoxYear.Name = "textBoxYear";
            textBoxYear.Size = new Size(100, 27);
            textBoxYear.TabIndex = 11;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(120, 380);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 36);
            buttonOk.TabIndex = 12;
            buttonOk.Text = "OK";
            buttonOk.Click += buttonOk_Click;
            // 
            // dataGridViewMain
            // 
            dataGridViewMain.AllowUserToAddRows = false;
            dataGridViewMain.AllowUserToDeleteRows = false;
            dataGridViewMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMain.ColumnHeadersHeight = 29;
            dataGridViewMain.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridViewMain.Location = new Point(400, 40);
            dataGridViewMain.Name = "dataGridViewMain";
            dataGridViewMain.ReadOnly = true;
            dataGridViewMain.RowHeadersWidth = 51;
            dataGridViewMain.Size = new Size(770, 280);
            dataGridViewMain.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Артикул";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Назва";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Бренд";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Ціна";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Рік випуску";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewSearch
            // 
            dataGridViewSearch.AllowUserToAddRows = false;
            dataGridViewSearch.AllowUserToDeleteRows = false;
            dataGridViewSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSearch.ColumnHeadersHeight = 29;
            dataGridViewSearch.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10 });
            dataGridViewSearch.Location = new Point(400, 350);
            dataGridViewSearch.Name = "dataGridViewSearch";
            dataGridViewSearch.ReadOnly = true;
            dataGridViewSearch.RowHeadersWidth = 51;
            dataGridViewSearch.Size = new Size(770, 280);
            dataGridViewSearch.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Артикул";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Назва";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Бренд";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Ціна";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "Рік випуску";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // Form1
            // 
            ClientSize = new Size(1182, 703);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(textBoxArticle);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(label3);
            Controls.Add(textBoxBrand);
            Controls.Add(label4);
            Controls.Add(textBoxPrice);
            Controls.Add(label5);
            Controls.Add(textBoxYear);
            Controls.Add(buttonOk);
            Controls.Add(dataGridViewMain);
            Controls.Add(dataGridViewSearch);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Магазин сантехніки";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}
