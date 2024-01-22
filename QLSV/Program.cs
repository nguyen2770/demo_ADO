using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class Program
    {
        /*string ConnectionString = "Data Source = PC-NGUYEN\\SQLEXPRESS;" +
                                    "Initial Catalog = qlsv;" +
                                    "Integrated Security=True;";*/


        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLSV_ConnectionString"].ConnectionString;

            Console.WriteLine("1.Them Sinh vien");
            Console.WriteLine("2. Hien danh sach sinh vien");
            Console.WriteLine("3. Xoa dinh vien theo ma");
            Console.WriteLine("4. Sua Sinh Vien theo ma");
            Console.Write("Nhap lua chon: ");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    {

                        string maSV, hoTen, ngaySinh, diaChi, SDT, gioiTinh;
                        do {
                            Console.Write("Nhap Ma SV: ");
                            maSV = Console.ReadLine();
                        } while (KTKhoaChinh_SV(connectionString, maSV));
  

                        Console.Write("Nhap ho ten: ");
                        hoTen = Console.ReadLine();

                        Console.Write("Nhap ngay sinh: ");
                        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                        ngaySinh = dateTime.ToString("yyyy/MM/dd");

                        Console.Write("Nhap dia chi: ");
                        diaChi = Console.ReadLine();
                        Console.Write("Nhap so dien thoai: ");
                        SDT = Console.ReadLine();
                        Console.Write("Nhap gioi tinh: ");
                        gioiTinh = Console.ReadLine();

                        bool tmp = ThemSV(connectionString, maSV, hoTen, ngaySinh, SDT, diaChi, IsGender(gioiTinh));
                        if (tmp)
                        {
                            Console.WriteLine("Them thanh Cong");
                        }
                        else
                        {
                            Console.WriteLine("Them Khong thanh cong");
                        }
                        break;
                    }
                case 2:
                    {
                        HienThiDSSV_tblSinhVien(connectionString);
                        break;
                    }

                case 3:
                    {
                        string maSV;
                        Console.Write("Nhap Ma SV: ");
                        maSV = Console.ReadLine();
                        bool tmp = DeleteSV_TheoMA(connectionString, maSV);
                        if (tmp)
                        {
                            Console.WriteLine("Xoa Thanh Cong");
                        }
                        else
                        {
                            Console.WriteLine("Xoa That Bai");
                        }
                        break;
                    }

                case 4:
                    {
                        string maSV, hoTen, ngaySinh, diaChi, SDT, gioiTinh;
                        Console.Write("Nhap Ma SV Can Sua: ");
                        maSV = Console.ReadLine();
                        Console.Write("Nhap ho ten: ");
                        hoTen = Console.ReadLine();

                        Console.Write("Nhap ngay sinh: ");
                        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                        ngaySinh = dateTime.ToString("yyyy/MM/dd");

                        Console.Write("Nhap dia chi: ");
                        diaChi = Console.ReadLine();
                        Console.Write("Nhap so dien thoai: ");
                        SDT = Console.ReadLine();
                        Console.Write("Nhap gioi tinh: ");
                        gioiTinh = Console.ReadLine();

                        bool tmp = updateSV_MaSV(connectionString, maSV, hoTen, ngaySinh, diaChi, SDT, IsGender(gioiTinh));
                        if (tmp)
                        {
                            Console.WriteLine("Sua thanh cong");
                        }else
                        {
                            Console.WriteLine("Khong thanh cong");
                        }
                        break;
                    }
            }

            Console.ReadKey();
        }
        private static bool ThemSV(string connectionString, string maSV, string hoTen, string ngaySinh, string DC, string SDT, bool GT)
        {
            /* string inesert_command = "insert into tblSINHVIEN(sMaSV,sHoTen, dNgaySinh, sDiaChi, sSoDienThoai, bGioiTinh)" +
                 "values ('" + maSV + "',N'" + hoTen + "', '" + ngaySinh + "', N'" + DC + "', '" + SDT + "', '" + GT + "')";
 */
            string insert_proc = "Insert_tblSINHVIEN";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {

                    /*sqlCommand.CommandText = inesert_command;
                    sqlCommand.CommandType = System.Data.CommandType.Text;*/

                    sqlCommand.CommandText = insert_proc;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@maSV", SqlDbType.VarChar, 20).Value = maSV;
                    /*sqlCommand.Parameters.AddWithValue("@maSV", maSV);*/
                    sqlCommand.Parameters.AddWithValue("@tenSV", hoTen);
                    sqlCommand.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    sqlCommand.Parameters.AddWithValue("@diaChi", DC);
                    sqlCommand.Parameters.AddWithValue("@soDienThoai", SDT);
                    sqlCommand.Parameters.AddWithValue("@gioiTinh", GT);



                    sqlConnection.Open();
                        int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                        return i > 0;
          
                }
            }
        }

        private static bool IsGender(string gender)
        {
            bool index = false;
            if(gender.ToLower() == "nam")
            {
                index = true;
            }
            return index;
        }

        private static bool KTKhoaChinh_SV (string connectionstring ,string maSV)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = "KT_MaSV";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@maSV", maSV);
                    
                    sqlConnection.Open ();
                    bool tmp = (cmd.ExecuteScalar() != null);
                    sqlConnection.Close ();

                    if (tmp)
                    {
                        Console.WriteLine("Ma Sinh Vien: " + maSV + " Da Ton Tai!");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private static void HienThiDSSV_tblSinhVien(string connectionstring)
        {
            string select_SinhVien = "Select_tblSINHVIEN";
            using(SqlConnection sqlConnection = new SqlConnection( connectionstring ))
            {
                using( SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText= select_SinhVien;
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                                    reader["sMaSV"],
                                    reader["sHoTen"],
                                    reader["dNgaySinh"],
                                    reader["sDiaChi"],
                                    reader["sSoDienThoai"],
                                    reader["bGioiTinh"]);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
        }

        private static bool DeleteSV_TheoMA (string connectionstring, string maSV) {
            string deleteSV = "sp_XoaSinhVien";
            using( SqlConnection sqlConnection = new SqlConnection(connectionstring ))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = deleteSV;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return i > 0;
                }
            }
        }

        private static bool updateSV_MaSV(string connectionstring, string maSV, string hoTen, string ngaySinh, string DC, string SDT, bool GT)
        {
            string updateSV = "sp_CapNhatSinhVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                using( SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = updateSV;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = maSV;
                    /*sqlCommand.Parameters.AddWithValue("@maSV", maSV);*/
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", DC);
                    cmd.Parameters.AddWithValue("@SoDienThoai", SDT);
                    cmd.Parameters.AddWithValue("@GioiTinh", GT);

                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close ();
                    return i > 0;
                }
            }
        }
    }
}
