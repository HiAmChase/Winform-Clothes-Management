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
        private const int PERCENT = 100;
        List<BillProduct> products = new List<BillProduct>();
        private double totalPrice = 0;
        private int inputClientFlag = 1;
        CultureInfo culture = new CultureInfo("vi-VN");
        public BillInfo()
        {
            InitializeComponent();
            LoadData();
            LoadClientData();
        }

        #region Events

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

            CheckAvailable(listViewProduct, billInfo);

            if (CheckAmount(billInfo))
            {
                MessageBox.Show("Không hợp lệ !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem listView = CreateListViewItem(billInfo);

            listViewProduct.Items.Add(listView);

            products.Add(billInfo);

            PrintTotalPrice();
            Payment();
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xác nhận thanh toán không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (BillInfoDAO.Instance.InsertBillExportInfo(2, products))
                {
                    MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadData();
                    ClearBilDisplay();
                }
            }
        }

        private void formDisplay_Click(object sender, EventArgs e)
        {
            VisibleForm();
        }

        private void clientDisplay_Click(object sender, EventArgs e)
        {
            VisibleClientData();
        }

        private void numericDiscount_ValueChanged(object sender, EventArgs e)
        {
            Payment();
        }

        #endregion

        #region Methods

        private void LoadData()
        {
            LoadProduct();
            AddBinding();
        }

        private void LoadClientData()
        {
            dataViewClient.DataSource = ClientDAO.Instance.GetClient();

            dataViewClient.Columns["IDClient"].Visible = false;
        }

        private void ClearBilDisplay()
        {
            products.Clear();
            ClearListView();
            ClearPriceAndPayment();
            SetAmountToDefault();
            SetDiscountToDefault();
            VisibleForm();
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = ProductDAO.Instance.GetProduct();

            InvisibleAttributes();
        }

        private void AddBinding()
        {
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            textBoxType.DataBindings.Add("Text", dataViewProduct.DataSource, "Type");
        }

        private void InvisibleAttributes()
        {
            dataViewProduct.Columns["IDProduct"].Visible = false;
            dataViewProduct.Columns["Branch"].Visible = false;
            dataViewProduct.Columns["Unit"].Visible = false;
        }

        private void ClearBinding()
        {
            textBoxProduct.DataBindings.Clear();
            textBoxType.DataBindings.Clear();
        }

        private void ClearListView()
        {
            listViewProduct.Items.Clear();
        }

        private void ClearPriceAndPayment()
        {
            totalPrice = 0;
            textBoxTotalPrice.Text = "0";
            textBoxPayment.Text = "0";
        }

        private void SetAmountToDefault()
        {
            numericAmount.Value = 0;
        }

        private void SetDiscountToDefault()
        {
            numericDiscount.Value = 0;
        }

        private void CheckAvailable(ListView listView, BillProduct billInfo)
        {
            int index = 0;

            foreach (ListViewItem item in listView.Items)
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

        private void Payment()
        {
            int discount = Convert.ToInt32(numericDiscount.Value);
            double price = totalPrice * (PERCENT - discount) / PERCENT;

            textBoxPayment.Text = price.ToString("c", culture);
        }

        private void VisibleForm()
        {
            inputClientFlag = 1;
            panelForm.Visible = true;
            dataViewClient.Visible = false;
        }

        private void VisibleClientData()
        {
            inputClientFlag = 0;
            panelForm.Visible = false;
            dataViewClient.Visible = true;
        }

        #endregion
    }
}
