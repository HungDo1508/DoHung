using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class FrmKhachHangAdd : Form
    {
        public string MaKhachHang { get; set; } = "";
        public FrmKhachHangAdd()
        {
            InitializeComponent();
        }
        private void HienThiDanhKhachVip()
        {
            //Khai báo đối tượng
            KhachVipBusiness khachvipBusiness = new KhachVipBusiness();

            DataTable dtKV = khachvipBusiness.LayDanhSach();

            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboLoai.DataSource = dtKV;
        }
        private void HienThiChiTietKhachHang()
        {
            
            KhachHang objKH = DataProvider.KhachHangBus.LayChiTietTheoMa(MaKhachHang);

            if (objKH != null)
            {
                txtMaKH.Text = MaKhachHang;
                txtMaKH.ReadOnly = true;
                txtTenKH.Text = objKH.TenKhachHang;
                txtDienThoai.Text = objKH.DienThoai;
                txtEmail.Text = objKH.Email;
                txtDiaChi.Text = objKH.DiaChi;
                cboLoai.SelectedValue = objKH.MaLoai;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Khai báo biến
            string maKH = "", TenKH = "", dienThoai = "", email = "", diaChi = "", maLoai = "";
            //Lấy thông tin trên giao diện cho các biến
            maKH = txtMaKH.Text.Trim();
            TenKH = txtTenKH.Text.Trim();
            dienThoai = txtDienThoai.Text.Trim();
            email = txtEmail.Text.Trim();
            diaChi = txtDiaChi.Text;

            
            KhachHang objKH = new KhachHang();

            //Gán giá trị cho các thuộc tính
            objKH.MaKhachHang = maKH;
            objKH.TenKhachHang = TenKH;
            objKH.DienThoai = dienThoai;
            objKH.Email = email;
            objKH.DiaChi = diaChi;

            //Xử lý lấy thông tin
           
            maLoai = "" + cboLoai.SelectedValue;

            objKH.MaLoai = maLoai;

            bool ketQua = false;

            //TH sửa
            if (!string.IsNullOrEmpty(MaKhachHang))
            {
                //Gọi hàm sửa
                ketQua = DataProvider.KhachHangBus.CapNhat(objKH);
            }
            else
            {
                //Gọi hàm thêm mới
                ketQua = DataProvider.KhachHangBus.ThemMoi(objKH);
            }
            if (ketQua)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông báo");
            }
        }

        private void FrmKhachHangAdd_Load(object sender, EventArgs e)
        {
            //Gọi hàm hiển thị khoa
            HienThiDanhKhachVip();

            //TH sửa
            if (!string.IsNullOrEmpty(MaKhachHang))
            {
                this.Text = "Sửa thông tin khách";
                //Hiển thị thông tin chi tiết
                HienThiChiTietKhachHang();
            }
            else
            {
                this.Text = "Thêm mới khách";
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
