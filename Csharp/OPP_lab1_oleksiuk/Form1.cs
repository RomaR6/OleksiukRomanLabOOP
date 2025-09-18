using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace OPP_lab1_oleksiuk_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxArticle.MaxLength = 8;
            textBoxArticle.KeyPress += OnlyDigits_KeyPress;
            textBoxPrice.KeyPress += Price_KeyPress;
            textBoxYear.KeyPress += OnlyDigits_KeyPress;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

        class Product
        {
            public string Article { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }
            public double Price { get; set; }
            public int Year { get; set; }

            public Product() { }

            public Product(string article, string name, string brand, double price, int year)
            {
                Article = article;
                Name = name;
                Brand = brand;
                Price = price;
                Year = year;
            }

            public string Info() =>
                $"Артикул: {Article}, Назва: {Name}, Бренд: {Brand}, Ціна: {Price} грн, Рік: {Year}";
        }

        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                e.Handled = true;

            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                ((sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Contains(",")))
                e.Handled = true;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Видалення")
            {
                textBoxBrand.Enabled = false;
                textBoxPrice.Enabled = false;
                textBoxYear.Enabled = false;
            }
            else
            {
                textBoxBrand.Enabled = true;
                textBoxPrice.Enabled = true;
                textBoxYear.Enabled = true;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string article = textBoxArticle.Text.Trim();
            string name = textBoxName.Text.Trim();
            string brand = textBoxBrand.Text.Trim();
            string priceStr = textBoxPrice.Text.Trim().Replace(',', '.');
            string yearStr = textBoxYear.Text.Trim();

            if (tabControl1.SelectedTab.Text == "Додавання")
            {
                if (string.IsNullOrWhiteSpace(article) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(brand) ||
                    string.IsNullOrWhiteSpace(priceStr) ||
                    string.IsNullOrWhiteSpace(yearStr))
                {
                    MessageBox.Show("Заповніть усі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double price = 0;
                double.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out price);
                int.TryParse(yearStr, out int year);

                if (year < 0 || year > 2025)
                {
                    MessageBox.Show("Рік випуску має бути від 0 до 2025!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Product p = new Product(article, name, brand, price, year);
                dataGridViewMain.Rows.Add(p.Article, p.Name, p.Brand, p.Price, p.Year);
            }
            else if (tabControl1.SelectedTab.Text == "Видалення")
            {
                bool deleted = false;

                foreach (DataGridViewRow row in dataGridViewMain.Rows)
                {
                    if (!row.IsNewRow &&
                        (row.Cells[0].Value?.ToString() == article || row.Cells[1].Value?.ToString() == name))
                    {
                        dataGridViewMain.Rows.Remove(row);
                        deleted = true;
                        break;
                    }
                }

                if (deleted)
                {
                    foreach (DataGridViewRow row in dataGridViewSearch.Rows)
                    {
                        if (!row.IsNewRow &&
                            (row.Cells[0].Value?.ToString() == article || row.Cells[1].Value?.ToString() == name))
                        {
                            dataGridViewSearch.Rows.Remove(row);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Такого товару немає у списку!", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControl1.SelectedTab.Text == "Пошук")
            {
                dataGridViewSearch.Rows.Clear();
                bool found = false;

                foreach (DataGridViewRow row in dataGridViewMain.Rows)
                {
                    if (row.IsNewRow) continue;

                    string rowArticle = row.Cells[0].Value?.ToString() ?? "";
                    string rowName = row.Cells[1].Value?.ToString() ?? "";

                    bool match = true;

                    if (!string.IsNullOrWhiteSpace(article) && !rowArticle.StartsWith(article))
                        match = false;

                    if (!string.IsNullOrWhiteSpace(name) &&
                        !rowName.Contains(name, StringComparison.OrdinalIgnoreCase))
                        match = false;

                    if (match)
                    {
                        dataGridViewSearch.Rows.Add(
                            row.Cells[0].Value,
                            row.Cells[1].Value,
                            row.Cells[2].Value,
                            row.Cells[3].Value,
                            row.Cells[4].Value
                        );
                        found = true;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("За даним запитом нічого не знайдено!", "Результат пошуку",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            textBoxArticle.Clear();
            textBoxName.Clear();
            textBoxBrand.Clear();
            textBoxPrice.Clear();
            textBoxYear.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Text Files|*.txt|All Files|*.*" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (DataGridViewRow row in dataGridViewMain.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            sw.WriteLine($"{row.Cells[0].Value};{row.Cells[1].Value};{row.Cells[2].Value};{row.Cells[3].Value};{row.Cells[4].Value}");
                        }
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Text Files|*.txt|All Files|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dataGridViewMain.Rows.Clear();
                string[] lines = File.ReadAllLines(ofd.FileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 5)
                    {
                        dataGridViewMain.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4]);
                    }
                }
            }
        }
    }
}
