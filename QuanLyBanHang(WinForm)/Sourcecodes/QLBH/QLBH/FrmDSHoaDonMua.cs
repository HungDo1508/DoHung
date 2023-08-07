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
    public partial class FrmDSHoaDonMua : Form
    {
        public FrmDSHoaDonMua()
        {
            InitializeComponent();
        }

        private void FrmDSHoaDonMua_Load(object sender, EventArgs e)
        {
            HienThiDanhSachHoaDonMua();
        }
        private void HienThiDanhSachHoaDonMua()
        {
            string tuKhoa = "";
            //Lấy thông tin cần tìm kiếm
            tuKhoa = txtTuKhoa.Text.Trim();


            //Lấy danh sách
            DataTable dtHoaDonM = DataProvider.HoaDonMuaBus.LayDanhSach();

            gridHoaDonMua.DataSource = null;
            gridHoaDonMua.DataSource = dtHoaDonM;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //Khai báo 1 đối tượng
            FrmHoaDonMuaAdd frmThemHD = new FrmHoaDonMuaAdd();

            //Hiển thị form
            frmThemHD.ShowDialog();

            //Reload lại danh sách sv
            HienThiDanhSachHoaDonMua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                //Thực hiện xóa
                string maHoaDon = "";

                //lấy mã sinh viên chọn trên grid
                maHoaDon = "" + gridHoaDonMua.CurrentRow.Cells[0].Value;

                bool ketQua = DataProvider.HoaDonMuaBus.Xoa(maHoaDon);

                if (ketQua)
                {
                    //Reload lại danh sách
                   HienThiDanhSachHoaDonMua();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            string maHoaDon = "";

            //lấy mã sinh viên chọn trên grid
            maHoaDon = "" + gridHoaDonMua.CurrentRow.Cells[0].Value;

            //Khai báo 1 đối tượng
            FrmHoaDonMuaAdd frmXemChiTiet = new FrmHoaDonMuaAdd();
            frmXemChiTiet.MaHoaDon = maHoaDon;
            //Hiển thị form
            frmXemChiTiet.ShowDialog();
            //Reload lại danh sách sv
            HienThiDanhSachHoaDonMua();
        }
    }
}
