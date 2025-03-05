using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace ManajemenBarang
{
    public partial class Form1 : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private int selectedId = 0;

        public Form1()
        {
            InitializeComponent();

            // Mendapatkan connection string dari App.config
            string connectionString = ConfigurationManager.ConnectionStrings["ManajemenBarangDB"].ConnectionString;
            _dbHelper = new DatabaseHelper(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Memuat data saat form pertama kali dibuka
            LoadData();
            ClearForm();
        }

        private void LoadData()
        {
            // Mengambil data dari database dan menampilkan di DataGridView
            List<Barang> barangList = _dbHelper.GetAllBarang();
            dgvBarang.DataSource = barangList;
        }

        private void ClearForm()
        {
            // Mengosongkan form input
            txtId.Text = "";
            txtNama.Text = "";
            txtStock.Text = "";
            txtHarga.Text = "";
            selectedId = 0;
            txtNama.Focus();
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
            btnSimpan.Enabled = true;
        }

        private bool ValidateInput()
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama barang harus diisi!", "Validasi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNama.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStock.Text) || !int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Stock harus diisi dengan angka!", "Validasi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHarga.Text) || !decimal.TryParse(txtHarga.Text, out _))
            {
                MessageBox.Show("Harga harus diisi dengan angka!", "Validasi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHarga.Focus();
                return false;
            }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                // Membuat objek barang baru
                Barang barang = new Barang
                {
                    Nama = txtNama.Text,
                    Stock = int.Parse(txtStock.Text),
                    Harga = decimal.Parse(txtHarga.Text)
                };

                // Menyimpan ke database
                int newId = _dbHelper.InsertBarang(barang);
                if (newId > 0)
                {
                    MessageBox.Show("Data barang berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data barang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId == 0)
                {
                    MessageBox.Show("Pilih data yang akan diupdate!", "Validasi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidateInput())
                    return;

                // Membuat objek barang untuk update
                Barang barang = new Barang
                {
                    Id = selectedId,
                    Nama = txtNama.Text,
                    Stock = int.Parse(txtStock.Text),
                    Harga = decimal.Parse(txtHarga.Text)
                };

                // Update ke database
                bool success = _dbHelper.UpdateBarang(barang);
                if (success)
                {
                    MessageBox.Show("Data barang berhasil diupdate.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal mengupdate data barang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId == 0)
                {
                    MessageBox.Show("Pilih data yang akan dihapus!", "Validasi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Konfirmasi penghapusan
                DialogResult result = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Hapus dari database
                    bool success = _dbHelper.DeleteBarang(selectedId);
                    if (success)
                    {
                        MessageBox.Show("Data barang berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus data barang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadData();
                    return;
                }

                // Mencari data
                List<Barang> searchResults = _dbHelper.SearchBarang(keyword);
                dgvBarang.DataSource = searchResults;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Pastikan bukan klik pada header
                {
                    // Mengambil data dari row yang diklik
                    DataGridViewRow row = dgvBarang.Rows[e.RowIndex];
                    selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                    txtId.Text = selectedId.ToString();
                    txtNama.Text = row.Cells["Nama"].Value.ToString();
                    txtStock.Text = row.Cells["Stock"].Value.ToString();
                    txtHarga.Text = row.Cells["Harga"].Value.ToString();

                    // Aktifkan tombol update dan hapus
                    btnUpdate.Enabled = true;
                    btnHapus.Enabled = true;
                    btnSimpan.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}