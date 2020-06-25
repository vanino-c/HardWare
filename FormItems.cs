using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware
{
    public partial class FormItems : Form
    {
        public FormItems()
        {
            InitializeComponent();
            ShowCategories();
            ShowItems();
            comboBoxManufacturerer.SelectedIndex = 0;
            comboBoxMeasUnit.SelectedIndex = 0;
        }

        void ShowCategories()
        {
            foreach (Categories categories in Program.hsdb.Categories)
            {
                comboBoxCategory.Items.Add(categories.Id.ToString() + ". " + categories.Name);
            }
        }

        void ShowItems()
        {
            listViewPhones.Items.Clear();
            foreach (Items items in Program.hsdb.Items)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    items.Id.ToString(),
                    comboBoxManufacturerer.Items[items.Manufacturer].ToString(),
                    items.Name,
                    items.Categories.Name,
                    comboBoxMeasUnit.Items[items.MeasureUnit].ToString(),
                    items.Price.ToString()
                });
                item.Tag = items;
                listViewPhones.Items.Add(item);
            }
            listViewPhones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewPhones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPhones.SelectedItems.Count == 1)
            {
                Items items = listViewPhones.SelectedItems[0].Tag as Items;
                comboBoxManufacturerer.SelectedIndex = items.Manufacturer;
                textBoxName.Text = items.Name;
                textBoxPrice.Text = items.Price.ToString();
                comboBoxCategory.SelectedIndex = comboBoxCategory.FindString(items.Category.ToString());
                comboBoxMeasUnit.SelectedIndex = items.MeasureUnit;
            }
            else
            {
                comboBoxManufacturerer.SelectedIndex = 0;
                textBoxName.Text = "";
                textBoxPrice.Text = "";
                comboBoxMeasUnit.SelectedIndex = 0;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxPrice.Text != "")
            {
                Items item = new Items();
                item.Manufacturer = comboBoxManufacturerer.SelectedIndex;
                item.Name = textBoxName.Text;
                item.Price = Convert.ToDouble(textBoxPrice.Text);
                item.MeasureUnit = comboBoxMeasUnit.SelectedIndex;
                item.Category = Convert.ToInt32(comboBoxCategory.SelectedItem.ToString().Split('.')[0]);
                Program.hsdb.Items.Add(item);
                Program.hsdb.SaveChanges();
                ShowItems();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewPhones.SelectedItems.Count == 1)
            {
                Items item = listViewPhones.SelectedItems[0].Tag as Items;
                item.Manufacturer = comboBoxManufacturerer.SelectedIndex;
                item.Name = textBoxName.Text;
                item.Price = Convert.ToDouble(textBoxPrice.Text);
                item.MeasureUnit = comboBoxMeasUnit.SelectedIndex;
                Program.hsdb.SaveChanges();
                ShowItems();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewPhones.SelectedItems.Count == 1)
                {
                    Items item = listViewPhones.SelectedItems[0].Tag as Items;
                    Program.hsdb.Items.Remove(item);
                    Program.hsdb.SaveChanges();
                    ShowItems();
                }
                comboBoxManufacturerer.SelectedIndex = 0;
                textBoxName.Text = "";
                textBoxPrice.Text = "";
                comboBoxMeasUnit.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить запись, возможно она используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
