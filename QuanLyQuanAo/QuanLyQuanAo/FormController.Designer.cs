namespace QuanLyQuanAo
{
    partial class FormController
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
            this.buttonProduct = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonBill = new System.Windows.Forms.Button();
            this.buttonSupplier = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonProduct
            // 
            this.buttonProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProduct.Location = new System.Drawing.Point(4, 4);
            this.buttonProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(163, 143);
            this.buttonProduct.TabIndex = 0;
            this.buttonProduct.Text = "Quản lý sản phẩm";
            this.buttonProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.ProductButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonBill);
            this.panel1.Controls.Add(this.buttonSupplier);
            this.panel1.Controls.Add(this.buttonClient);
            this.panel1.Controls.Add(this.buttonProduct);
            this.panel1.Location = new System.Drawing.Point(265, 197);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 149);
            this.panel1.TabIndex = 1;
            // 
            // buttonBill
            // 
            this.buttonBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBill.Location = new System.Drawing.Point(516, 4);
            this.buttonBill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBill.Name = "buttonBill";
            this.buttonBill.Size = new System.Drawing.Size(163, 143);
            this.buttonBill.TabIndex = 3;
            this.buttonBill.Text = "Quản lý hóa đơn";
            this.buttonBill.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBill.UseVisualStyleBackColor = true;
            this.buttonBill.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // buttonSupplier
            // 
            this.buttonSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupplier.Location = new System.Drawing.Point(345, 4);
            this.buttonSupplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSupplier.Name = "buttonSupplier";
            this.buttonSupplier.Size = new System.Drawing.Size(163, 143);
            this.buttonSupplier.TabIndex = 2;
            this.buttonSupplier.Text = "Quản lý nhà cung cấp";
            this.buttonSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSupplier.UseVisualStyleBackColor = true;
            this.buttonSupplier.Click += new System.EventHandler(this.buttonSupplier_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClient.Location = new System.Drawing.Point(175, 2);
            this.buttonClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(163, 143);
            this.buttonClient.TabIndex = 1;
            this.buttonClient.Text = "Quản lý khách hàng";
            this.buttonClient.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 145);
            this.button1.TabIndex = 2;
            this.button1.Text = "Quản lý nhân viên:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 641);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Màn hình chính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormController_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonBill;
        private System.Windows.Forms.Button buttonSupplier;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button button1;
    }
}

