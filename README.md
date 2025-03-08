# Aplikasi Manajemen Barang

Aplikasi desktop sederhana untuk manajemen data barang dengan fitur CRUD (Create, Read, Update, Delete) menggunakan C# .NET 8.0 dan Windows Forms.

## Teknologi yang Digunakan

- Microsoft Visual Studio 2022
- .NET 8.0
- Windows Forms
- SQL Server
- ADO.NET

## Fitur Aplikasi

- Menampilkan daftar barang dalam DataGridView
- Menambahkan data barang baru
- Mengubah data barang yang sudah ada
- Menghapus data barang
- Mencari barang berdasarkan nama

## Struktur Database

```sql
CREATE DATABASE ManajemenBarangDB;
GO

USE ManajemenBarangDB;
GO

CREATE TABLE Barang (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nama NVARCHAR(100) NOT NULL,
    Stock INT NOT NULL,
    Harga DECIMAL(18,2) NOT NULL
);
GO
```

## Cara Penggunaan

### Prasyarat

1. .NET 8.0 SDK
2. SQL Server
3. Visual Studio 2022

### Langkah Instalasi

1. Clone repository ini atau download source code
2. Buka file solution (.sln) dengan Visual Studio 2022
3. Update connection string di file App.config sesuai dengan konfigurasi SQL Server Anda
4. Jalankan script SQL untuk membuat database dan tabel
5. Build dan jalankan aplikasi

### Konfigurasi Database

Pastikan untuk mengubah connection string di App.config sesuai dengan konfigurasi SQL Server di komputer Anda:

```xml
<connectionStrings>
    <add name="ManajemenBarangDB" connectionString="Data Source=NAMA_SERVER;Initial Catalog=ManajemenBarangDB;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Cara Penggunaan Aplikasi

1. **Menambah Barang**:
   - Isi field Nama, Stock, dan Harga
   - Klik tombol "Simpan"

2. **Mengubah Barang**:
   - Klik data pada tabel yang ingin diubah
   - Edit field yang diinginkan
   - Klik tombol "Update"

3. **Menghapus Barang**:
   - Klik data pada tabel yang ingin dihapus
   - Klik tombol "Hapus"
   - Konfirmasi penghapusan

4. **Mencari Barang**:
   - Masukkan kata kunci pada textbox Search
   - Klik tombol "Search"
   - Untuk menampilkan semua data, kosongkan textbox Search dan klik "Search"

5. **Membersihkan Form**:
   - Klik tombol "Clear" untuk mengosongkan semua field

## Troubleshooting

1. **Error Koneksi Database**:
   - Periksa SQL Server apakah berjalan
   - Periksa connection string di App.config
   - Pastikan database ManajemenBarangDB telah dibuat

2. **Format Input Tidak Valid**:
   - Pastikan input Stock berupa angka bulat
   - Pastikan input Harga berupa angka (bisa menggunakan koma atau titik untuk desimal)

## Struktur Project

- `Form1.cs` - Form utama aplikasi dan logic UI
- `Barang.cs` - Class model untuk objek Barang
- `DatabaseHelper.cs` - Class untuk operasi database
- `App.config` - File konfigurasi termasuk connection string

## Pengembangan Lebih Lanjut

Beberapa ide untuk pengembangan aplikasi ini:
- Menambahkan fitur kategori barang
- Implementasi fitur stok minimal dan notifikasi
- Menambahkan laporan dan export data
- Meningkatkan UI dengan tema modern
- Menambahkan sistem login dan otorisasi

## Lisensi

Project ini bersifat open source dan tersedia untuk digunakan dalam tujuan pendidikan.
