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
    public partial class FrmDanhSachKhachHang : Form
    {
        public FrmDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void FormDSKH_Load(object sender, EventArgs e)
        {
            HienThiDanhSachKhachHang();
            HienThiDanhSachKhachVip();
        }
        private void HienThiDanhSachKhachVip()
        {
            //Khai báo đối tượng
            KhachVipBusiness khachvipBusiness = new KhachVipBusiness();

            DataTable dtLoai = khachvipBusiness.LayDanhSach();

            //Tạo 1 dòng dữ liệu mới để hiển thị tất cả loại
            DataRow root = dtLoai.NewRow();
            root["MaLoai"] = "";
            root["TenLoai"] = "---Chọn Loại---";
            //Chèn vào đầu danh sách
            dtLoai.Rows.InsertAt(root, 0);

            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboLoai.DataSource = dtLoai;
        }
        private void HienThiDanhSachKhachHang()
        {
            string tuKhoa = "", maLoai = "";
            //Lấy thông tin cần tìm kiếm
            tuKhoa = txtTuKhoa.Text.Trim();
            maLoai = "" + cboLoai.SelectedValue;
            //Lấy danh sách
            DataTable dtKhachHang = DataProvider.KhachHangBus.TimKiemKhachHang(tuKhoa,maLoai);
            gridKhachHang.DataSource = null;
            gridKhachHang.DataSource = dtKhachHang;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSachKhachHang();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin khách hàng này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                //Thực hiện xóa
                string maKH = "" ;

                //lấy mã sinh viên chọn trên grid
                maKH = "" + gridKhachHang.CurrentRow.Cells[0].Value;

                
                bool ketQua = DataProvider.KhachHangBus.Xoa(maKH);
                
                if (ketQua)
                {
                    //Reload lại danh sách
                    HienThiDanhSachKhachHang();
                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //Khai báo 1 đối tượng
            FrmKhachHangAdd frmThem = new FrmKhachHangAdd();

            //Hiển thị form
            frmThem.ShowDialog();

            //Reload lại danh sách sv
            HienThiDanhSachKhachHang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKH = "";

            //lấy mã khách hàng chọn trên grid
            maKH = "" + gridKhachHang.CurrentRow.Cells[0].Value;

            //Khai báo 1 đối tượng
            FrmKhachHangAdd frmSua = new FrmKhachHangAdd();

            //Truyền mã sinh viên lên giao diện
            frmSua.MaKhachHang = maKH;

            //Hiển thị form
            frmSua.ShowDialog();

            //Reload lại danh sách 
            HienThiDanhSachKhachHang();
        }
    }
}
