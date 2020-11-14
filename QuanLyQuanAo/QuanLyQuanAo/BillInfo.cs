using QuanLyQuanAo.DAO;
using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAo
{
    public partial class BillInfo : Form
    {
        List<BillProduct> products = new List<BillProduct>();
        private double totalPrice = 0;
        CultureInfo culture = new CultureInfo("vi-VN");
        public BillInfo()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadProduct();
            AddBinding();
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = ProductDAO.Instance.GetProduct();

            InvisibleAttributes();
        }

        private void InvisibleAttributes()
        {
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

            int index = 0;

            foreach (ListViewItem item in listViewProduct.Items)
            {
                BillProduct preBillInfo = item.Tag as BillProduct;
                if (preBillInfo.IdProduct == billInfo.IdProduct)
                {
                    int tempAmount = Convert.ToInt32(preBillInfo.Amount.ToString());
                    billInfo.Amount += tempAmount;
                    billInfo.TotalPrice = billInfo.Amount * billInfo.Price;
                    if (CheckAmount(billInfo))
                    {
                        break;
                    }
                    products.RemoveAt(index);
                    listViewProduct.Items.Remove(item);
                    totalPrice -= tempAmount * billInfo.Price;
                    break;
                }
                index++;
            }

            if (CheckAmount(billInfo))
            {
                MessageBox.Show("Không hợp lệ !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem listView = CreateListViewItem(billInfo);

            products.Add(billInfo);

            listViewProduct.Items.Add(listView);

            PrintTotalPrice();
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xác nhận thanh toán không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (BillInfoDAO.Instance.InsertBillExportInfo(2, products))
                {
                    MessageBox.Show("Xong");
                    ClearBinding();
                    LoadData();
                }
            } 
        }

        private void ClearBinding()
        {
            textBoxProduct.DataBindings.Clear();
            textBoxType.DataBindings.Clear();
        }

        private bool CheckAmount(BillProduct billInfo)
        {
            bool overflow = billInfo.Amount > billInfo.MaxAmount;
            bool underflow = billInfo.Amount < 1;
            return overflow || underflow;
        }

        private ListViewItem CreateListViewItem(BillProduct billInfo)
        {
            ListViewItem listView = new ListViewItem(billInfo.Name.ToString()) { Tag = billInfo };
            listView.SubItems.Add(billInfo.Amount.ToString());
            listView.SubItems.Add(billInfo.Price.ToString());
            totalPrice += billInfo.TotalPrice;
            listView.SubItems.Add(billInfo.TotalPrice.ToString());

            return listView;
        }

        private void PrintTotalPrice()
        {
            textBoxTotalPrice.Text = totalPrice.ToString("c", culture);
        }
    }
}
