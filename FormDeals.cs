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
    public partial class FormDeals : Form
    {
        public FormDeals()
        {
            InitializeComponent();
            ShowSellers();
            ShowCategories();
            comboBoxCategory.SelectedIndex = 0;
            ShowItems();
            comboBoxItem.SelectedIndex = 0;
            ShowDeals();
        }

        void ShowItems()
        {
            comboBoxItem.Items.Clear();
            string[] manufacturer =
            {
                "Россия",
                "Китай",
                "США",
                "Италия"
            };
            foreach (Items item in Program.hsdb.Items)
            {
                if (item.Category == Convert.ToInt32(comboBoxCategory.SelectedItem.ToString().Split('.')[0]))
                {
                    string[] sItem =
                    {
                        item.Id.ToString() + ".",
                        manufacturer[item.Manufacturer] + " " + item.Name,
                        item.Price.ToString() + "р",
                    };
                    comboBoxItem.Items.Add(string.Join(" ", sItem));
                }
            }
        }

        void ShowCategories()
        {
            foreach (Categories categories in Program.hsdb.Categories)
            {
                comboBoxCategory.Items.Add(categories.Id.ToString() + ". " + categories.Name);
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDeals.SelectedItems.Count == 1)
                {
                    Deals deals = listViewDeals.SelectedItems[0].Tag as Deals;
                    Program.hsdb.Deals.Remove(deals);
                    Program.hsdb.SaveChanges();
                    ShowDeals();
                }
                comboBoxItem.SelectedIndex = 0;
                comboBoxCategory.SelectedIndex = 0;
                textBoxTotal.Text = "0";
                textBoxCity.Text = "";
                textBoxHouse.Text = "";
                textBoxStreet.Text = "";
                numericUpDownCount.Value = 1;
                comboBoxSeller.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить запись, возможно она используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ShowSellers()
        {
            comboBoxSeller.Items.Clear();
            foreach (Sellers sellers in Program.hsdb.Sellers)
            {
                string[] item =
                {
                    sellers.Id.ToString() + ".",
                    sellers.Lastname,
                    sellers.Firstname.Substring(0, 1) + "." + sellers.Middlename.Substring(0, 1) + "."
                };
                comboBoxSeller.Items.Add(string.Join(" ", item));
            }
        }

        void ShowDeals()
        {
            listViewDeals.Items.Clear();
            foreach (Deals deals in Program.hsdb.Deals)
            {
                Items nItem = new Items();
                foreach (Items items in Program.hsdb.Items)
                {
                    if (items.Id == deals.Item)
                    {
                        nItem = items;
                        break;
                    }
                }
                string[] manufacturer =
                {
                    "Россия",
                    "Китай",
                    "США",
                    "Италия"
                };
                string[] sItem =
                {
                    nItem.Id.ToString() + ".",
                    manufacturer[nItem.Manufacturer] + " " + nItem.Name,
                    nItem.Price.ToString() + "р",
                };
                ListViewItem item = new ListViewItem(new string[]
                {
                    deals.Id.ToString(),
                    deals.Sellers.Id + ". " + deals.Sellers.Lastname + " " + deals.Sellers.Firstname.Substring(0, 1) + "." +  deals.Sellers.Middlename.Substring(0, 1) + ".",
                    deals.Categories.Name,
                    string.Join(" ", sItem),
                    deals.Price.ToString(),
                    deals.Adress
                });
                item.Tag = deals;
                listViewDeals.Items.Add(item);
            }
            listViewDeals.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDeals.SelectedItems.Count == 1)
            {
                if (comboBoxSeller.SelectedItem != null)
                {
                    if (comboBoxItem.SelectedItem != null)
                    {
                        string adress = string.Join(":", new string[]{
                            textBoxCity.Text,
                            textBoxStreet.Text,
                            textBoxHouse.Text
                    }   );
                        Deals deals = listViewDeals.SelectedItems[0].Tag as Deals;
                        deals.Price = Convert.ToDouble(textBoxTotal.Text);
                        deals.SellerID = Convert.ToInt32(comboBoxSeller.SelectedItem.ToString().Split('.')[0]);
                        deals.Count = Convert.ToInt32(numericUpDownCount.Value);
                        deals.Type = Convert.ToInt32(comboBoxCategory.SelectedItem.ToString().Split('.')[0]);
                        deals.Item = Convert.ToInt32(comboBoxItem.SelectedItem.ToString().Split('.')[0]);
                        deals.Adress = adress;
                        Program.hsdb.SaveChanges();
                        ShowDeals();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите продавца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxSeller.SelectedItem != null)
            {
                if (comboBoxItem.SelectedItem != null)
                {
                    Deals deals = new Deals();
                    string adress = string.Join(":", new string[]{
                        textBoxCity.Text,
                        textBoxStreet.Text,
                        textBoxHouse.Text
                    });
                    
                    deals.Price = Convert.ToDouble(textBoxTotal.Text);
                    deals.SellerID = Convert.ToInt32(comboBoxSeller.SelectedItem.ToString().Split('.')[0]);
                    deals.Count = Convert.ToInt32(numericUpDownCount.Value);
                    deals.Type = Convert.ToInt32(comboBoxCategory.SelectedItem.ToString().Split('.')[0]);
                    deals.Item = Convert.ToInt32(comboBoxItem.SelectedItem.ToString().Split('.')[0]);
                    deals.Adress = adress;
                    Program.hsdb.Deals.Add(deals);
                    Program.hsdb.SaveChanges();
                    ShowDeals();
                }
            }
            else
            {
                MessageBox.Show("Выберите продавца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Total()
        {
            if (comboBoxItem.SelectedItem != null)
            {
                Items item = Program.hsdb.Items.Find(Convert.ToInt32(comboBoxItem.SelectedItem.ToString().Split('.')[0]));
                double total = item.Price;
                total *= Convert.ToDouble(numericUpDownCount.Value);
                textBoxTotal.Text = total.ToString("0.00");
            }
        }
        private void listViewDeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDeals.SelectedItems.Count == 1)
            {
                Deals deals = listViewDeals.SelectedItems[0].Tag as Deals;
                comboBoxSeller.SelectedIndex = comboBoxSeller.FindString(deals.SellerID.ToString());

                comboBoxCategory.SelectedIndex = comboBoxCategory.FindString(deals.Type.ToString());
                comboBoxItem.SelectedIndex = comboBoxItem.FindString(deals.Item.ToString());
                string[] adress = deals.Adress.Split(':');
                textBoxCity.Text = adress[0];
                textBoxHouse.Text = adress[1];
                textBoxStreet.Text = adress[2];
                numericUpDownCount.Value = deals.Count;
                Total();
            }
            else
            {
                comboBoxItem.SelectedIndex = 0;
                comboBoxCategory.SelectedIndex = 0;
                textBoxTotal.Text = "0";
                textBoxCity.Text = "";
                textBoxHouse.Text = "";
                textBoxStreet.Text = "";
                numericUpDownCount.Value = 1;
                comboBoxSeller.SelectedItem = null;
            }
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total();
        }

        private void numericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
            Total();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowItems();
            comboBoxItem.SelectedIndex = 0;
            Total();
        }
    }
}
