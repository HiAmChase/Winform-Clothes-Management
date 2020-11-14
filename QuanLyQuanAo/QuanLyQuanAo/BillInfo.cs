using QuanLyQuanAo.DAO;
using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAo
{
    public partial class BillInfo : Form
    {
        public BillInfo()
        {
            InitializeComponent();
            LoadProduct();
            AddBinding();
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = ProductDAO.Instance.GetProduct();
            dataViewProduct.Columns["IDProduct"].Visible = false;
            dataViewProduct.Columns["Branch"].Visible = false;
            dataViewProduct.Columns["Unit"].Visible = false;
        }

        private void AddBinding()
        {
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            textBoxType.DataBindings.Add("Text", dataViewProduct.DataSource, "Type");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int idProduct = (int)dataViewProduct.SelectedCells[0].OwningRow.Cells["IDProduct"].Value;

            int amount = Convert.ToInt32(numericAmount.Value);

            if (amount == 0)
            {
                MessageBox.Show("Không hợp lệ. Số lượng nhập vào đang là 0", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BillProduct billInfo = BillInfoDAO.Instance.GetBillProduct(idProduct, amount);

            foreach (ListViewItem item in listViewProduct.Items)
            {
                if (item.Text.ToString() == billInfo.Name)
                {
                    int tempAmount = Convert.ToInt32(item.Tag);
                    billInfo.Amount += tempAmount;
                    if (CheckAmount(billInfo))
                    {
                        break;
                    }
                    listViewProduct.Items.Remove(item);
                    break;
                }
            }

            if (CheckAmount(billInfo))
            {
                MessageBox.Show("Không hợp lệ !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem listView = CreateListViewItem(billInfo);

            listViewProduct.Items.Add(listView);
        }

        private bool CheckAmount(BillProduct billInfo)
        {
            bool overflow = billInfo.Amount > billInfo.MaxAmount;
            bool underflow = billInfo.Amount < 1;
            return overflow || underflow;
        }

        private ListViewItem CreateListViewItem(BillProduct billInfo)
        {
            ListViewItem listView = new ListViewItem(billInfo.Name.ToString()) { Tag = billInfo.Amount.ToString() };
            listView.SubItems.Add(billInfo.Amount.ToString());
            listView.SubItems.Add(billInfo.Price.ToString());
            listView.SubItems.Add(billInfo.TotalPrice.ToString());

            return listView;
        }
    }
}
