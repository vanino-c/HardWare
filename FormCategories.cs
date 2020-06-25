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
    public partial class FormCategories : Form
    {
        public FormCategories()
        {
            InitializeComponent();
            ShowCategories();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewProviders.SelectedItems.Count == 1)
                {
                    Categories categories = listViewProviders.SelectedItems[0].Tag as Categories;
                    foreach (Deals deal in Program.hsdb.Deals)
                    {
                        if (deal.Type == categories.Id)
                        {
                            MessageBox.Show("Невозможно удалить запись, она имеет связаные товары!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    Program.hsdb.Categories.Remove(categories);
                    Program.hsdb.SaveChanges();
                    ShowCategories();
                }
                textBoxProvider.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить запись, возможно она используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewProviders.SelectedItems.Count == 1)
            {
                Categories category = listViewProviders.SelectedItems[0].Tag as Categories;
                category.Name = textBoxProvider.Text;
                Program.hsdb.SaveChanges();
                ShowCategories();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxProvider.Text != "")
            {
                Categories category = new Categories();
                category.Name = textBoxProvider.Text;
                Program.hsdb.Categories.Add(category);
                Program.hsdb.SaveChanges();
                ShowCategories();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProviders.SelectedItems.Count == 1)
            {
                Categories categories = listViewProviders.SelectedItems[0].Tag as Categories;
                textBoxProvider.Text = categories.Name;
            }
            else
            {
                textBoxProvider.Text = "";
            }
        }

        void ShowCategories()
        {
            listViewProviders.Items.Clear();
            foreach (Categories category in Program.hsdb.Categories)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    category.Id.ToString(),
                    category.Name
                });
                item.Tag = category;
                listViewProviders.Items.Add(item);
            }
            listViewProviders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
