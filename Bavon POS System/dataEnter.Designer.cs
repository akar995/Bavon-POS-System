namespace Bavon_POS_System
{
    partial class dataEnter
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enterBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemCodeTextBox = new System.Windows.Forms.TextBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.bardcodeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.purchaseDatePicker = new System.Windows.Forms.DateTimePicker();
            this.expirationDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.salePriceLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.purchasePriceTextBox = new System.Windows.Forms.TextBox();
            this.percentageTextBox = new System.Windows.Forms.TextBox();
            this.supplierTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableGrid);
            this.panel1.Location = new System.Drawing.Point(384, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 536);
            this.panel1.TabIndex = 36;
            // 
            // tableGrid
            // 
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.ItemCode,
            this.Item_Name,
            this.purchasePrice,
            this.percentage,
            this.quantity,
            this.salePrice,
            this.supplier,
            this.purchaseDate,
            this.expirationDate});
            this.tableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableGrid.Location = new System.Drawing.Point(0, 0);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.Size = new System.Drawing.Size(903, 536);
            this.tableGrid.TabIndex = 0;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Width = 125;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            // 
            // Item_Name
            // 
            this.Item_Name.HeaderText = "Item name";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            this.Item_Name.Width = 150;
            // 
            // purchasePrice
            // 
            this.purchasePrice.HeaderText = "Purchase Price";
            this.purchasePrice.Name = "purchasePrice";
            this.purchasePrice.Width = 150;
            // 
            // percentage
            // 
            this.percentage.HeaderText = "Percentage";
            this.percentage.Name = "percentage";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            // 
            // salePrice
            // 
            this.salePrice.HeaderText = "Sale Price";
            this.salePrice.Name = "salePrice";
            // 
            // supplier
            // 
            this.supplier.HeaderText = "Supplier";
            this.supplier.Name = "supplier";
            this.supplier.Width = 150;
            // 
            // purchaseDate
            // 
            this.purchaseDate.HeaderText = "Purchase Date";
            this.purchaseDate.Name = "purchaseDate";
            // 
            // expirationDate
            // 
            this.expirationDate.HeaderText = "Expiration Date";
            this.expirationDate.Name = "expirationDate";
            // 
            // enterBtn
            // 
            this.enterBtn.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.enterBtn.Location = new System.Drawing.Point(193, 500);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(146, 61);
            this.enterBtn.TabIndex = 33;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.deleteBtn.Location = new System.Drawing.Point(6, 382);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 32);
            this.deleteBtn.TabIndex = 32;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.addBtn.Location = new System.Drawing.Point(253, 382);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 32);
            this.addBtn.TabIndex = 30;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.searchBtn.Location = new System.Drawing.Point(384, 26);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 32);
            this.searchBtn.TabIndex = 31;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Item name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Barcode";
            // 
            // itemCodeTextBox
            // 
            this.itemCodeTextBox.Location = new System.Drawing.Point(158, 54);
            this.itemCodeTextBox.Name = "itemCodeTextBox";
            this.itemCodeTextBox.Size = new System.Drawing.Size(192, 20);
            this.itemCodeTextBox.TabIndex = 27;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(158, 87);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(192, 20);
            this.itemNameTextBox.TabIndex = 26;
            // 
            // bardcodeTextBox
            // 
            this.bardcodeTextBox.Location = new System.Drawing.Point(158, 14);
            this.bardcodeTextBox.Name = "bardcodeTextBox";
            this.bardcodeTextBox.Size = new System.Drawing.Size(192, 20);
            this.bardcodeTextBox.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.purchaseDatePicker);
            this.groupBox1.Controls.Add(this.expirationDatePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.enterBtn);
            this.groupBox1.Controls.Add(this.salePriceLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.purchasePriceTextBox);
            this.groupBox1.Controls.Add(this.percentageTextBox);
            this.groupBox1.Controls.Add(this.itemNameTextBox);
            this.groupBox1.Controls.Add(this.itemCodeTextBox);
            this.groupBox1.Controls.Add(this.supplierTextBox);
            this.groupBox1.Controls.Add(this.quantityTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bardcodeTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 582);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // purchaseDatePicker
            // 
            this.purchaseDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.purchaseDatePicker.Location = new System.Drawing.Point(158, 340);
            this.purchaseDatePicker.Name = "purchaseDatePicker";
            this.purchaseDatePicker.Size = new System.Drawing.Size(192, 20);
            this.purchaseDatePicker.TabIndex = 34;
            // 
            // expirationDatePicker
            // 
            this.expirationDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expirationDatePicker.Location = new System.Drawing.Point(158, 304);
            this.expirationDatePicker.Name = "expirationDatePicker";
            this.expirationDatePicker.Size = new System.Drawing.Size(192, 20);
            this.expirationDatePicker.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Purchase Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Exipration Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 265);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 18);
            this.label13.TabIndex = 31;
            this.label13.Text = "Supplier";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 18);
            this.label12.TabIndex = 31;
            this.label12.Text = "Quantity";
            // 
            // salePriceLabel
            // 
            this.salePriceLabel.AutoSize = true;
            this.salePriceLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salePriceLabel.Location = new System.Drawing.Point(155, 194);
            this.salePriceLabel.Name = "salePriceLabel";
            this.salePriceLabel.Size = new System.Drawing.Size(17, 18);
            this.salePriceLabel.TabIndex = 30;
            this.salePriceLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 30;
            this.label5.Text = "Sale Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 18);
            this.label11.TabIndex = 30;
            this.label11.Text = "Percentage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 18);
            this.label10.TabIndex = 29;
            this.label10.Text = "Purchase price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Item Code";
            // 
            // purchasePriceTextBox
            // 
            this.purchasePriceTextBox.Location = new System.Drawing.Point(158, 127);
            this.purchasePriceTextBox.Name = "purchasePriceTextBox";
            this.purchasePriceTextBox.Size = new System.Drawing.Size(192, 20);
            this.purchasePriceTextBox.TabIndex = 26;
            // 
            // percentageTextBox
            // 
            this.percentageTextBox.Location = new System.Drawing.Point(158, 162);
            this.percentageTextBox.Name = "percentageTextBox";
            this.percentageTextBox.Size = new System.Drawing.Size(192, 20);
            this.percentageTextBox.TabIndex = 27;
            this.percentageTextBox.TextChanged += new System.EventHandler(this.percentageTextBox_TextChanged);
            // 
            // supplierTextBox
            // 
            this.supplierTextBox.Location = new System.Drawing.Point(158, 263);
            this.supplierTextBox.Name = "supplierTextBox";
            this.supplierTextBox.Size = new System.Drawing.Size(192, 20);
            this.supplierTextBox.TabIndex = 24;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(158, 230);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(192, 20);
            this.quantityTextBox.TabIndex = 24;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(506, 26);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(0, 13);
            this.logLabel.TabIndex = 38;
            this.logLabel.Visible = false;
            // 
            // dataEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 644);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchBtn);
            this.Name = "dataEnter";
            this.Text = "dataEnter";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemCodeTextBox;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox bardcodeTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox purchasePriceTextBox;
        private System.Windows.Forms.TextBox percentageTextBox;
        private System.Windows.Forms.TextBox supplierTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.DateTimePicker expirationDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker purchaseDatePicker;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDate;
        private System.Windows.Forms.Label salePriceLabel;
        private System.Windows.Forms.Label label5;
    }
}