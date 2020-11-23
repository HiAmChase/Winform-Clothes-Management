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
    public enum State { Unavailable, Available};
    public partial class BillInfo : Form
    {
        private const int PERCENT = 100;
        //************************Lưu ý: ID_CLIENT_DEFAULT******************
        private const int ID_CLIENT_DEFAULT = 1;
        private const int ERROR = -100;
        List<BillProduct> products = new List<BillProduct>();
        private double totalPrice = 0;
        private State stateClient = State.Unavailable;
        private State stateSupplier = State.Unavailable;
        CultureInfo culture = new CultureInfo("vi-VN");
        public BillInfo()
        {
            InitializeComponent();
            LoadData();
            LoadClientData();
            LoadSupplierData();
        }
        #region Export

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
            int idClient = ID_CLIENT_DEFAULT;

            if (listViewProduct.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch(stateClient)
            {
                case State.Unavailable:
                    if (TextBoxIsEmpty())
                    {
                        //Không thay đổi IDClient
                        if (MessageBox.Show("Dữ liệu khách hàng đang trống. Bạn có chắc muốn thực hiện thanh toán ?", "Thông báo",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                            return;
                    }
                    //Có dữ liệu
                    else
                    {
                        idClient = GetNewIDClient();
                    }
                    break;
                case State.Available:
                    idClient = (int)dataViewClient.SelectedCells[0].OwningRow.Cells["IDClient"].Value;
                    break;
                default:
                    break;
            }

            if (MessageBox.Show("Bạn có chắc chắn xác nhận thanh toán không ?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (BillInfoDAO.Instance.InsertBillExport(idClient, products))
                {
                    MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadData();
                    ClearBilDisplay();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewProduct.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }          

            ListViewItem item = listViewProduct.SelectedItems[0];

            BillProduct billInfo = item.Tag as BillProduct;

            totalPrice -= (billInfo.Price * billInfo.Amount);

            products.Remove(billInfo);
            listViewProduct.Items.Remove(item);

            PrintTotalPrice();
            Payment();
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

            InvisibleAttributes(dataViewProduct, new object[] { "IDProduct" , "Branch", "Unit" });
        }

        private void AddBinding()
        {
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            textBoxType.DataBindings.Add("Text", dataViewProduct.DataSource, "Type");
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

        private bool TextBoxIsEmpty()
        {
            bool checkName = textBoxName.Text.Equals("");
            bool checkPhone = textBoxPhone.Text.Equals("");
            bool checkEmail = textBoxEmail.Text.Equals("");
            bool checkAddress= textBoxAddress.Text.Equals("");

            return checkName || checkPhone || checkEmail || checkAddress;
        }

        private int GetNewIDClient()
        {
            int idClient = ERROR;
            string name = textBoxName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;

            if (ClientDAO.Instance.InsertClient(name, phone, email, address))
            {
                idClient = ClientDAO.Instance.GetIDClientMax();
            }

            return idClient;
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

        private void VisibleForm()
        {
            stateClient = State.Unavailable;
            panelForm.Visible = true;
            dataViewClient.Visible = false;
        }

        private void VisibleClientData()
        {
            stateClient = State.Available;
            panelForm.Visible = false;
            dataViewClient.Visible = true;
        }

        #endregion

        #endregion

        #region Methods

        private void LoadSupplierData()
        { 
            dataViewSupplier.DataSource = SupplierDAO.Instance.GetSupplier();

            InvisibleAttributes(dataViewSupplier, new object[] { "IDSupplier", "Phone" });
        }

        private void LoadProductBySupplier(int idSupplier)
        {
            dataViewProduct2.DataSource = ProductDAO.Instance.GetProductBySupplierName(idSupplier);

            InvisibleAttributes(dataViewProduct2, new object[] { "IDProduct", "Type", "Branch", "Unit" });
        }

        #endregion

        #region Events

        private void enterSupplierButton_Click(object sender, EventArgs e)
        {

            availableSupButton.Enabled = false;
            unavailableSupButton.Enabled = false;

            dataViewSupplier.Enabled = false;
            panelStateProduct.Visible = true;
            panelAvailableProduct.Visible = true;

            string supplierName = dataViewSupplier.SelectedCells[0].OwningRow.Cells["Name"].Value.ToString();
            int idSupplier = (int)dataViewSupplier.SelectedCells[0].OwningRow.Cells["IDSupplier"].Value;

            LoadProductBySupplier(idSupplier);
            labelInfo.Text = "Các sản phẩm của " + supplierName;
        }

        private void availableSupButton_Click(object sender, EventArgs e)
        {
            stateSupplier = State.Available;
            dataViewSupplier.Visible = true;
            panelUnavailableSup.Visible = false;
        }

        private void unavailableSupButton_Click(object sender, EventArgs e)
        {
            stateSupplier = State.Unavailable;
            dataViewSupplier.Visible = false;
            panelUnavailableSup.Visible = true;
        }

        private void unavailableProcButton_Click(object sender, EventArgs e)
        {
            panelAvailableProduct.Visible = true;
        }

        private void availableProcButton_Click(object sender, EventArgs e)
        {
            panelAvailableProduct.Visible = true;
            panelUnavailableProduct.Visible = false;
        }

        private void unavailableProcButton_Click_1(object sender, EventArgs e)
        {
            panelUnavailableProduct.Visible = true;
            panelAvailableProduct.Visible = false;
        }

        #endregion


        private void InvisibleAttributes(DataGridView dataView, object[] parameters = null)
        {
            foreach (string item in parameters)
            {
                dataView.Columns[item].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
