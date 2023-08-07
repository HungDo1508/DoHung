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
    public partial class frmDanhSachSinhVien : Form
    {
        public frmDanhSachSinhVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý công việc khi form hiển thị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDanhSachSinhVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSachKhoa();

            HienThiDanhSachSinhVien();
        }

        /// <summary>
        /// Hàm hiển thị danh sách khoa lên combobox
        /// </summary>
        private void HienThiDanhSachKhoa()
        {
            //Khai báo đối tượng
            ChuyenKhoaBusiness chuyenKhoaBusiness = new ChuyenKhoaBusiness();

            DataTable dtKhoa = chuyenKhoaBusiness.LayDanhSach();

            //Tạo 1 dòng dữ liệu mới để hiển thị tất cả sinh viên
            DataRow root = dtKhoa.NewRow();
            root["MaKhoa"] = "";
            root["TenKhoa"] = "---Chọn khoa---";
            //Chèn vào đầu danh sách
            dtKhoa.Rows.InsertAt(root, 0);

            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DataSource = dtKhoa;
        }

        /// <summary>
        /// Hàm hiển thị danh sách sinh viên
        /// </summary>
        private void HienThiDanhSachSinhVien()
        {
            string tuKhoa = "", maKhoa = "";
            //Lấy thông tin cần tìm kiếm
            tuKhoa = txtTuKhoa.Text.Trim();
            maKhoa = "" + cboKhoa.SelectedValue;
            //Lấy danh sách
            DataTable dtSinhVien = DataProvider.SinhVienBus.TimKiemSinhVien(tuKhoa, maKhoa);

            gridSinhVien.DataSource = dtSinhVien;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //Khai báo 1 đối tượng
            frmSinhVienAdd frmThem = new frmSinhVienAdd();

            //Hiển thị form
            frmThem.ShowDialog();

            //Reload lại danh sách sv
            HienThiDanhSachSinhVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSV = "";

            //lấy mã sinh viên chọn trên grid
            maSV = "" + gridSinhVien.CurrentRow.Cells[0].Value;

            //Khai báo 1 đối tượng
            frmSinhVienAdd frmSua = new frmSinhVienAdd();

            //Truyền mã sinh viên lên giao diện
            frmSua.MaSinhVien = maSV;

            //Hiển thị form
            frmSua.ShowDialog();

            //Reload lại danh sách sv
            HienThiDanhSachSinhVien();
        }

        /// <summary>
        /// Xóa thông tin sinh viên khỏi hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin sinh viên này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dr == DialogResult.Yes)
            {
                //Thực hiện xóa
                string maSV = "";

                //lấy mã sinh viên chọn trên grid
                maSV = "" + gridSinhVien.CurrentRow.Cells[0].Value;

                bool ketQua = DataProvider.SinhVienBus.Xoa(maSV);

                if(ketQua)
                {
                    //Reload lại danh sách
                    HienThiDanhSachSinhVien();
                }    
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSachSinhVien();
        }
    }
}
