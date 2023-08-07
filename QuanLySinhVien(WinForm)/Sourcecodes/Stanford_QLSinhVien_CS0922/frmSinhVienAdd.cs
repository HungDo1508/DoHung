using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stanford_QLSinhVien_CS0922
{
    public partial class frmSinhVienAdd : Form
    {
        /// <summary>
        /// Khai báo 1 thuộc tính để chứa mã sv trong TH sửa
        /// </summary>
        public string MaSinhVien { get; set; } = "";

        public frmSinhVienAdd()
        {
            InitializeComponent();
        }

        private void frmSinhVienAdd_Load(object sender, EventArgs e)
        {
            //Gọi hàm hiển thị khoa
            HienThiDanhSachKhoa();

            //TH sửa
            if (!string.IsNullOrEmpty(MaSinhVien))
            {
                this.Text = "Sửa thông tin sinh viên";
                //Hiển thị thông tin chi tiết
                HienThiChiTietSinhVien();
            }  
            else
            {
                this.Text = "Thêm mới sinh viên";
            }   
        }

        /// <summary>
        /// Hàm hiển thị danh sách khoa lên combobox
        /// </summary>
        private void HienThiDanhSachKhoa()
        {
            //Khai báo đối tượng
            ChuyenKhoaBusiness chuyenKhoaBusiness = new ChuyenKhoaBusiness();

            DataTable dtKhoa = chuyenKhoaBusiness.LayDanhSach();

            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DataSource = dtKhoa;
        }

        /// <summary>
        /// Hàm hiển thị thông tin chi tiết sinh viên theo mã
        /// </summary>
        private void HienThiChiTietSinhVien()
        {
            //Lấy đối tượng sinh viên
            SinhVien objSV = DataProvider.SinhVienBus.LayChiTietTheoMa(MaSinhVien);

            if(objSV != null)
            {
                txtMaSV.Text = MaSinhVien;
                txtMaSV.ReadOnly = true;
                txtHoTen.Text = objSV.HoTen;
                txtDienThoai.Text = objSV.DienThoai;
                txtEmail.Text = objSV.Email;
                txtDiaChi.Text = objSV.DiaChi;
                //Hiển thị lên giao diện
                cboGioiTinh.SelectedIndex = objSV.GioiTinh;
                dtpNgaySinh.Value = objSV.NgaySinh;
                cboKhoa.SelectedValue = objSV.MaKhoa;
            }    
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Khai báo biến
            string maSV = "", hoTen = "", dienThoai = "", email = "", diaChi = "", maKhoa = "";
            int gioiTinh = 0;
            //Lấy thông tin trên giao diện cho các biến
            maSV = txtMaSV.Text.Trim();
            hoTen = txtHoTen.Text.Trim();
            dienThoai = txtDienThoai.Text.Trim();
            email = txtEmail.Text.Trim();
            diaChi = txtDiaChi.Text;

            //Khai báo 1 đối tượng sinh viên
            SinhVien objSV = new SinhVien();

            //Gán giá trị cho các thuộc tính
            objSV.MaSV = maSV;
            objSV.HoTen = hoTen;
            objSV.DienThoai = dienThoai;
            objSV.Email = email;
            objSV.DiaChi = diaChi;

            //Xử lý lấy thông tin
            gioiTinh = cboGioiTinh.SelectedIndex;

            objSV.GioiTinh = gioiTinh;

            objSV.NgaySinh = dtpNgaySinh.Value;

            maKhoa = "" + cboKhoa.SelectedValue;

            objSV.MaKhoa = maKhoa;

            bool ketQua = false;

            //TH sửa
            if (!string.IsNullOrEmpty(MaSinhVien))
            {
                //Gọi hàm sửa
                ketQua = DataProvider.SinhVienBus.CapNhat(objSV);
            }
            else
            {
                //Gọi hàm thêm mới
                ketQua = DataProvider.SinhVienBus.ThemMoi(objSV);
            }
            if(ketQua)
            {
                MessageBox.Show("Cập nhật thông tin sinh viên thành công", "Thông báo");
            }    
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            //Đóng form hiện thời
            this.Close();
        }
    }
}
