namespace QuanLyQuanAo
{
    partial class BillInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.billImport = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataViewClient = new System.Windows.Forms.DataGridView();
            this.clientDisplay = new System.Windows.Forms.Button();
            this.formDisplay = new System.Windows.Forms.Button();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewProduct = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataViewProduct = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxPayment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericDiscount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.payButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.numericAmount = new System.Windows.Forms.NumericUpDown();
            this.deleteButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.billImport.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewProduct)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscount)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // billImport
            // 
            this.billImport.Controls.Add(this.tabPage1);
            this.billImport.Controls.Add(this.tabPage2);
            this.billImport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billImport.Location = new System.Drawing.Point(42, 12);
            this.billImport.Name = "billImport";
            this.billImport.SelectedIndex = 0;
            this.billImport.Size = new System.Drawing.Size(1200, 737);
            this.billImport.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 703);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xuất hóa đơn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataViewClient);
            this.tabPage2.Controls.Add(this.clientDisplay);
            this.tabPage2.Controls.Add(this.formDisplay);
            this.tabPage2.Controls.Add(this.textBoxTotalPrice);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.listViewProduct);
            this.tabPage2.Controls.Add(this.dataViewProduct);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panelForm);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 703);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xuất hóa đơn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataViewClient
            // 
            this.dataViewClient.AllowUserToAddRows = false;
            this.dataViewClient.AllowUserToDeleteRows = false;
            this.dataViewClient.AllowUserToResizeColumns = false;
            this.dataViewClient.AllowUserToResizeRows = false;
            this.dataViewClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewClient.Location = new System.Drawing.Point(6, 465);
            this.dataViewClient.Name = "dataViewClient";
            this.dataViewClient.ReadOnly = true;
            this.dataViewClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewClient.Size = new System.Drawing.Size(612, 218);
            this.dataViewClient.TabIndex = 20;
            this.dataViewClient.VirtualMode = true;
            this.dataViewClient.Visible = false;
            // 
            // clientDisplay
            // 
            this.clientDisplay.Location = new System.Drawing.Point(146, 431);
            this.clientDisplay.Name = "clientDisplay";
            this.clientDisplay.Size = new System.Drawing.Size(147, 28);
            this.clientDisplay.TabIndex = 19;
            this.clientDisplay.Text = "Chưa biết tên";
            this.clientDisplay.UseVisualStyleBackColor = true;
            this.clientDisplay.Click += new System.EventHandler(this.clientDisplay_Click);
            // 
            // formDisplay
            // 
            this.formDisplay.Location = new System.Drawing.Point(6, 431);
            this.formDisplay.Name = "formDisplay";
            this.formDisplay.Size = new System.Drawing.Size(134, 28);
            this.formDisplay.TabIndex = 18;
            this.formDisplay.Text = "Nhập thông tin";
            this.formDisplay.UseVisualStyleBackColor = true;
            this.formDisplay.Click += new System.EventHandler(this.formDisplay_Click);
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(1035, 575);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(148, 29);
            this.textBoxTotalPrice.TabIndex = 15;
            this.textBoxTotalPrice.Text = "0";
            this.textBoxTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(979, 578);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tổng";
            // 
            // listViewProduct
            // 
            this.listViewProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewProduct.FullRowSelect = true;
            this.listViewProduct.GridLines = true;
            this.listViewProduct.HideSelection = false;
            this.listViewProduct.Location = new System.Drawing.Point(755, 96);
            this.listViewProduct.Name = "listViewProduct";
            this.listViewProduct.Size = new System.Drawing.Size(428, 473);
            this.listViewProduct.TabIndex = 13;
            this.listViewProduct.UseCompatibleStateImageBehavior = false;
            this.listViewProduct.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sản phẩm";
            this.columnHeader1.Width = 145;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số lượng";
            this.columnHeader5.Width = 82;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đơn giá";
            this.columnHeader6.Width = 97;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Thành tiền";
            this.columnHeader7.Width = 100;
            // 
            // dataViewProduct
            // 
            this.dataViewProduct.AllowUserToAddRows = false;
            this.dataViewProduct.AllowUserToDeleteRows = false;
            this.dataViewProduct.AllowUserToResizeColumns = false;
            this.dataViewProduct.AllowUserToResizeRows = false;
            this.dataViewProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewProduct.Location = new System.Drawing.Point(6, 6);
            this.dataViewProduct.Name = "dataViewProduct";
            this.dataViewProduct.ReadOnly = true;
            this.dataViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewProduct.Size = new System.Drawing.Size(612, 419);
            this.dataViewProduct.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxPayment);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.numericDiscount);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.payButton);
            this.panel4.Location = new System.Drawing.Point(755, 610);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(431, 73);
            this.panel4.TabIndex = 12;
            // 
            // textBoxPayment
            // 
            this.textBoxPayment.Location = new System.Drawing.Point(158, 35);
            this.textBoxPayment.Name = "textBoxPayment";
            this.textBoxPayment.ReadOnly = true;
            this.textBoxPayment.Size = new System.Drawing.Size(182, 29);
            this.textBoxPayment.TabIndex = 17;
            this.textBoxPayment.Text = "0";
            this.textBoxPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Thành tiền";
            // 
            // numericDiscount
            // 
            this.numericDiscount.Location = new System.Drawing.Point(95, 36);
            this.numericDiscount.Name = "numericDiscount";
            this.numericDiscount.Size = new System.Drawing.Size(41, 29);
            this.numericDiscount.TabIndex = 10;
            this.numericDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDiscount.ValueChanged += new System.EventHandler(this.numericDiscount_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Giảm giá";
            // 
            // payButton
            // 
            this.payButton.Location = new System.Drawing.Point(346, 3);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(82, 67);
            this.payButton.TabIndex = 10;
            this.payButton.Text = "Thanh toán";
            this.payButton.UseVisualStyleBackColor = true;
            this.payButton.Click += new System.EventHandler(this.payButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.addButton);
            this.panel3.Controls.Add(this.numericAmount);
            this.panel3.Controls.Add(this.deleteButton);
            this.panel3.Location = new System.Drawing.Point(624, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 141);
            this.panel3.TabIndex = 10;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 45);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Thêm";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // numericAmount
            // 
            this.numericAmount.Location = new System.Drawing.Point(3, 105);
            this.numericAmount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericAmount.Name = "numericAmount";
            this.numericAmount.Size = new System.Drawing.Size(102, 29);
            this.numericAmount.TabIndex = 9;
            this.numericAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(3, 54);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 45);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Xóa";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxType);
            this.panel1.Controls.Add(this.textBoxProduct);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(755, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 84);
            this.panel1.TabIndex = 6;
            // 
            // textBoxType
            // 
            this.textBoxType.Enabled = false;
            this.textBoxType.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxType.Location = new System.Drawing.Point(158, 8);
            this.textBoxType.Multiline = true;
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(212, 27);
            this.textBoxType.TabIndex = 11;
            this.textBoxType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Enabled = false;
            this.textBoxProduct.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProduct.Location = new System.Drawing.Point(158, 42);
            this.textBoxProduct.Multiline = true;
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(212, 27);
            this.textBoxProduct.TabIndex = 9;
            this.textBoxProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(15, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 33);
            this.label12.TabIndex = 10;
            this.label12.Text = "Loại";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(15, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 28);
            this.label13.TabIndex = 8;
            this.label13.Text = "Tên sản phẩm";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.textBoxAddress);
            this.panelForm.Controls.Add(this.label6);
            this.panelForm.Controls.Add(this.textBoxEmail);
            this.panelForm.Controls.Add(this.label5);
            this.panelForm.Controls.Add(this.textBoxPhone);
            this.panelForm.Controls.Add(this.label3);
            this.panelForm.Controls.Add(this.textBoxName);
            this.panelForm.Controls.Add(this.label2);
            this.panelForm.Controls.Add(this.label1);
            this.panelForm.Location = new System.Drawing.Point(6, 465);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(612, 232);
            this.panelForm.TabIndex = 5;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(158, 162);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(451, 52);
            this.textBoxAddress.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LimeGreen;
            this.label6.Location = new System.Drawing.Point(16, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 31);
            this.label6.TabIndex = 40;
            this.label6.Text = "Địa chỉ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(158, 122);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(451, 27);
            this.textBoxEmail.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(16, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 31);
            this.label5.TabIndex = 38;
            this.label5.Text = "Email";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.Location = new System.Drawing.Point(158, 78);
            this.textBoxPhone.Multiline = true;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(451, 27);
            this.textBoxPhone.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 31);
            this.label3.TabIndex = 36;
            this.label3.Text = "Số điện thoại";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(158, 36);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(451, 27);
            this.textBoxName.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 31);
            this.label2.TabIndex = 34;
            this.label2.Text = "Họ và tên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, -7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thông tin khách hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(-1, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BillInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.billImport);
            this.Name = "BillInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill";
            this.billImport.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewProduct)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscount)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl billImport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericAmount;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button payButton;
        private System.Windows.Forms.DataGridView dataViewProduct;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericDiscount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.ListView listViewProduct;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPayment;
        private System.Windows.Forms.Button clientDisplay;
        private System.Windows.Forms.Button formDisplay;
        private System.Windows.Forms.DataGridView dataViewClient;
        private System.Windows.Forms.Button button1;
    }
}