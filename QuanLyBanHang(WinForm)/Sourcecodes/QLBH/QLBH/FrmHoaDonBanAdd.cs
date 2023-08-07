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
    public partial class FrmHoaDonBanAdd : Form
    {
        public string MaHoaDon { get; set; } = "";
        public string MaKhachHang { get; set; } = "";
        public FrmHoaDonBanAdd()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void HienThiDanhSachHoaDonBan()
        {
            //Khai báo đối tượng
            HoaDonBanBusiness HoaDonBanBusiness = new HoaDonBanBusiness();

            DataTable dtHDB = HoaDonBanBusiness.LayDanhSach();

        }
        private void HienThiMaKhachHang()
        {
            //Khai báo đối tượng
            KhachHangBusiness khachHangBusiness = new KhachHangBusiness();

            DataTable dtKhachHang = khachHangBusiness.LayTenKhach();

            //Tạo 1 dòng dữ liệu mới để hiển thị tất cả sinh viên
            DataRow root = dtKhachHang.NewRow();
            root["MaKhachHang"] = "--Chọn mã khách hàng--";
            //Chèn vào đầu danh sách
            dtKhachHang.Rows.InsertAt(root, 0);

            cboMaKhachHang.DisplayMember = "MaKhachHang";
            cboMaKhachHang.ValueMember = "MaKhachHang";
            cboMaKhachHang.DataSource = dtKhachHang;
        }
        private void HienThiMaHoaDon()
        {
            //Khai báo đối tượng
            HoaDonMuaBusiness hoaDonMuaBusiness = new HoaDonMuaBusiness();

            DataTable dtHDM = hoaDonMuaBusiness.LayMaHoaDon();

            //Tạo 1 dòng dữ liệu mới để hiển thị tất cả sinh viên
            DataRow root = dtHDM.NewRow();
            root["MaHoaDon"] = "---Chọn mã hóa đơn---";
            
            //Chèn vào đầu danh sách
            dtHDM.Rows.InsertAt(root, 0);

            cboMaHoaDon.DisplayMember = "MaHoaDon";
            cboMaHoaDon.ValueMember = "MaHoaDon";
            cboMaHoaDon.DataSource = dtHDM;
        }
        private void HienThiHoaDonBan()
        {

            HoaDonBan objHDB = DataProvider.HoaDonBanBus.LayChiTietTheoMa(MaHoaDon);

            if (objHDB != null)
            {
                cboMaHoaDon.Text = MaHoaDon;
                cboMaHoaDon.Enabled = false;
                cboMaKhachHang.Text = objHDB.MaKhachHang;
                cboMaKhachHang.Enabled = false;
                txtTenHoaDon.Text = objHDB.TenHoaDon;
                dtpNgayMua.Value = objHDB.NgayBan;
                txtMoTa.Text = objHDB.MoTa;

            }
        }

        private void FrmHoaDonBanAdd_Load(object sender, EventArgs e)
        {
            HienThiDanhSachHoaDonBan();
            HienThiMaKhachHang();
            HienThiMaHoaDon();
            //TH sửa
            if (!string.IsNullOrEmpty(MaHoaDon))
            {
                this.Text = "Xem chi tiết hóa đơn ";
                //Hiển thị thông tin chi tiết
                HienThiHoaDonBan();
            }
            else
            {
                this.Text = "Thêm mới hóa đơn";
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Khai báo biến
            string maHoaDon = "", tenHoaDon = "", MoTa = "" ,maKhachHang= "";
            DateTime ngayBan;
            //Lấy thông tin trên giao diện cho các biến
            maHoaDon = cboMaHoaDon.Text;
            maKhachHang = cboMaKhachHang.Text;
            tenHoaDon = txtTenHoaDon.Text.Trim();
            MoTa = txtMoTa.Text;
            ngayBan = dtpNgayMua.Value;
            HoaDonBan objHDB = new HoaDonBan();
            //Gán giá trị cho các thuộc tính
            objHDB.MaHoaDon = maHoaDon;
            objHDB.MaKhachHang = maKhachHang;
            objHDB.TenHoaDon = tenHoaDon;
            objHDB.MoTa = MoTa;
            objHDB.NgayBan = ngayBan;


            bool ketQua = false;
            //Gọi hàm thêm mới
            //TH sửa
            if (!string.IsNullOrEmpty(MaHoaDon))
            {

                ketQua = DataProvider.HoaDonBanBus.CapNhat(objHDB);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            else
            {
                //Gọi hàm thêm mới
                ketQua = DataProvider.HoaDonBanBus.ThemMoi(objHDB);
                MessageBox.Show("Thêm mới hóa đơn thành công", "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
