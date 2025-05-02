using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using FinalProjectPSD.Factory;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Repository
{
    public class MsJewelRepository
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public List<MsJewel> GetAllJewels()
        {
            List<MsJewel> jewels = new List<MsJewel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT j.JewelID, j.BrandID, j.CategoryID, j.JewelName, j.JewelPrice, j.JewelReleaseYear
                              FROM MsJewel j
                              ORDER BY j.JewelID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MsJewel jewel = new MsJewel
                        {
                            JewelID = Convert.ToInt32(reader["JewelID"]),
                            BrandID = Convert.ToInt32(reader["BrandID"]),
                            CategoryID = Convert.ToInt32(reader["CategoryID"]),
                            JewelName = reader["JewelName"].ToString(),
                            JewelPrice = Convert.ToInt32(reader["JewelPrice"]),
                            JewelReleaseYear = Convert.ToInt32(reader["JewelReleaseYear"])
                        };

                        jewels.Add(jewel);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
   
                }
            }

            return jewels;
        }

        public MsJewel GetJewelById(int jewelId)
        {
            MsJewel jewel = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT j.JewelID, j.BrandID, j.CategoryID, j.JewelName, j.JewelPrice, j.JewelReleaseYear
                              FROM MsJewel j
                              WHERE j.JewelID = @JewelID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@JewelID", jewelId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        jewel = new MsJewel
                        {
                            JewelID = Convert.ToInt32(reader["JewelID"]),
                            BrandID = Convert.ToInt32(reader["BrandID"]),
                            CategoryID = Convert.ToInt32(reader["CategoryID"]),
                            JewelName = reader["JewelName"].ToString(),
                            JewelPrice = Convert.ToInt32(reader["JewelPrice"]),
                            JewelReleaseYear = Convert.ToInt32(reader["JewelReleaseYear"])
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
  
                }
            }

            return jewel;
        }

        public bool InsertJewel(int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO MsJewel (BrandID, CategoryID, JewelName, JewelPrice, JewelReleaseYear)
                              VALUES (@BrandID, @CategoryID, @JewelName, @JewelPrice, @JewelReleaseYear)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BrandID", brandId);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                command.Parameters.AddWithValue("@JewelName", jewelName);
                command.Parameters.AddWithValue("@JewelPrice", jewelPrice);
                command.Parameters.AddWithValue("@JewelReleaseYear", jewelReleaseYear);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }

        public bool UpdateJewel(int jewelId, int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE MsJewel 
                              SET BrandID = @BrandID, CategoryID = @CategoryID, JewelName = @JewelName, 
                                  JewelPrice = @JewelPrice, JewelReleaseYear = @JewelReleaseYear
                              WHERE JewelID = @JewelID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@JewelID", jewelId);
                command.Parameters.AddWithValue("@BrandID", brandId);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                command.Parameters.AddWithValue("@JewelName", jewelName);
                command.Parameters.AddWithValue("@JewelPrice", jewelPrice);
                command.Parameters.AddWithValue("@JewelReleaseYear", jewelReleaseYear);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DeleteJewel(int jewelId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MsJewel WHERE JewelID = @JewelID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@JewelID", jewelId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}