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
            textBox1.MaxLength = 8;
            textBox1.KeyPress += Article_KeyPress;
            textBox3.KeyPress += Brand_KeyPress;
            textBox4.MaxLength = 10;
            textBox4.KeyPress += Price_KeyPress;
            textBox5.KeyPress += Year_KeyPress;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if (tabControl1.SelectedTab.Text == "Видалення")
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
            else
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
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

                double price = 0;
                double.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out price);
                int.TryParse(yearStr, out int year);

                if (year < 0 || year > 2025)
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
                    if (!row.IsNewRow &&
                        (row.Cells[0].Value?.ToString() == article || row.Cells[1].Value?.ToString() == name))
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
                        if (!row.IsNewRow &&
                            (row.Cells[0].Value?.ToString() == article || row.Cells[1].Value?.ToString() == name))
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

                    if (!string.IsNullOrWhiteSpace(name) &&
                        !rowName.Contains(name, StringComparison.OrdinalIgnoreCase))
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

                if (!found)
                {
                    MessageBox.Show("За даним запитом нічого не знайдено!", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
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
