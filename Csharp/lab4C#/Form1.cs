using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab4C_
{
    public partial class Form1 : Form
    {
        private readonly ProductService _productService;

        public Form1()
        {
            InitializeComponent();
            _productService = new ProductService();
            _productService.ProductListChanged += OnProductListChanged;
            SetupEventHandlers();
        }

        private void OnProductListChanged()
        {
            UpdateDataGridView(_productService.GetAllProducts());
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
            textBoxVolume.KeyPress += Year_KeyPress;
            textBoxPower.KeyPress += Year_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.AddRange(new string[] { "Бойлер", "Сифон", "Мийка" });
            comboBoxType.SelectedIndex = 0;
            TabControl1_SelectedIndexChanged(null, null);
            OnProductListChanged();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text;
            bool isCalculationTab = selectedTab == "обрахувати";

            if (selectedTab == "Пошук")
            {
                ClearInputFields();
                UpdateDataGridView(new List<Product>(), isSearchResult: true);
            }

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
            try
            {
                if (selectedTab == "додавання") AddProduct();
                else if (selectedTab == "Видалення") DeleteProduct();
                else if (selectedTab == "Пошук") SearchProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (selectedTab != "Пошук")
            {
                ClearInputFields();
            }
        }

        private void AddProduct()
        {
            Product newProduct = null;
            try
            {
                if (!double.TryParse(textBox4.Text.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
                    throw new ArgumentException("Некоректна ціна.");
                if (!int.TryParse(textBox5.Text.Trim(), out int year))
                    throw new ArgumentException("Некоректний рік.");

                string article = textBox1.Text.Trim();
                string name = textBox2.Text.Trim();
                string brand = textBox3.Text.Trim();

                switch (comboBoxType.SelectedItem.ToString())
                {
                    case "Бойлер":
                        if (!int.TryParse(textBoxVolume.Text.Trim(), out int volume))
                            throw new ArgumentException("Некоректний об'єм.");
                        if (!int.TryParse(textBoxPower.Text.Trim(), out int power))
                            throw new ArgumentException("Некоректна потужність.");

                        newProduct = new Boiler(article, name, brand, price, year, volume, power);
                        break;
                    case "Сифон":
                        newProduct = new Siphon(article, name, brand, price, year, textBoxSiphonType.Text.Trim());
                        break;
                    case "Мийка":
                        newProduct = new Sink(article, name, brand, price, year, textBoxMaterial.Text.Trim());
                        break;
                }

                if (newProduct != null)
                {
                    _productService.AddProduct(newProduct);
                    MessageBox.Show("Товар успішно додано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка додавання: " + ex.Message, "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (_productService.DeleteProduct(article))
            {
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

            var results = _productService.SearchProducts(article, name);

            UpdateDataGridView(results, isSearchResult: true);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть один або декілька рядків у таблиці для обрахунку.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string article = row.Cells[0].Value.ToString();

                    Product product = _productService.GetProductByArticle(article);
                    if (product == null) continue;

                    if (double.TryParse(textBox6.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valPlus)) product += valPlus;
                    if (double.TryParse(textBox7.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMinus)) product -= valMinus;
                    if (double.TryParse(textBox8.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMul)) product *= valMul;
                    if (double.TryParse(textBox9.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valDiv)) product /= valDiv;
                }

                _productService.NotifyUpdate();
                ClearCalculationFields();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Помилка! Ділення на нуль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridView(IEnumerable<Product> products, bool isSearchResult = false)
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
                try
                {
                    _productService.SaveToFile(sfd.FileName);
                    MessageBox.Show("Дані успішно збережено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV Files|*.csv|All Files|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _productService.LoadFromFile(ofd.FileName);
                    MessageBox.Show("Дані успішно завантажено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        }
        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        #endregion
    }
}