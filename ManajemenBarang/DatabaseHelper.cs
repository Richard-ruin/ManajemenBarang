using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManajemenBarang
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method untuk mendapatkan semua barang
        public List<Barang> GetAllBarang()
        {
            List<Barang> barangList = new List<Barang>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Nama, Stock, Harga FROM Barang";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Barang barang = new Barang
                            {
                                Id = reader.GetInt32(0),
                                Nama = reader.GetString(1),
                                Stock = reader.GetInt32(2),
                                Harga = reader.GetDecimal(3)
                            };
                            barangList.Add(barang);
                        }
                    }
                }
            }

            return barangList;
        }

        // Method untuk menambahkan barang baru
        public int InsertBarang(Barang barang)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Barang (Nama, Stock, Harga) VALUES (@Nama, @Stock, @Harga); SELECT SCOPE_IDENTITY()";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nama", barang.Nama);
                    command.Parameters.AddWithValue("@Stock", barang.Stock);
                    command.Parameters.AddWithValue("@Harga", barang.Harga);

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // Method untuk mengupdate barang
        public bool UpdateBarang(Barang barang)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Barang SET Nama = @Nama, Stock = @Stock, Harga = @Harga WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", barang.Id);
                    command.Parameters.AddWithValue("@Nama", barang.Nama);
                    command.Parameters.AddWithValue("@Stock", barang.Stock);
                    command.Parameters.AddWithValue("@Harga", barang.Harga);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Method untuk menghapus barang
        public bool DeleteBarang(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Barang WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Method untuk mencari barang berdasarkan nama
        public List<Barang> SearchBarang(string keyword)
        {
            List<Barang> barangList = new List<Barang>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Nama, Stock, Harga FROM Barang WHERE Nama LIKE @Keyword";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Barang barang = new Barang
                            {
                                Id = reader.GetInt32(0),
                                Nama = reader.GetString(1),
                                Stock = reader.GetInt32(2),
                                Harga = reader.GetDecimal(3)
                            };
                            barangList.Add(barang);
                        }
                    }
                }
            }

            return barangList;
        }
    }
}