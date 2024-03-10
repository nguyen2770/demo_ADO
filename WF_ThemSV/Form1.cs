using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WF_ThemSV
{
    public partial class Form1 : Form
    {
        // bộ sử lý lỗi
        private ErrorProvider errorProvider = new ErrorProvider();

        private string connectionString =
            ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

        private DataTable dtSINHVIEN = new DataTable();
        private DataView dvSINHVIEN = new DataView();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // nút thêm sẽ không ấn được
            bt_ThemMoi.Enabled = false;
            LoadDataToGridView();

        }

        private bool ktSDT(string phonenb)
        {
            return Regex.IsMatch(phonenb, @"^\d{10}$");
        }

        private void kt_HopLe(object sender, EventArgs e)
        {
            bool kt;
            
            if (!string.IsNullOrWhiteSpace(tb_sMaSV.Text)
                && !string.IsNullOrWhiteSpace(tb_sHoTen.Text) 
                && !string.IsNullOrWhiteSpace(tb_sDiaChi.Text) 
                && !string.IsNullOrWhiteSpace(tb_sSDT.Text)
                && ktSDT(tb_sSDT.Text) 
                && (rd_GTNam.Checked || rd_GTNu.Checked) )
            {
                kt = true;
            } else
            {
                kt = false;
            }
            bt_ThemMoi.Enabled = kt;

        }



        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNumeric(tb_sSDT.Text))
            {
                errorProvider.SetError(tb_sSDT, "Số điện thoại không hợp lệ");

            }
            else
            {
                errorProvider.SetError(tb_sSDT, null);

            }
        }
            private bool IsNumeric(string text)
            {
                foreach (char c in text)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            }

 

        private void tb_sMaSV_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_sMaSV.Text))
            {
                errorProvider.SetError(tb_sMaSV, "Ma khong trong");
            }
            else
            {
                errorProvider.SetError(tb_sMaSV, null);
            }
        }

        private void tb_sHoTen_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tb_sHoTen.Text))
            {
                errorProvider.SetError(tb_sHoTen, "Ho ten không được để trống");
            }
            else
            {
                errorProvider.SetError(tb_sHoTen, null);
            }
        }

        private void LoadDataToGridView()
        {
            string Select_Proc = "Select_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = Select_Proc;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtSINHVIEN);
                        if (dtSINHVIEN.Rows.Count > 0)
                        {
                            dvSINHVIEN = dtSINHVIEN.DefaultView;
                            /*GrV_DSSV.AutoGenerateColumns = false;*/
                            GrV_DSSV.DataSource = dvSINHVIEN;

                          
                        }
                        else
                        {
                            MessageBox.Show("Khong co ban ghi nao ton tai");
                        }

                    }
                }
            } 
                
            
        }

        private void bt_ThemMoi_Click(object sender, EventArgs e)
        {
            string insert_Proc = "Insert_tblSINHVIEN";
            using (SqlConnection  con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd =  con.CreateCommand())
                {
                    cmd.CommandText = insert_Proc;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@maSV", tb_sHoTen.Text);
                    sqlCommand.Parameters.AddWithValue("@tenSV", tb_sHoTen.Text);
                    sqlCommand.Parameters.AddWithValue("@ngaySinh", mtb_dNgaySinh.Text);
                    sqlCommand.Parameters.AddWithValue("@diaChi", tb_sDiaChi.Text);
                    sqlCommand.Parameters.AddWithValue("@soDienThoai", tb_sSDT.Text);
                    sqlCommand.Parameters.AddWithValue("@gioiTinh", );
                }
            }
        }


        private bool Kt_PrimaryKey(string s)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "KT_MaSV";
                    command.CommandType  = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@maSV", s);
                    
                    connection.Open();
                    bool tmp = command.ExecuteScalar() != null;
                    connection.Close();

                    if (tmp)
                    {
                        Console.WriteLine("Ma Sinh Vien: " + s + " Da Ton Tai!");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }


    }
  }
