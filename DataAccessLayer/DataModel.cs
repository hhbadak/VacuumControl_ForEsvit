using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataModel
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private readonly string _connectionString = ConnectionStrings.ConStr; // ConnectionStrings sınıfındaki bağlantı dizesini kullanın.

        public DataModel()
        {
            con = new SqlConnection(_connectionString);
            cmd = con.CreateCommand();
        }

        public Employee personalLogin(string username, string password)
        {
            Employee model = new Employee();
            try
            {
                cmd.CommandText = "SELECT Kimlik FROM kullanici_liste WHERE kullanici_adi = @uName AND sifre = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uName", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    model = getPersonal(id);
                }
                return model;

            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public Employee getPersonal(int id)
        {
            try
            {
                Employee model = new Employee();
                cmd.CommandText = "SELECT Kimlik, kullanici_adi, sifre, ad_soyad, durum, pcAd, versiyon, KisaAd, Departman \r\nFROM kullanici_liste\r\nWHERE Kimlik = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.ID = Convert.ToInt32(reader["Kimlik"]);
                    model.Username = reader.GetString(1);
                    model.Password = reader.GetString(2);
                    model.NameSurname = reader.GetString(3);
                    model.Status = reader.GetByte(4);
                    model.PcName = reader.GetString(5);
                    model.Version = reader.GetString(6);
                    model.ShortName = reader.GetString(7);
                    model.Department = reader.GetString(8);
                }
                return model;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public List<VacuumTest> logEntryListVacuumTest(VacuumTest filter)
        {
            List<VacuumTest> rt = new List<VacuumTest>();
            try
            {
                cmd.CommandText = @"
            SELECT vt.ID, vt.Barcode, q.tanim, vh.Name, vt.DateTime, kl.kullanici_adi 
            FROM kalite_vakumTest AS vt 
            JOIN kalite_liste AS q ON q.Kimlik = vt.QualityID 
            JOIN kullanici_liste AS kl ON kl.Kimlik = vt.QualityPersonalID 
            JOIN kalite_vakumHata AS vh ON vh.ID = vt.ResultID 
            WHERE CONVERT(date, vt.DateTime) = @datetime";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now.Date);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VacuumTest model = new VacuumTest
                        {
                            // Bu satırların veri tiplerini kontrol edin ve doğru dönüşümler yapın
                            ID = reader.GetInt32(0),                         // vt.ID -> int
                            Barcode = reader.GetString(1),                   // vt.Barcode -> nvarchar
                            Quality = reader.GetString(2),                   // q.tanim -> nvarchar
                            Result = reader.GetString(3),                    // vh.Name -> nvarchar
                            Datetime = reader.GetDateTime(4),                // vt.DateTime -> datetime
                            QualityPersonal = reader.GetString(5),           // kl.kullanici_adi -> nvarchar
                        };
                        rt.Add(model);
                    }
                }
                return rt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool isThereBarcode(string barcode)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Products WHERE Barcode = @barcode";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barcode", barcode);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool isThereFault(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Id FROM kalite_vakumHata WHERE Id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    if (result is int)
                    {
                        id = (int)result;
                        return true;
                    }
                    else
                    {
                        // Dönüştürme başarısız oldu
                        // Gerekirse uygun bir hata işleme mekanizması burada eklenebilir
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }

        public bool createVacuumTest(VacuumTest test)
        {
            try
            {
                cmd.CommandText = "INSERT INTO kalite_vakumTest(Barcode, QualityID, ResultID, DateTime, QualityPersonalID) VALUES(@barcode, @qid, @result, FORMAT(@date, 'yyyy-MM-dd HH:mm:ss'), @qpid)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barcode", test.Barcode);
                cmd.Parameters.AddWithValue("@qid", test.QualityID);
                cmd.Parameters.AddWithValue("@result", test.ResultID);
                cmd.Parameters.AddWithValue("@date", test.Datetime);
                cmd.Parameters.AddWithValue("@qpid", test.QualityPersonalID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Employee> getPersonalUsername(int ID)
        {
            List<Employee> e = new List<Employee>();
            try
            {
                cmd.CommandText = "SELECT Kimlik, kullanici_adi, sifre, ad_soyad FROM kullanici_liste WHERE Kimlik = @kimlik";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kimlik", ID);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee model = new Employee
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Username = reader["kullanici_adi"].ToString(),
                            Password = reader["sifre"].ToString(),
                            NameSurname = reader["ad_soyad"].ToString()
                        };
                        e.Add(model);
                    }
                }
                return e;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool updateProductQuality(VacuumTest pro)
        {
            try
            {
                cmd.CommandText = "UPDATE Products SET Quality = @quality, Fault = 46 WHERE Barcode=@barcode";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Quality", pro.QualityID);
                cmd.Parameters.AddWithValue("@barcode", pro.Barcode);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }

        public List<Products> getBarcodeQuality(string barcode)
        {
            List<Products> pr = new List<Products>();
            try
            {
                cmd.CommandText = "SELECT ID, Quality FROM Products WHERE Barcode = @barcode";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barcode", barcode);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products model = new Products
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            QualityID = Convert.ToInt32(reader["Quality"])
                        };
                        pr.Add(model);
                    }
                }
                return pr;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        // Aşağıdaki 3 metodun baştan oluşturulması gerekmiyor, zaten var olan metodlarla uyumlu olarak mevcut.
        public bool CheckBarcodeAndNavigate(string barcode)
        {
            // Daha önce tanımlanmış olan yöntem kullanılabilir
            return isThereBarcode(barcode);
        }

        public bool ProcessVacuumTest(string barcode, int qualityID, int resultID, int qualityPersonalID)
        {
            VacuumTest vt = new VacuumTest
            {
                Barcode = barcode,
                QualityID = qualityID,
                ResultID = resultID,
                Datetime = DateTime.Now,
                QualityPersonalID = qualityPersonalID
            };

            return createVacuumTest(vt);
        }

        public List<Products> GetQualityInfoByBarcode(string barcode)
        {
            return getBarcodeQuality(barcode);
        }
    }
}
