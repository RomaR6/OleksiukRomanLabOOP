using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace OOP_C__lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.MaxLength = 8;
            textBox1.KeyPress += Article_KeyPress;
            textBox3.KeyPress += Brand_KeyPress;
            textBox4.MaxLength = 10;
            textBox4.KeyPress += Price_KeyPress;
            textBox5.KeyPress += Year_KeyPress;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            button2.Click += Button2_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            ShowHideArithmetic(false);
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

            public static Product operator +(Product p, double value)
            {
                return new Product(p.Article, p.Name, p.Brand, p.Price + value, p.Year);
            }
            public static Product operator -(Product p, double value)
            {
                return new Product(p.Article, p.Name, p.Brand, p.Price - value, p.Year);
            }
            public static Product operator *(Product p, double value)
            {
                return new Product(p.Article, p.Name, p.Brand, p.Price * value, p.Year);
            }
            public static Product operator /(Product p, double value)
            {
                return new Product(p.Article, p.Name, p.Brand, p.Price / value, p.Year);
            }
            public static implicit operator bool(Product p) => p.Price > 0;
            public static implicit operator string(Product p) => p.Info();
            public string Info() =>
                 $"Артикул: {Article}, Назва: {Name}, Бренд: {Brand}, Ціна: {Price} грн, Рік: {Year}";
        }

        private void Article_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && tb.Text.Length >= 8)
                e.Handled = true;
        }

        private void Brand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                e.Handled = true;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (tb.Text.Contains(".") || tb.Text.Contains(",")))
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && tb.Text.Length >= 10)
                e.Handled = true;
        }

        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "обрахувати")
            {
                ShowHideArithmetic(true);
                ShowHideMainControls(false);
            }
            else
            {
                ShowHideArithmetic(false);
                ShowHideMainControls(true);
            }
        }

        private void ShowHideArithmetic(bool show)
        {
            label6.Visible = show;
            label7.Visible = show;
            label8.Visible = show;
            label9.Visible = show;
            textBox6.Visible = show;
            textBox7.Visible = show;
            textBox8.Visible = show;
            textBox9.Visible = show;
            button2.Visible = show;
        }

        private void ShowHideMainControls(bool show)
        {
            label1.Visible = show;
            label2.Visible = show;
            label3.Visible = show;
            label4.Visible = show;
            label5.Visible = show;
            textBox1.Visible = show;
            textBox2.Visible = show;
            textBox3.Visible = show;
            textBox4.Visible = show;
            textBox5.Visible = show;
            button1.Visible = show;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string article = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string brand = textBox3.Text.Trim();
            string priceStr = textBox4.Text.Trim().Replace(',', '.');
            string yearStr = textBox5.Text.Trim();

            if (tabControl1.SelectedTab.Text == "додавання")
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

                if (!double.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
                {
                    MessageBox.Show("Введіть правильну ціну!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(yearStr, out int year) || year < 0 || year > 2025)
                {
                    MessageBox.Show("Рік випуску має бути від 0 до 2025!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Product p = new Product(article, name, brand, price, year);
                dataGridView1.Rows.Add(p.Article, p.Name, p.Brand, p.Price, p.Year);
            }
            else if (tabControl1.SelectedTab.Text == "Видалення")
            {
                bool deleted = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && (row.Cells[0].Value?.ToString() == article || row.Cells[1].Value?.ToString() == name))
                    {
                        dataGridView1.Rows.Remove(row);
                        deleted = true;
                        break;
                    }
                }

                if (deleted)
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (!row.IsNewRow && (row.Cells[0].Value?.ToString() == article || row.Cells[1].Value?.ToString() == name))
                        {
                            dataGridView2.Rows.Remove(row);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Такого товару немає у списку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControl1.SelectedTab.Text == "Пошук")
            {
                dataGridView2.Rows.Clear();
                bool found = false;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string rowArticle = row.Cells[0].Value?.ToString() ?? "";
                    string rowName = row.Cells[1].Value?.ToString() ?? "";

                    bool match = true;

                    if (!string.IsNullOrWhiteSpace(article) && !rowArticle.StartsWith(article))
                        match = false;

                    if (!string.IsNullOrWhiteSpace(name) && !rowName.Contains(name, StringComparison.OrdinalIgnoreCase))
                        match = false;

                    if (match)
                    {
                        dataGridView2.Rows.Add(
                            row.Cells[0].Value,
                            row.Cells[1].Value,
                            row.Cells[2].Value,
                            row.Cells[3].Value,
                            row.Cells[4].Value
                        );
                        found = true;
                    }
                }
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView2.SelectedRows.Count == 0)
                return;

            void ApplyOperation(DataGridViewRow row, double value, Func<Product, double, Product> operation)
            {
                if (row.IsNewRow) return;
                double oldPrice = Convert.ToDouble(row.Cells[3].Value);
                Product p = new Product(
                    row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    oldPrice,
                    Convert.ToInt32(row.Cells[4].Value)
                );
                Product newP = operation(p, value);
                row.DataGridView.Rows.Add(newP.Article, newP.Name, newP.Brand, newP.Price, newP.Year);
            }

            if (double.TryParse(textBox6.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valPlus))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    ApplyOperation(row, valPlus, (p, v) => p + v);
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    ApplyOperation(row, valPlus, (p, v) => p + v);
            }

            if (double.TryParse(textBox7.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMinus))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    ApplyOperation(row, valMinus, (p, v) => p - v);
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    ApplyOperation(row, valMinus, (p, v) => p - v);
            }

            if (double.TryParse(textBox8.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valMul))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    ApplyOperation(row, valMul, (p, v) => p * v);
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    ApplyOperation(row, valMul, (p, v) => p * v);
            }

            if (double.TryParse(textBox9.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valDiv))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    ApplyOperation(row, valDiv, (p, v) => p / v);
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    ApplyOperation(row, valDiv, (p, v) => p / v);
            }

            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Text Files|*.txt|All Files|*.*" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            sw.WriteLine($"{row.Cells[0].Value};{row.Cells[1].Value};{row.Cells[2].Value};{row.Cells[3].Value};{row.Cells[4].Value}");
                        }
                    }
                }
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Text Files|*.txt|All Files|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                string[] lines = File.ReadAllLines(ofd.FileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 5)
                    {
                        dataGridView1.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4]);
                    }
                }
            }
        }

    }
}
