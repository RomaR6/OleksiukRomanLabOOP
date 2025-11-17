using lab6C_;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6C_
{
    public partial class Form1 : Form
    {
        private Warehouse warehouseBoilers;
        private Warehouse warehouseSiphons;
        private Warehouse warehouseSinks;
        private List<Warehouse> allWarehouses;

        
        private Dictionary<string, DiscountRule> discountRules;


        public Form1()
        {
            InitializeComponent();
            SetupEventHandlers();

            warehouseBoilers = new Warehouse("Склад бойлерів");
            warehouseSiphons = new Warehouse("Склад сифонів");
            warehouseSinks = new Warehouse("Склад мийок");
            allWarehouses = new List<Warehouse> { warehouseBoilers, warehouseSiphons, warehouseSinks };


            warehouseBoilers.WarehouseChanged += OnWarehouseChanged;
            warehouseSiphons.WarehouseChanged += OnWarehouseChanged;
            warehouseSinks.WarehouseChanged += OnWarehouseChanged;

           
            discountRules = PredefinedRules.GetDiscountRules();

            cmbDiscountRule.Items.AddRange(discountRules.Keys.ToArray());
            cmbDiscountRule.SelectedIndex = 0;

            UpdateWarehouseCounters();
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

            ToolStripMenuItem reportMenuItem = new ToolStripMenuItem("Повний звіт");
            reportMenuItem.Click += (sender, e) => ShowFullReport();
            файлToolStripMenuItem.DropDownItems.Add(reportMenuItem);

            textBox1.KeyPress += Article_KeyPress;
            textBox3.KeyPress += Brand_KeyPress;
            textBox4.KeyPress += Price_KeyPress;
            textBox5.KeyPress += Year_KeyPress;


            btnFilterExpensive.Click += BtnFilterExpensive_Click;
            btnSortSelected.Click += BtnSortSelected_Click;
            btnApplyDiscount.Click += BtnApplyDiscount_Click;
        }


        private void OnWarehouseChanged(object sender, EventArgs e)
        {
            UpdateWarehouseCounters();
        }

        private void UpdateWarehouseCounters()
        {
            lblWarehouseBoilers.Text = $"Склад бойлерів: {warehouseBoilers.GetItemCount()}";
            lblWarehouseSiphons.Text = $"Склад сифонів: {warehouseSiphons.GetItemCount()}";
            lblWarehouseSinks.Text = $"Склад мийок: {warehouseSinks.GetItemCount()}";
        }

        private void ShowFullReport()
        {
            List<Product> allProducts = ProductDatabase.GetItems();
            List<Warehouse> allWarehouses = this.allWarehouses;

            StringBuilder report = new StringBuilder();
            report.AppendLine($"--- ПОВНИЙ ЗВІТ ПО ТОВАРАХ ---");
            report.AppendLine($"Всього у базі: {allProducts.Count} позицій.\n");

            foreach (var product in allProducts)
            {
                report.Append($"[Товар]: {product.GetFullInfo()}\n");

                string warehouseInfo = "  -> Знаходиться на складах: ";
                int count = 0;
                foreach (var warehouse in allWarehouses)
                {
                    if (warehouse.ContainsItem(product))
                    {
                        warehouseInfo += $"{warehouse.Name}; ";
                        count++;
                    }
                }

                if (count == 0) warehouseInfo += "Немає на жодному складі.";

                report.AppendLine(warehouseInfo + "\n");
            }

            Form reportForm = new Form();
            reportForm.Text = "Повний звіт";
            reportForm.Size = new System.Drawing.Size(600, 400);


            System.Windows.Forms.TextBox reportTextBox = new System.Windows.Forms.TextBox();

            reportTextBox.Multiline = true;
            reportTextBox.ScrollBars = ScrollBars.Vertical;
            reportTextBox.Dock = DockStyle.Fill;
            reportTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            reportTextBox.Text = report.ToString();
            reportForm.Controls.Add(reportTextBox);
            reportForm.ShowDialog();
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
            Warehouse targetWarehouse = null;

            try
            {
                string brandName = textBox3.Text;
                if (string.IsNullOrWhiteSpace(brandName))
                {
                    MessageBox.Show("Поле 'Бренд' не може бути порожнім.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Manufacturer manufacturer = new Manufacturer(brandName);

                switch (comboBoxType.SelectedItem.ToString())
                {
                    case "Бойлер":
                        newProduct = new Boiler(textBox1.Text, textBox2.Text, manufacturer, price, year, int.Parse(textBoxVolume.Text), int.Parse(textBoxPower.Text));
                        targetWarehouse = warehouseBoilers;
                        break;
                    case "Сифон":
                        newProduct = new Siphon(textBox1.Text, textBox2.Text, manufacturer, price, year, textBoxSiphonType.Text);
                        targetWarehouse = warehouseSiphons;
                        break;
                    case "Мийка":
                        newProduct = new Sink(textBox1.Text, textBox2.Text, manufacturer, price, year, textBoxMaterial.Text);
                        targetWarehouse = warehouseSinks;
                        break;
                }

                if (newProduct != null)
                {
                    ProductDatabase.Add(newProduct);
                    targetWarehouse.AddItemReference(newProduct);
                    UpdateDataGridView(ProductDatabase.GetItems());
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

            Product productToRemove = ProductDatabase.FindByArticle(article);

            if (productToRemove != null)
            {
                foreach (var warehouse in allWarehouses)
                {
                    warehouse.RemoveItemReference(productToRemove);
                }

                ProductDatabase.RemoveAllByArticle(article);

                UpdateDataGridView(ProductDatabase.GetItems());
                MessageBox.Show("Товар успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Товар з таким артикулом не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 1 
        private List<Product> FindProducts(ProductFilter filter)
        {
            List<Product> results = new List<Product>();
            foreach (Product p in ProductDatabase.GetItems())
            {
                
                if (filter(p))
                {
                    results.Add(p);
                }
            }
            return results;
        }

        
        
        private void BtnFilterExpensive_Click(object sender, EventArgs e)
        {
            // 1 
            var results = FindProducts(PredefinedRules.ExpensiveFilter);

            UpdateDataGridView(results, isSearchResult: true);
            MessageBox.Show($"Знайдено {results.Count} товарів дорожчих за 500 грн.", "Результат фільтрації");
        }
        private void SearchProducts()
        {
            string article = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();

            List<Product> results = new List<Product>();


            foreach (Product p in ProductDatabase.GetItems())
            {
                if ((string.IsNullOrWhiteSpace(article) || p.Article.StartsWith(article, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrWhiteSpace(name) || p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)))
                {
                    results.Add(p);
                }
            }

            UpdateDataGridView(results, isSearchResult: true);
        }

        // 3 
        private void BtnSortSelected_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть один або декілька рядків у головній таблиці.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Product> selectedProducts = new List<Product>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string article = row.Cells[0].Value.ToString();
                Product product = ProductDatabase.FindByArticle(article);
                if (product != null)
                {
                    selectedProducts.Add(product);
                }
            }

            // 3 
            ComparisonRule customRule = PredefinedRules.SortByPriceDesc;

           
            Comparison<Product> netComparison = new Comparison<Product>(customRule);

            
            selectedProducts.Sort(netComparison);

            UpdateDataGridView(selectedProducts, isSearchResult: true);
            MessageBox.Show("Обрані товари відсортовано за спаданням ціни.", "Результат сортування");
        }


        // 2 
        private void BtnApplyDiscount_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть один або декілька рядків у головній таблиці.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedRuleName = cmbDiscountRule.SelectedItem.ToString();

            // 2 
            DiscountRule selectedRule = discountRules[selectedRuleName];

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string article = row.Cells[0].Value.ToString();
                Product product = ProductDatabase.FindByArticle(article);
                if (product != null)
                {
                    // 2 
                    product.Price = selectedRule(product);
                }
            }

            UpdateDataGridView(ProductDatabase.GetItems());
            MessageBox.Show($"Знижку '{selectedRuleName}' застосовано.", "Ціни оновлено");
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
                Product product = ProductDatabase.FindByArticle(article);
                if (product == null) continue;

                if (double.TryParse(textBox6.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valPlus)) product += valPlus;
                if (double.TryParse(textBox7.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMinus)) product -= valMinus;
                if (double.TryParse(textBox8.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMul)) product *= valMul;
                if (double.TryParse(textBox9.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valDiv)) product /= valDiv;
            }

            UpdateDataGridView(ProductDatabase.GetItems());
            ClearCalculationFields();
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files|*.csv|All Files|*.*" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (Product p in ProductDatabase.GetItems())
                    {
                        string type = p.GetType().Name;
                        string line = $"{type};{p.Article};{p.Name};{p.Brand.Name};{p.Price};{p.Year}";
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
                ProductDatabase.Clear();
                foreach (var wh in allWarehouses) wh.ClearReferences();

                string[] lines = File.ReadAllLines(ofd.FileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length < 6) continue;

                    try
                    {
                        string type = parts[0];
                        string article = parts[1];
                        string name = parts[2];
                        string brandName = parts[3];
                        double price = double.Parse(parts[4], CultureInfo.InvariantCulture);
                        int year = int.Parse(parts[5]);

                        Manufacturer manufacturer = new Manufacturer(brandName);

                        Product p = null;
                        if (type == "Boiler" && parts.Length >= 8) p = new Boiler(article, name, manufacturer, price, year, int.Parse(parts[6]), int.Parse(parts[7]));
                        else if (type == "Siphon" && parts.Length >= 7) p = new Siphon(article, name, manufacturer, price, year, parts[6]);
                        else if (type == "Sink" && parts.Length >= 7) p = new Sink(article, name, manufacturer, price, year, parts[6]);

                        if (p != null)
                        {
                            ProductDatabase.Add(p);

                            if (p is Boiler) warehouseBoilers.AddItemReference(p);
                            else if (p is Siphon) warehouseSiphons.AddItemReference(p);
                            else if (p is Sink) warehouseSinks.AddItemReference(p);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка читання рядка: {line}\nДеталі: {ex.Message}", "Помилка файлу");
                    }
                }
                UpdateDataGridView(ProductDatabase.GetItems());
            }
        }

        #region Helper and UI Methods
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

        private void UpdateDataGridView(List<Product> products, bool isSearchResult = false)
        {
            DataGridView dgv = isSearchResult ? dataGridView2 : dataGridView1;
            dgv.Rows.Clear();
            foreach (Product p in products)
            {
                dgv.Rows.Add(p.Article, p.Name, p.Brand.Name, p.Price, p.Year, p.GetSpecificInfo());
            }
        }
        private void ShowHideArithmetic(bool show)
        {
            label6.Visible = label7.Visible = label8.Visible = label9.Visible = show;
            textBox6.Visible = textBox7.Visible = textBox8.Visible = textBox9.Visible = show;
            button2.Visible = show;

            labelDiscount.Visible = show;
            cmbDiscountRule.Visible = show;
            btnApplyDiscount.Visible = show;
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
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (sender as System.Windows.Forms.TextBox).Text.Contains(",")) e.Handled = true;
        }
        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        #endregion
    }
}