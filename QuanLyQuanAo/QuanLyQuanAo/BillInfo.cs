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
        private const int ID_DEFAULT = 1;
        private const int ERROR = -100;


        List<BillProductOut> productsOut = new List<BillProductOut>();
        List<ProductInfo> productsEntry = new List<ProductInfo>();

        private double paymentPriceOut = 0;
        private double paymentPriceEntry = 0;

        private State stateClient = State.Unavailable;
        private State stateSupplier = State.Available;
        private State stateProduct = State.Available;


        CultureInfo culture = new CultureInfo("vi-VN");
        public BillInfo()
        {
            InitializeComponent();
            LoadDataExport();
            LoadClientData();
            LoadDataImport();
        }
        #region Export

        #region Events

        private void addButton_Click(object sender, EventArgs e)
        {
            int idProduct = (int)dataViewProduct.SelectedCells[0].OwningRow.Cells["IDProduct"].Value;

            int amount = Convert.ToInt32(numericAmountOut.Value);

            if (amount == 0)
            {
                MessageBox.Show("Không hợp lệ. Số lượng nhập vào đang là 0", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BillProductOut billInfo = BillInfoDAO.Instance.GetBillProductOut(idProduct, amount);

            CheckAvailable(listViewProductOut, billInfo);

            if (CheckAmount(billInfo))
            {
                MessageBox.Show("Không hợp lệ !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem listView = CreateListViewItem(billInfo);

            listViewProductOut.Items.Add(listView);

            productsOut.Add(billInfo);

            PrintTotalPrice();
            Payment();
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            int idClient = ID_DEFAULT;

            if (listViewProductOut.Items.Count == 0)
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
                if (BillInfoDAO.Instance.InsertBillExport(idClient, productsOut))
                {
                    MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadDataExport();
                    ClearBilDisplay();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewProductOut.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }          

            ListViewItem item = listViewProductOut.SelectedItems[0];

            BillProductOut billInfo = item.Tag as BillProductOut;

            paymentPriceOut -= (billInfo.PriceOut * billInfo.Amount);

            productsOut.Remove(billInfo);
            listViewProductOut.Items.Remove(item);

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

        private void LoadDataExport()
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
            productsOut.Clear();
            ClearListView();
            ClearPriceAndPayment();
            SetAmountToDefault();
            SetDiscountToDefault();
            VisibleForm();      
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = ProductDAO.Instance.GetProduct();

            InvisibleAttributes(dataViewProduct, new object[] { "IDProduct" , "Branch", "Unit", "PriceIn" });
        }

        private void AddBinding()
        {
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            textBoxType.DataBindings.Add("Text", dataViewProduct.DataSource, "Type");
        }

        private void CheckAvailable(ListView listView, BillProductOut billInfo)
        {
            int index = 0;

            foreach (ListViewItem item in listView.Items)
            {
                BillProductOut preBillInfo = item.Tag as BillProductOut;
                if (preBillInfo.IdProduct == billInfo.IdProduct)
                {
                    int tempAmount = preBillInfo.Amount;
                    billInfo.Amount += tempAmount;
                    billInfo.TotalPrice = billInfo.Amount * billInfo.PriceOut;
                    if (CheckAmount(billInfo))
                    {
                        break;
                    }
                    productsOut.RemoveAt(index);
                    listView.Items.Remove(item);
                    paymentPriceOut -= tempAmount * billInfo.PriceOut;
                    break;
                }
                index++;
            }
        }


        private bool CheckAmount(BillProductOut billInfo)
        {
            bool overflow = billInfo.Amount > billInfo.MaxAmount;
            bool underflow = billInfo.Amount < 1;
            return overflow || underflow;
        }


        private ListViewItem CreateListViewItem(BillProductOut billInfo)
        {
            ListViewItem listView = new ListViewItem(billInfo.Name.ToString()) { Tag = billInfo };
            listView.SubItems.Add(billInfo.Amount.ToString());
            listView.SubItems.Add(billInfo.PriceOut.ToString());
            paymentPriceOut += billInfo.TotalPrice;
            listView.SubItems.Add(billInfo.TotalPrice.ToString());

            return listView;
        }

        private void PrintTotalPrice()
        {
            textBoxTotalPrice.Text = paymentPriceOut.ToString("c", culture);
        }

        private void Payment()
        {
            int discount = Convert.ToInt32(numericDiscount.Value);
            double price = paymentPriceOut * (PERCENT - discount) / PERCENT;

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
            listViewProductOut.Items.Clear();
        }

        private void ClearPriceAndPayment()
        {
            paymentPriceOut = 0;
            textBoxTotalPrice.Text = "0";
            textBoxPayment.Text = "0";
        }

        private void SetAmountToDefault()
        {
            numericAmountOut.Value = 0;
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
        private void SetBillInfoToDefault()
        {
            LoadSupplierData();

            stateProduct = State.Available;

            listViewProductEntry.Items.Clear();
            productsEntry.Clear();
            paymentPriceEntry = 0;


            confirmButton.Enabled = false;
            availableSupButton.Enabled = true;
            unavailableSupButton.Enabled = true;
            dataViewSupplier.Enabled = true;
            availableProcButton.Enabled = true;

            panelAvailableProduct.Visible = false;
            panelUnavailableProduct.Visible = false;
            panelStateProduct.Visible = false;
            panelAmount.Visible = false;

            ReleaseTextBox();
            SwitchSupplierInfo(true);
            PrintTotalPriceEntry();
        }

        private void LoadDataImport()
        {
            LoadSupplierData();
            LoadTypeIntoComboBox();
            LoadColorIntoComboBox();
            LoadSizeIntoComboBox();
        }

        private void LoadSupplierData()
        { 
            dataViewSupplier.DataSource = SupplierDAO.Instance.GetSupplier();

            InvisibleAttributes(dataViewSupplier, new object[] { "IDSupplier", "Phone" });
        }

        private void GetSupplierAndLoadProduct()
        {
            string supplierName = dataViewSupplier.SelectedCells[0].OwningRow.Cells["Name"].Value.ToString();
            int idSupplier = (int)dataViewSupplier.SelectedCells[0].OwningRow.Cells["IDSupplier"].Value;

            labelInfo.Text = "Các sản phẩm của " + supplierName;

            LoadProductBySupplier(idSupplier);
        }

        private void LoadProductBySupplier(int idSupplier)
        {
            dataViewProduct2.DataSource = ProductDAO.Instance.GetProductBySupplier(idSupplier);

            InvisibleAttributes(dataViewProduct2, new object[] { "IDProduct", "Type", "Branch", "Unit", "PriceOut" });
        }

        private void AddProductIntoListView()
        {
            int idProduct = (int)dataViewProduct2.SelectedCells[0].OwningRow.Cells["IDProduct"].Value;

            int amount = Convert.ToInt32(numericAmountEntry.Value);

            ProductInfo product = ProductDAO.Instance.GetProductByIDAndAmount(idProduct, amount);

            CheckAvailable(listViewProductEntry, product);

            if (CheckAmount(product))
            {
                MessageBox.Show("Không hợp lệ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            productsEntry.Add(product);

            ListViewItem listView = CreateListViewItem(product);

            listViewProductEntry.Items.Add(listView);

            //foreach (ProductInfo item in productsEntry)
            //{
            //    MessageBox.Show(item.Amount.ToString());
            //}

            PrintTotalPriceEntry();
        }

        private void ConfirmEntry(int idSupplier, List<ProductInfo> products)
        {
            if (MessageBox.Show("Bạn có chắc chắn xác nhận thanh toán không ?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (BillInfoDAO.Instance.InsertBillImport(idSupplier, products))
                {
                    MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetBillInfoToDefault();
                }
            }
        }

        private void AddNewProductHadSupplier()
        {
            string name = textBoxNewName.Text;
            string type = comboBoxType.Text;
            string branch = (string)dataViewSupplier.SelectedCells[0].OwningRow.Cells["Branch"].Value;
            string color = comboBoxColor.Text;
            string size = comboBoxSize.Text;
            string unit = textBoxUnit.Text;
            double priceIn = Convert.ToDouble(textBoxPriceIn.Text);
            double priceOut = Convert.ToDouble(textBoxPriceOut.Text);

            int newAmount = (int)numericAmountEntry.Value;

            ProductInfo newProduct = new ProductInfo(-1, name, type, branch, color,
                                                    unit, size, newAmount, priceIn, priceOut);

            if (CheckAmount(newProduct))
            {
                MessageBox.Show("Không hợp lệ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            productsEntry.Add(newProduct);

            ListViewItem listView = CreateListViewItem(newProduct);

            listViewProductEntry.Items.Add(listView);

            PrintTotalPriceEntry();
        }

        private void AddNewProductHadNotSupplier()
        {
            string name = textBoxNewName.Text;
            string type = comboBoxType.Text;
            string branch = textBoxBranch.Text;
            string color = comboBoxColor.Text;
            string size = comboBoxSize.Text;
            string unit = textBoxUnit.Text;
            double priceIn = Convert.ToDouble(textBoxPriceIn.Text);
            double priceOut = Convert.ToDouble(textBoxPriceOut.Text);

            int newAmount = (int)numericAmountEntry.Value;

            ProductInfo newProduct = new ProductInfo(-1, name, type, branch, color,
                                                    unit, size, newAmount, priceIn, priceOut);

            if (CheckAmount(newProduct))
            {
                MessageBox.Show("Không hợp lệ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            productsEntry.Add(newProduct);

            ListViewItem listView = CreateListViewItem(newProduct);

            listViewProductEntry.Items.Add(listView);

            PrintTotalPriceEntry();
        }
        private ListViewItem CreateListViewItem(ProductInfo product)
        {
            ListViewItem listView = new ListViewItem(product.Name.ToString()) { Tag = product };
            listView.SubItems.Add(product.Amount.ToString());
            listView.SubItems.Add(product.PriceIn.ToString());
            listView.SubItems.Add((product.Amount * product.PriceIn).ToString());
            paymentPriceEntry += product.Amount * product.PriceIn;

            return listView;
        }

        private void CheckAvailable(ListView listView, ProductInfo product)
        {
            int index = 0;

            foreach (ListViewItem item in listView.Items)
            {
                
                ProductInfo preProduct = item.Tag as ProductInfo;
                if (preProduct.IdProduct == product.IdProduct)
                {
                    int tempAmout = preProduct.Amount;
                    product.Amount += tempAmout;
                    if (CheckAmount(product))
                    {
                        break;
                    }
                    productsEntry.RemoveAt(index);
                    paymentPriceEntry -= tempAmout * product.PriceIn;
                    listView.Items.Remove(item);
                    break;
                }
                index++;
            }

        }

        private int GetNewSupplier()
        {
            int newID = ERROR;
            string name = textBoxSupName.Text;
            string phone = textBoxSupPhone.Text;
            string email = textBoxSupEmail.Text;
            string address = textBoxSupAddress.Text;
            string branch = textBoxBranch.Text;

            if (SupplierDAO.Instance.InsertSupplier(name, branch, phone, email, address))
            {
                newID = SupplierDAO.Instance.GetNewIDSupplier();
            }
            return newID;
        }

        private void LoadTypeIntoComboBox()
        {
            comboBoxType.DataSource = TypeDAO.Instance.GetTypeInfo();
            comboBoxType.DisplayMember = "Name";
        }

        private void LoadColorIntoComboBox()
        {
            comboBoxColor.DataSource = ColorDAO.Instance.GetColor();
            comboBoxColor.DisplayMember = "NameColor";
        }

        private void LoadSizeIntoComboBox()
        {
            comboBoxSize.DataSource = SizeDAO.Instance.GetSize();
            comboBoxSize.DisplayMember = "SizeInfo";
        }

        private bool CheckAmount(ProductInfo productEntry)
        {
            return productEntry.Amount < 1;
        }

        private void PrintTotalPriceEntry()
        {
            textBoxPriceEntry.Text = paymentPriceEntry.ToString("c", culture);
        }

        private void ReleaseTextBox()
        {
            textBoxNewName.Text = "";
            comboBoxType.SelectedIndex = 0;
            comboBoxColor.SelectedIndex = 0;
            comboBoxSize.SelectedIndex= 0;
            textBoxUnit.Text = "";
            textBoxPriceIn.Text = "";
            textBoxPriceOut.Text = "";

            textBoxSupName.Text = "";
            textBoxBranch.Text = "";
            textBoxSupPhone.Text = "";
            textBoxSupAddress.Text = "";
            textBoxSupEmail.Text = "";
        }

        private void SwitchSupplierInfo(bool status)
        {
            textBoxSupName.Enabled = status;
            textBoxSupPhone.Enabled = status;
            textBoxSupEmail.Enabled = status;
            textBoxSupAddress.Enabled = status;
            textBoxBranch.Enabled = status;
        }
        #endregion

        #region Events

        private void enterSupplierButton_Click(object sender, EventArgs e)
        {
            confirmButton.Enabled = true;
            availableSupButton.Enabled = false;
            unavailableSupButton.Enabled = false;
            dataViewSupplier.Enabled = false;

            panelAmount.Visible = true;
            panelStateProduct.Visible = true;

            switch(stateSupplier)
            {
                case State.Available:
                    stateProduct = State.Available;
                    panelAvailableProduct.Visible = true;
                    GetSupplierAndLoadProduct();
                    break;
                case State.Unavailable:
                    stateProduct = State.Unavailable;
                    panelUnavailableProduct.Visible = true;
                    availableProcButton.Enabled = false;
                    SwitchSupplierInfo(false);
                    break;
            }
        }

        private void addButton2_Click(object sender, EventArgs e)
        {
            switch (stateProduct)
            {
                case State.Available:
                    AddProductIntoListView();
                    break;
                case State.Unavailable:
                    if (stateSupplier == State.Available)
                        AddNewProductHadSupplier();
                    else
                        AddNewProductHadNotSupplier();
                    break;
            }
        }

        private void deleteButton2_Click(object sender, EventArgs e)
        {
            if (listViewProductEntry.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem item = listViewProductEntry.SelectedItems[0];

            ProductInfo product = item.Tag as ProductInfo;

            paymentPriceEntry -= (product.PriceIn * product.Amount);

            productsEntry.Remove(product);

            listViewProductEntry.Items.Remove(item);

            PrintTotalPriceEntry();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (listViewProductEntry.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idSupplier = ID_DEFAULT;

            switch (stateSupplier)
            {
                case State.Available:
                    idSupplier = (int)dataViewSupplier.SelectedCells[0].OwningRow.Cells["IDSupplier"].Value;
                    break;
                case State.Unavailable:
                    idSupplier = GetNewSupplier();
                    break;
            }
            ConfirmEntry(idSupplier, productsEntry);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            SetBillInfoToDefault();
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

        private void availableProcButton_Click(object sender, EventArgs e)
        {
            stateProduct = State.Available;
            panelAvailableProduct.Visible = true;
            panelUnavailableProduct.Visible = false;
        }

        private void unavailableProcButton_Click_1(object sender, EventArgs e)
        {
            stateProduct = State.Unavailable;
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
