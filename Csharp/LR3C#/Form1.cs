using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LR3C_ 
{
    public partial class Form1 : Form
    {
        private List<Product> productList = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            this.Load += Form1_Load;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            comboBoxType.SelectedIndexChanged += ComboBoxType_SelectedIndexChanged;
            button1.Click += button1_Click;
            button2.Click += Button2_Click;
            зберегтиToolStripMenuItem.Click += зберегтиToolStripMenuItem_Click;
            відкритиToolStripMenuItem.Click += відкритиToolStripMenuItem_Click;

            
            textBox1.KeyPress += Article_KeyPress;
            textBox3.KeyPress += Brand_KeyPress;
            textBox4.KeyPress += Price_KeyPress;
            textBox5.KeyPress += Year_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.AddRange(new string[] { "Бойлер", "Сифон", "Мийка" });
            comboBoxType.SelectedIndex = 0;
            TabControl1_SelectedIndexChanged(null, null);
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text;
            bool isCalculationTab = selectedTab == "обрахувати";

            
            ShowHideMainControls(!isCalculationTab);
            
            ShowHideArithmetic(isCalculationTab);
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBoxType.SelectedItem.ToString();
            panelBoiler.Visible = selectedType == "Бойлер";
            panelSiphon.Visible = selectedType == "Сифон";
            panelSink.Visible = selectedType == "Мийка";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text;

            if (selectedTab == "додавання") AddProduct();
            else if (selectedTab == "Видалення") DeleteProduct();
            else if (selectedTab == "Пошук") SearchProducts();

            ClearInputFields();
        }

        private void AddProduct()
        {
            if (!double.TryParse(textBox4.Text.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double price) ||
                !int.TryParse(textBox5.Text.Trim(), out int year))
            {
                MessageBox.Show("Заповніть коректно ціну та рік!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product newProduct = null;
            try
            {
                switch (comboBoxType.SelectedItem.ToString())
                {
                    case "Бойлер":
                        newProduct = new Boiler(textBox1.Text, textBox2.Text, textBox3.Text, price, year, int.Parse(textBoxVolume.Text), int.Parse(textBoxPower.Text));
                        break;
                    case "Сифон":
                        newProduct = new Siphon(textBox1.Text, textBox2.Text, textBox3.Text, price, year, textBoxSiphonType.Text);
                        break;
                    case "Мийка":
                        newProduct = new Sink(textBox1.Text, textBox2.Text, textBox3.Text, price, year, textBoxMaterial.Text);
                        break;
                }

                if (newProduct != null)
                {
                    productList.Add(newProduct);
                    UpdateDataGridView(productList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка даних: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteProduct()
        {
            string article = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(article))
            {
                MessageBox.Show("Введіть артикул для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int removedCount = productList.RemoveAll(p => p.Article.Equals(article, StringComparison.OrdinalIgnoreCase));
            if (removedCount > 0)
            {
                UpdateDataGridView(productList);
                MessageBox.Show("Товар(и) успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Товар з таким артикулом не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SearchProducts()
        {
            string article = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();

            var results = productList.Where(p =>
                (string.IsNullOrWhiteSpace(article) || p.Article.StartsWith(article, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(name) || p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            UpdateDataGridView(results, isSearchResult: true);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть один або декілька рядків у таблиці для обрахунку.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string article = row.Cells[0].Value.ToString();
                Product product = productList.FirstOrDefault(p => p.Article == article);
                if (product == null) continue;

                if (double.TryParse(textBox6.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valPlus)) product += valPlus;
                if (double.TryParse(textBox7.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMinus)) product -= valMinus;
                if (double.TryParse(textBox8.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMul)) product *= valMul;
                if (double.TryParse(textBox9.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valDiv)) product /= valDiv;
            }

            UpdateDataGridView(productList);
            ClearCalculationFields();
        }

        private void UpdateDataGridView(List<Product> products, bool isSearchResult = false)
        {
            DataGridView dgv = isSearchResult ? dataGridView2 : dataGridView1;
            dgv.Rows.Clear();
            foreach (Product p in products)
            {
                dgv.Rows.Add(p.Article, p.Name, p.Brand, p.Price, p.Year, p.GetSpecificInfo());
            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files|*.csv|All Files|*.*" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (Product p in productList)
                    {
                        string type = p.GetType().Name;
                        string line = $"{type};{p.Article};{p.Name};{p.Brand};{p.Price};{p.Year}";
                        if (p is Boiler b) line += $";{b.VolumeLiters};{b.PowerW}";
                        if (p is Siphon s) line += $";{s.SiphonType}";
                        if (p is Sink sk) line += $";{sk.Material}";
                        sw.WriteLine(line);
                    }
                }
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV Files|*.csv|All Files|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                productList.Clear();
                string[] lines = File.ReadAllLines(ofd.FileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length < 6) continue;

                    string type = parts[0];
                    string article = parts[1];
                    string name = parts[2];
                    string brand = parts[3];
                    double price = double.Parse(parts[4]);
                    int year = int.Parse(parts[5]);

                    Product p = null;
                    if (type == "Boiler" && parts.Length >= 8) p = new Boiler(article, name, brand, price, year, int.Parse(parts[6]), int.Parse(parts[7]));
                    else if (type == "Siphon" && parts.Length >= 7) p = new Siphon(article, name, brand, price, year, parts[6]);
                    else if (type == "Sink" && parts.Length >= 7) p = new Sink(article, name, brand, price, year, parts[6]);

                    if (p != null) productList.Add(p);
                }
                UpdateDataGridView(productList);
            }
        }

        #region Helper and UI Methods
        private void ShowHideArithmetic(bool show)
        {
            label6.Visible = label7.Visible = label8.Visible = label9.Visible = show;
            textBox6.Visible = textBox7.Visible = textBox8.Visible = textBox9.Visible = show;
            button2.Visible = show;
        }

        private void ShowHideMainControls(bool show)
        {
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = show;
            textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = show;
            button1.Visible = show;
            labelType.Visible = comboBoxType.Visible = show;
            panelBoiler.Visible = show && comboBoxType.SelectedItem?.ToString() == "Бойлер";
            panelSiphon.Visible = show && comboBoxType.SelectedItem?.ToString() == "Сифон";
            panelSink.Visible = show && comboBoxType.SelectedItem?.ToString() == "Мийка";
        }

        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBoxVolume.Clear();
            textBoxPower.Clear();
            textBoxSiphonType.Clear();
            textBoxMaterial.Clear();
        }

        private void ClearCalculationFields()
        {
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
        #endregion

        #region KeyPress Validation
        private void Article_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        private void Brand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }
        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.') e.Handled = true;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (sender as TextBox).Text.Contains(",")) e.Handled = true;
        }
        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        #endregion
    }
}