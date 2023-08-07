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
    public partial class FrmDSHoaDonBan : Form
    {
        public FrmDSHoaDonBan()
        {
            InitializeComponent();
        }

        private void FrmDSHoaDonBan_Load(object sender, EventArgs e)
        {
            HienThiDanhSachHoaDonBan();
        }
        private void HienThiDanhSachHoaDonBan()
        {
            string tuKhoa = "";
            //Lấy thông tin cần tìm kiếm
            tuKhoa = txtTuKhoa.Text.Trim();


            //Lấy danh sách
            DataTable dtHoaDonB = DataProvider.HoaDonBanBus.LayDanhSach();

            gridHoaDonBan.DataSource = null;
            gridHoaDonBan.DataSource = dtHoaDonB;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //Khai báo 1 đối tượng
            FrmHoaDonBanAdd frmThemHD = new FrmHoaDonBanAdd();

            //Hiển thị form
            frmThemHD.ShowDialog();

            //Reload lại danh sách 
            HienThiDanhSachHoaDonBan();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            string maHoaDon = "";

            //lấy mã sinh viên chọn trên grid
            maHoaDon = "" + gridHoaDonBan.CurrentRow.Cells[0].Value;

            //Khai báo 1 đối tượng
            FrmHoaDonBanAdd frmXemChiTiet = new FrmHoaDonBanAdd();
            frmXemChiTiet.MaHoaDon = maHoaDon;
            //Hiển thị form
            frmXemChiTiet.ShowDialog();
            //Reload lại danh sách 
            HienThiDanhSachHoaDonBan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                //Thực hiện xóa
                string maHoaDon = "";

                //lấy mã hd chọn trên grid
                maHoaDon = "" + gridHoaDonBan.CurrentRow.Cells[0].Value;

                bool ketQua = DataProvider.HoaDonBanBus.Xoa(maHoaDon);

                if (ketQua)
                {
                    //Reload lại danh sách
                    HienThiDanhSachHoaDonBan();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
