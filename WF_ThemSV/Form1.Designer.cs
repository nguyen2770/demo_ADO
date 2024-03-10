namespace WF_ThemSV
{
    partial class Form1
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
            this.grb_themSV = new System.Windows.Forms.GroupBox();
            this.mtb_dNgaySinh = new System.Windows.Forms.MaskedTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_ThemMoi = new System.Windows.Forms.Button();
            this.rd_GTNu = new System.Windows.Forms.RadioButton();
            this.rd_GTNam = new System.Windows.Forms.RadioButton();
            this.tb_sDiaChi = new System.Windows.Forms.TextBox();
            this.tb_sSDT = new System.Windows.Forms.TextBox();
            this.tb_sHoTen = new System.Windows.Forms.TextBox();
            this.tb_sMaSV = new System.Windows.Forms.TextBox();
            this.lb_dngaysinh = new System.Windows.Forms.Label();
            this.lb_bgioitinh = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_sdiachi = new System.Windows.Forms.Label();
            this.lb_sodienthoai = new System.Windows.Forms.Label();
            this.lb_sHoTen = new System.Windows.Forms.Label();
            this.lb_iMaSV = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GrV_DSSV = new System.Windows.Forms.DataGridView();
            this.grb_themSV.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrV_DSSV)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_themSV
            // 
            this.grb_themSV.Controls.Add(this.mtb_dNgaySinh);
            this.grb_themSV.Controls.Add(this.button5);
            this.grb_themSV.Controls.Add(this.button4);
            this.grb_themSV.Controls.Add(this.button3);
            this.grb_themSV.Controls.Add(this.button2);
            this.grb_themSV.Controls.Add(this.bt_ThemMoi);
            this.grb_themSV.Controls.Add(this.rd_GTNu);
            this.grb_themSV.Controls.Add(this.rd_GTNam);
            this.grb_themSV.Controls.Add(this.tb_sDiaChi);
            this.grb_themSV.Controls.Add(this.tb_sSDT);
            this.grb_themSV.Controls.Add(this.tb_sHoTen);
            this.grb_themSV.Controls.Add(this.tb_sMaSV);
            this.grb_themSV.Controls.Add(this.lb_dngaysinh);
            this.grb_themSV.Controls.Add(this.lb_bgioitinh);
            this.grb_themSV.Controls.Add(this.label4);
            this.grb_themSV.Controls.Add(this.lb_sdiachi);
            this.grb_themSV.Controls.Add(this.lb_sodienthoai);
            this.grb_themSV.Controls.Add(this.lb_sHoTen);
            this.grb_themSV.Controls.Add(this.lb_iMaSV);
            this.grb_themSV.Location = new System.Drawing.Point(37, 30);
            this.grb_themSV.Name = "grb_themSV";
            this.grb_themSV.Size = new System.Drawing.Size(738, 349);
            this.grb_themSV.TabIndex = 0;
            this.grb_themSV.TabStop = false;
            this.grb_themSV.Text = "Thông tin sinh viên";
            // 
            // mtb_dNgaySinh
            // 
            this.mtb_dNgaySinh.Location = new System.Drawing.Point(174, 252);
            this.mtb_dNgaySinh.Mask = "00/00/0000";
            this.mtb_dNgaySinh.Name = "mtb_dNgaySinh";
            this.mtb_dNgaySinh.Size = new System.Drawing.Size(152, 26);
            this.mtb_dNgaySinh.TabIndex = 20;
            this.mtb_dNgaySinh.ValidatingType = typeof(System.DateTime);
            this.mtb_dNgaySinh.TextChanged += new System.EventHandler(this.kt_HopLe);
            this.mtb_dNgaySinh.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightCoral;
            this.button5.Location = new System.Drawing.Point(594, 238);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 42);
            this.button5.TabIndex = 18;
            this.button5.Text = "Tìm Kiếm";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightCoral;
            this.button4.Location = new System.Drawing.Point(594, 190);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 42);
            this.button4.TabIndex = 17;
            this.button4.Text = "Xóa Bỏ";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightCoral;
            this.button3.Location = new System.Drawing.Point(594, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 43);
            this.button3.TabIndex = 16;
            this.button3.Text = "Chỉnh Sửa";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCoral;
            this.button2.Location = new System.Drawing.Point(594, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 44);
            this.button2.TabIndex = 15;
            this.button2.Text = "Bỏ Qua";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // bt_ThemMoi
            // 
            this.bt_ThemMoi.BackColor = System.Drawing.Color.LightCoral;
            this.bt_ThemMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_ThemMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_ThemMoi.Location = new System.Drawing.Point(594, 41);
            this.bt_ThemMoi.Name = "bt_ThemMoi";
            this.bt_ThemMoi.Size = new System.Drawing.Size(106, 44);
            this.bt_ThemMoi.TabIndex = 14;
            this.bt_ThemMoi.Text = "Thêm Mới";
            this.bt_ThemMoi.UseVisualStyleBackColor = false;
            this.bt_ThemMoi.Click += new System.EventHandler(this.bt_ThemMoi_Click);
            // 
            // rd_GTNu
            // 
            this.rd_GTNu.AutoSize = true;
            this.rd_GTNu.Location = new System.Drawing.Point(272, 307);
            this.rd_GTNu.Name = "rd_GTNu";
            this.rd_GTNu.Size = new System.Drawing.Size(54, 24);
            this.rd_GTNu.TabIndex = 12;
            this.rd_GTNu.TabStop = true;
            this.rd_GTNu.Text = "Nữ";
            this.rd_GTNu.UseVisualStyleBackColor = true;
            this.rd_GTNu.CheckedChanged += new System.EventHandler(this.kt_HopLe);
            // 
            // rd_GTNam
            // 
            this.rd_GTNam.AutoSize = true;
            this.rd_GTNam.Location = new System.Drawing.Point(174, 307);
            this.rd_GTNam.Name = "rd_GTNam";
            this.rd_GTNam.Size = new System.Drawing.Size(67, 24);
            this.rd_GTNam.TabIndex = 11;
            this.rd_GTNam.TabStop = true;
            this.rd_GTNam.Text = "Nam";
            this.rd_GTNam.UseVisualStyleBackColor = true;
            this.rd_GTNam.CheckedChanged += new System.EventHandler(this.kt_HopLe);
            // 
            // tb_sDiaChi
            // 
            this.tb_sDiaChi.Location = new System.Drawing.Point(174, 202);
            this.tb_sDiaChi.Name = "tb_sDiaChi";
            this.tb_sDiaChi.Size = new System.Drawing.Size(362, 26);
            this.tb_sDiaChi.TabIndex = 10;
            this.tb_sDiaChi.TextChanged += new System.EventHandler(this.kt_HopLe);
            // 
            // tb_sSDT
            // 
            this.tb_sSDT.Location = new System.Drawing.Point(174, 153);
            this.tb_sSDT.Name = "tb_sSDT";
            this.tb_sSDT.Size = new System.Drawing.Size(362, 26);
            this.tb_sSDT.TabIndex = 9;
            this.tb_sSDT.TextChanged += new System.EventHandler(this.kt_HopLe);
            this.tb_sSDT.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // tb_sHoTen
            // 
            this.tb_sHoTen.Location = new System.Drawing.Point(174, 97);
            this.tb_sHoTen.Name = "tb_sHoTen";
            this.tb_sHoTen.Size = new System.Drawing.Size(362, 26);
            this.tb_sHoTen.TabIndex = 8;
            this.tb_sHoTen.TextChanged += new System.EventHandler(this.kt_HopLe);
            this.tb_sHoTen.Validating += new System.ComponentModel.CancelEventHandler(this.tb_sHoTen_Validating);
            // 
            // tb_sMaSV
            // 
            this.tb_sMaSV.Location = new System.Drawing.Point(174, 41);
            this.tb_sMaSV.Name = "tb_sMaSV";
            this.tb_sMaSV.Size = new System.Drawing.Size(362, 26);
            this.tb_sMaSV.TabIndex = 7;
            this.tb_sMaSV.TextChanged += new System.EventHandler(this.kt_HopLe);
            this.tb_sMaSV.Validating += new System.ComponentModel.CancelEventHandler(this.tb_sMaSV_Validating);
            // 
            // lb_dngaysinh
            // 
            this.lb_dngaysinh.AutoSize = true;
            this.lb_dngaysinh.Location = new System.Drawing.Point(23, 255);
            this.lb_dngaysinh.Name = "lb_dngaysinh";
            this.lb_dngaysinh.Size = new System.Drawing.Size(78, 20);
            this.lb_dngaysinh.TabIndex = 6;
            this.lb_dngaysinh.Text = "Ngày sinh";
            // 
            // lb_bgioitinh
            // 
            this.lb_bgioitinh.AutoSize = true;
            this.lb_bgioitinh.Location = new System.Drawing.Point(23, 307);
            this.lb_bgioitinh.Name = "lb_bgioitinh";
            this.lb_bgioitinh.Size = new System.Drawing.Size(67, 20);
            this.lb_bgioitinh.TabIndex = 5;
            this.lb_bgioitinh.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 4;
            // 
            // lb_sdiachi
            // 
            this.lb_sdiachi.AutoSize = true;
            this.lb_sdiachi.Location = new System.Drawing.Point(23, 208);
            this.lb_sdiachi.Name = "lb_sdiachi";
            this.lb_sdiachi.Size = new System.Drawing.Size(60, 20);
            this.lb_sdiachi.TabIndex = 3;
            this.lb_sdiachi.Text = "Địa Chỉ";
            // 
            // lb_sodienthoai
            // 
            this.lb_sodienthoai.AutoSize = true;
            this.lb_sodienthoai.Location = new System.Drawing.Point(23, 159);
            this.lb_sodienthoai.Name = "lb_sodienthoai";
            this.lb_sodienthoai.Size = new System.Drawing.Size(102, 20);
            this.lb_sodienthoai.TabIndex = 2;
            this.lb_sodienthoai.Text = "Số điện thoại";
            // 
            // lb_sHoTen
            // 
            this.lb_sHoTen.AutoSize = true;
            this.lb_sHoTen.Location = new System.Drawing.Point(23, 103);
            this.lb_sHoTen.Name = "lb_sHoTen";
            this.lb_sHoTen.Size = new System.Drawing.Size(122, 20);
            this.lb_sHoTen.TabIndex = 1;
            this.lb_sHoTen.Text = "Họ tên sinh viên";
            // 
            // lb_iMaSV
            // 
            this.lb_iMaSV.AutoSize = true;
            this.lb_iMaSV.Location = new System.Drawing.Point(23, 47);
            this.lb_iMaSV.Name = "lb_iMaSV";
            this.lb_iMaSV.Size = new System.Drawing.Size(96, 20);
            this.lb_iMaSV.TabIndex = 0;
            this.lb_iMaSV.Text = "Mã sinh viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GrV_DSSV);
            this.groupBox1.Location = new System.Drawing.Point(35, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 242);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Sinh Viên";
            // 
            // GrV_DSSV
            // 
            this.GrV_DSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrV_DSSV.Location = new System.Drawing.Point(2, 25);
            this.GrV_DSSV.Name = "GrV_DSSV";
            this.GrV_DSSV.RowHeadersWidth = 62;
            this.GrV_DSSV.RowTemplate.Height = 28;
            this.GrV_DSSV.Size = new System.Drawing.Size(740, 217);
            this.GrV_DSSV.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 668);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grb_themSV);
            this.Name = "Form1";
            this.Text = "oi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grb_themSV.ResumeLayout(false);
            this.grb_themSV.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrV_DSSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_themSV;
        private System.Windows.Forms.Label lb_iMaSV;
        private System.Windows.Forms.Label lb_dngaysinh;
        private System.Windows.Forms.Label lb_bgioitinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_sdiachi;
        private System.Windows.Forms.Label lb_sodienthoai;
        private System.Windows.Forms.Label lb_sHoTen;
        private System.Windows.Forms.TextBox tb_sDiaChi;
        private System.Windows.Forms.TextBox tb_sSDT;
        private System.Windows.Forms.TextBox tb_sHoTen;
        private System.Windows.Forms.TextBox tb_sMaSV;
        private System.Windows.Forms.RadioButton rd_GTNu;
        private System.Windows.Forms.RadioButton rd_GTNam;
        private System.Windows.Forms.Button bt_ThemMoi;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox mtb_dNgaySinh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView GrV_DSSV;
    }
}

