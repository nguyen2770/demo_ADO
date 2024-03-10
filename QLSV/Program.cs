using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

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

            int key;
            do
            {
                Console.WriteLine("1.Them Sinh vien");
                Console.WriteLine("2. Hien danh sach sinh vien");
                Console.WriteLine("3. Xoa dinh vien theo ma");
                Console.WriteLine("4. Sua Sinh Vien theo ma");
                Console.WriteLine("5. Hien danh sach sinh vien theo pp ngat ket noi");
                Console.WriteLine("6. Xoa Sinh vien theo phương phap ngat ket noi");
                Console.WriteLine("7. Them SInh Vien theo pp ngat ket noi");
                Console.Write("Nhap lua chon: ");
                key = Convert.ToInt32(Console.ReadLine());
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
                            } else
                            {
                                Console.WriteLine("Khong thanh cong");
                            }
                            break;
                        }
                    case 5:
                        {
                            hienDSSV_NgatKetNoi(connectionString);
                            break;
                        }

                    case 6:
                        {
                            string maSV;
                            Console.Write("Nhap Ma SV: ");
                            maSV = Console.ReadLine();
                            bool tmp = xoaSV_TheoMa_NgatKetNoi(connectionString, maSV);
                            Console.WriteLine(tmp);
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
                    case 7:
                        {
                            string maSV, hoTen, ngaySinh, diaChi, SDT, gioiTinh;
                            do
                            {
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

                            bool tmp = ThemSV_NgatKetNoi(connectionString, maSV, hoTen, ngaySinh, SDT, diaChi, IsGender(gioiTinh));
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

                }

            } while (key != 0);

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

        private static void hienDSSV_NgatKetNoi(string connectionstring)
        {
            string select_proc = "Select_tblSINHVIEN";
            using(SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand()) { 
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = select_proc;
                    cmd.CommandType= CommandType.StoredProcedure;
                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using(DataTable table = new DataTable())
                        {
                            adapter.Fill(table);
                            if(table.Rows.Count > 0)
                            {
                                using (DataView dataView = table.DefaultView)
                                {
                                    dataView.RowFilter = "bGioiTinh = false";
                                    dataView.Sort = "dNgaySinh ASC";

                                    foreach (DataRowView row in dataView)
                                    {
                                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                                        row["sMaSV"],
                                        row["sHoTen"],
                                        row["dNgaySinh"],
                                        row["sDiaChi"],
                                        row["sSoDienThoai"],
                                        row["bGioiTinh"]);
                                    }
                                }
                                    /*HIển thị dữ liệu ra màn hình*/
                                    /*foreach (DataRow row in table.Rows)
                                    {
                                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                                        row["sMaSV"],
                                        row["sHoTen"],
                                        row["dNgaySinh"],
                                        row["sDiaChi"],
                                        row["sSoDienThoai"],
                                        row["bGioiTinh"]);
                                    }*/
                            }
                            else
                            {
                                Console.WriteLine("Khong taon tai ban ghi nao");
                            }
                        }

                    }
                
                }
            }
        }

        private static bool xoaSV_TheoMa_NgatKetNoi(string connectionString, string maSV) {
            string delete_proc = "sp_XoaSinhVien";
            string select_proc = "Select_tblSINHVIEN";
            using(SqlConnection connection = new SqlConnection(connectionString)) { 
                using(SqlCommand  cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = select_proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter  adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (DataTable tblSinhVien = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(tblSinhVien);
                            using (DataSet dataSet = new DataSet())
                            {
                                dataSet.Tables.Add(tblSinhVien);

                                // tìm mã sinh viên cần xóa
                                tblSinhVien.PrimaryKey = new DataColumn[] {tblSinhVien.Columns["sMaSV"]};
                                DataRow row = tblSinhVien.Rows.Find(maSV);
                                row.Delete();

                                // đồng bộ dữ liệu lên cơ sở dữ liệu sd deleteCommand
                                cmd.CommandText = delete_proc;
                                cmd.Parameters.Clear(); // clear đi để không bị chồng dữ liệu
                                cmd.Parameters.AddWithValue("@MaSV", maSV);

                                adapter.DeleteCommand = cmd;
                                int i = adapter.Update(dataSet, "tblSinhVien");

                                return i > 0;
                            }
                        }
                    }
                }
            }
        }

        private static bool ThemSV_NgatKetNoi(string connectionstring, string maSV, string hoTen, string ngaySinh, string DC, string SDT, bool GT)
        {
            string select_proc = "Select_tblSINHVIEN";
            string insert_proc = "Insert_tblSINHVIEN";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        cmd.CommandText = select_proc;
                        cmd.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand = cmd;
                        using(DataTable tblSinhVien = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(tblSinhVien);
                            using(DataSet dsSinhVien = new DataSet())
                            {
                                dsSinhVien.Tables.Add(tblSinhVien);

                                // thêm sinh viên vào dataTable
                                DataRow row = tblSinhVien.NewRow();
                                row["sMaSV"] = maSV;
                                row["sHoTen"] = hoTen;
                                row["dNgaySinh"] = ngaySinh;
                                row["sDiaChi"] = DC;
                                row["sSoDienThoai"] = SDT;
                                row["bGioiTinh"] = GT;
                                tblSinhVien.Rows.Add(row);

                                // đồng bộ dữ liệu vào CSDL
                                cmd.Parameters.Clear();
                                cmd.CommandText = insert_proc;
                                cmd.Parameters.AddWithValue("@maSV", maSV);
                                cmd.Parameters.AddWithValue("@tenSV", hoTen);
                                cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                                cmd.Parameters.AddWithValue("@diaChi", DC);
                                cmd.Parameters.AddWithValue("@soDienThoai", SDT);
                                cmd.Parameters.AddWithValue("@gioiTinh", GT);

                                adapter.InsertCommand = cmd;
                                int i = adapter.Update(dsSinhVien,"tblSINHVIEN");

                                return i > 0;

                            }
                        }
                    }
                }
            }
        }
    }
}
