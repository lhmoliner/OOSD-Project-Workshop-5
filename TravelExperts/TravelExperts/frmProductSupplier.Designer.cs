namespace TravelExperts
{
    partial class frmProductSupplier
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
            this.components = new System.ComponentModel.Container();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.tabModifyProductSupplier = new System.Windows.Forms.TabControl();
            this.tabProduct = new System.Windows.Forms.TabPage();
            this.txtModifyProduct = new System.Windows.Forms.TextBox();
            this.lstProductList = new System.Windows.Forms.ListBox();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travelExpertsDataSet = new TravelExperts.TravelExpertsDataSet();
            this.tabSupplier = new System.Windows.Forms.TabPage();
            this.btnSaveSupplier = new System.Windows.Forms.Button();
            this.txtModifySupplier = new System.Windows.Forms.TextBox();
            this.lstSupplierList = new System.Windows.Forms.ListBox();
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsTableAdapter = new TravelExperts.TravelExpertsDataSetTableAdapters.ProductsTableAdapter();
            this.suppliersTableAdapter = new TravelExperts.TravelExpertsDataSetTableAdapters.SuppliersTableAdapter();
            this.tabModifyProductSupplier.SuspendLayout();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelExpertsDataSet)).BeginInit();
            this.tabSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Location = new System.Drawing.Point(262, 171);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(71, 28);
            this.btnSaveProduct.TabIndex = 2;
            this.btnSaveProduct.Text = "Save";
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Location = new System.Drawing.Point(267, 268);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(89, 32);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // tabModifyProductSupplier
            // 
            this.tabModifyProductSupplier.Controls.Add(this.tabProduct);
            this.tabModifyProductSupplier.Controls.Add(this.tabSupplier);
            this.tabModifyProductSupplier.Location = new System.Drawing.Point(12, 32);
            this.tabModifyProductSupplier.Name = "tabModifyProductSupplier";
            this.tabModifyProductSupplier.SelectedIndex = 0;
            this.tabModifyProductSupplier.Size = new System.Drawing.Size(344, 232);
            this.tabModifyProductSupplier.TabIndex = 0;
            // 
            // tabProduct
            // 
            this.tabProduct.BackColor = System.Drawing.Color.Transparent;
            this.tabProduct.Controls.Add(this.txtModifyProduct);
            this.tabProduct.Controls.Add(this.lstProductList);
            this.tabProduct.Controls.Add(this.btnSaveProduct);
            this.tabProduct.Location = new System.Drawing.Point(4, 25);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabProduct.Size = new System.Drawing.Size(336, 203);
            this.tabProduct.TabIndex = 0;
            this.tabProduct.Text = "Product";
            this.tabProduct.UseVisualStyleBackColor = true;
            // 
            // txtModifyProduct
            // 
            this.txtModifyProduct.Location = new System.Drawing.Point(3, 173);
            this.txtModifyProduct.Name = "txtModifyProduct";
            this.txtModifyProduct.Size = new System.Drawing.Size(253, 22);
            this.txtModifyProduct.TabIndex = 1;
            this.txtModifyProduct.Tag = "product name";
            // 
            // lstProductList
            // 
            this.lstProductList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstProductList.DataSource = this.productsBindingSource;
            this.lstProductList.DisplayMember = "ProdName";
            this.lstProductList.FormattingEnabled = true;
            this.lstProductList.ItemHeight = 16;
            this.lstProductList.Location = new System.Drawing.Point(3, 3);
            this.lstProductList.Name = "lstProductList";
            this.lstProductList.Size = new System.Drawing.Size(330, 162);
            this.lstProductList.Sorted = true;
            this.lstProductList.TabIndex = 0;
            this.lstProductList.ValueMember = "ProductId";
            this.lstProductList.SelectedIndexChanged += new System.EventHandler(this.lstProductList_SelectedIndexChanged);
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.travelExpertsDataSet;
            // 
            // travelExpertsDataSet
            // 
            this.travelExpertsDataSet.DataSetName = "TravelExpertsDataSet";
            this.travelExpertsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabSupplier
            // 
            this.tabSupplier.BackColor = System.Drawing.Color.Transparent;
            this.tabSupplier.Controls.Add(this.btnSaveSupplier);
            this.tabSupplier.Controls.Add(this.txtModifySupplier);
            this.tabSupplier.Controls.Add(this.lstSupplierList);
            this.tabSupplier.Location = new System.Drawing.Point(4, 25);
            this.tabSupplier.Name = "tabSupplier";
            this.tabSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabSupplier.Size = new System.Drawing.Size(336, 203);
            this.tabSupplier.TabIndex = 1;
            this.tabSupplier.Text = "Supplier";
            this.tabSupplier.UseVisualStyleBackColor = true;
            // 
            // btnSaveSupplier
            // 
            this.btnSaveSupplier.Location = new System.Drawing.Point(262, 171);
            this.btnSaveSupplier.Name = "btnSaveSupplier";
            this.btnSaveSupplier.Size = new System.Drawing.Size(71, 28);
            this.btnSaveSupplier.TabIndex = 48;
            this.btnSaveSupplier.Text = "Save";
            this.btnSaveSupplier.UseVisualStyleBackColor = true;
            this.btnSaveSupplier.Click += new System.EventHandler(this.btnSaveSupplier_Click);
            // 
            // txtModifySupplier
            // 
            this.txtModifySupplier.Location = new System.Drawing.Point(3, 173);
            this.txtModifySupplier.Name = "txtModifySupplier";
            this.txtModifySupplier.Size = new System.Drawing.Size(253, 22);
            this.txtModifySupplier.TabIndex = 2;
            this.txtModifySupplier.Tag = "supplier name";
            // 
            // lstSupplierList
            // 
            this.lstSupplierList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSupplierList.DataSource = this.suppliersBindingSource;
            this.lstSupplierList.DisplayMember = "SupName";
            this.lstSupplierList.FormattingEnabled = true;
            this.lstSupplierList.ItemHeight = 16;
            this.lstSupplierList.Location = new System.Drawing.Point(3, 3);
            this.lstSupplierList.Name = "lstSupplierList";
            this.lstSupplierList.Size = new System.Drawing.Size(330, 162);
            this.lstSupplierList.Sorted = true;
            this.lstSupplierList.TabIndex = 1;
            this.lstSupplierList.ValueMember = "SupplierId";
            this.lstSupplierList.SelectedIndexChanged += new System.EventHandler(this.lstSupplierList_SelectedIndexChanged);
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataMember = "Suppliers";
            this.suppliersBindingSource.DataSource = this.travelExpertsDataSet;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(369, 28);
            this.menuStrip1.TabIndex = 57;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // suppliersTableAdapter
            // 
            this.suppliersTableAdapter.ClearBeforeFill = true;
            // 
            // frmModifyProductSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 310);
            this.Controls.Add(this.tabModifyProductSupplier);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "frmModifyProductSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Product/Supplier";
            this.Load += new System.EventHandler(this.frmModifyProductSupplier_Load);
            this.tabModifyProductSupplier.ResumeLayout(false);
            this.tabProduct.ResumeLayout(false);
            this.tabProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelExpertsDataSet)).EndInit();
            this.tabSupplier.ResumeLayout(false);
            this.tabSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TabControl tabModifyProductSupplier;
        private System.Windows.Forms.TabPage tabProduct;
        private System.Windows.Forms.TabPage tabSupplier;
        private System.Windows.Forms.ListBox lstProductList;
        private System.Windows.Forms.TextBox txtModifyProduct;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private TravelExpertsDataSet travelExpertsDataSet;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private TravelExpertsDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private System.Windows.Forms.ListBox lstSupplierList;
        private System.Windows.Forms.BindingSource suppliersBindingSource;
        private TravelExpertsDataSetTableAdapters.SuppliersTableAdapter suppliersTableAdapter;
        private System.Windows.Forms.Button btnSaveSupplier;
        private System.Windows.Forms.TextBox txtModifySupplier;
    }
}