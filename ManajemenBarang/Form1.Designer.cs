using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ManajemenBarang
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Labels
            lblId = new Label();
            lblNama = new Label();
            lblStock = new Label();
            lblHarga = new Label();
            lblSearch = new Label();

            // TextBoxes
            txtId = new TextBox();
            txtNama = new TextBox();
            txtStock = new TextBox();
            txtHarga = new TextBox();
            txtSearch = new TextBox();

            // Buttons
            btnSimpan = new Button();
            btnUpdate = new Button();
            btnHapus = new Button();
            btnClear = new Button();
            btnSearch = new Button();

            // DataGridView
            dgvBarang = new DataGridView();

            // Initialize DataGridView
            ((System.ComponentModel.ISupportInitialize)(dgvBarang)).BeginInit();

            SuspendLayout();

            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 20);
            lblId.Name = "lblId";
            lblId.Size = new Size(24, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID";

            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(20, 60);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(49, 20);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama";

            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(20, 100);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(46, 20);
            lblStock.TabIndex = 2;
            lblStock.Text = "Stock";

            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Location = new Point(20, 140);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(50, 20);
            lblHarga.TabIndex = 3;
            lblHarga.Text = "Harga";

            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(20, 200);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(53, 20);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Search";

            // 
            // txtId
            // 
            txtId.Location = new Point(120, 20);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(200, 27);
            txtId.TabIndex = 5;

            // 
            // txtNama
            // 
            txtNama.Location = new Point(120, 60);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(200, 27);
            txtNama.TabIndex = 6;

            // 
            // txtStock
            // 
            txtStock.Location = new Point(120, 100);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(200, 27);
            txtStock.TabIndex = 7;

            // 
            // txtHarga
            // 
            txtHarga.Location = new Point(120, 140);
            txtHarga.Name = "txtHarga";
            txtHarga.Size = new Size(200, 27);
            txtHarga.TabIndex = 8;

            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(120, 200);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            txtSearch.TabIndex = 9;

            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(350, 20);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 10;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;

            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(350, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(350, 100);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(94, 29);
            btnHapus.TabIndex = 12;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += btnHapus_Click;

            // 
            // btnClear
            // 
            btnClear.Location = new Point(350, 140);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(350, 200);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // 
            // dgvBarang
            // 
            dgvBarang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarang.Location = new Point(20, 250);
            dgvBarang.Name = "dgvBarang";
            dgvBarang.RowHeadersWidth = 51;
            dgvBarang.RowTemplate.Height = 29;
            dgvBarang.Size = new Size(600, 200);
            dgvBarang.TabIndex = 15;
            dgvBarang.CellClick += dgvBarang_CellClick;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 480);
            Controls.Add(dgvBarang);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnHapus);
            Controls.Add(btnUpdate);
            Controls.Add(btnSimpan);
            Controls.Add(txtSearch);
            Controls.Add(txtHarga);
            Controls.Add(txtStock);
            Controls.Add(txtNama);
            Controls.Add(txtId);
            Controls.Add(lblSearch);
            Controls.Add(lblHarga);
            Controls.Add(lblStock);
            Controls.Add(lblNama);
            Controls.Add(lblId);
            Name = "Form1";
            Text = "Manajemen Barang";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)(dgvBarang)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblNama;
        private Label lblStock;
        private Label lblHarga;
        private Label lblSearch;
        private TextBox txtId;
        private TextBox txtNama;
        private TextBox txtStock;
        private TextBox txtHarga;
        private TextBox txtSearch;
        private Button btnSimpan;
        private Button btnUpdate;
        private Button btnHapus;
        private Button btnClear;
        private Button btnSearch;
        private DataGridView dgvBarang;
    }
}