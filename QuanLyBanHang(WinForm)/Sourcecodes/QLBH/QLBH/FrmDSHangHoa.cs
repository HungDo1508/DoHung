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
    public partial class FrmDSHangHoa : Form
    {
        public FrmDSHangHoa()
        {
            InitializeComponent();
        }
        
        private void FrmDSHangHoa_Load(object sender, EventArgs e)
        {
            HienThiDanhSachHangHoa();
        }
        private void HienThiDanhSachHangHoa()
        {
            string tuKhoa = "";
            //Lấy thông tin cần tìm kiếm
            tuKhoa = txtTuKhoa.Text.Trim();
            //Lấy danh sách
            DataTable dtHangHoa = DataProvider.HangHoaBus.TimKiemHangHoa(tuKhoa);
            gridHangHoa.DataSource = null;
            gridHangHoa.DataSource = dtHangHoa;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSachHangHoa();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //Khai báo 1 đối tượng
            FrmHangHoaAdd frmThem = new FrmHangHoaAdd();

            //Hiển thị form
            frmThem.ShowDialog();

            //Reload lại danh sách 
            HienThiDanhSachHangHoa();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHH = "";

            //lấy mã hàng hóa chọn trên grid
            maHH = "" + gridHangHoa.CurrentRow.Cells[0].Value;

            //Khai báo 1 đối tượng
           FrmHangHoaAdd frmSua = new FrmHangHoaAdd();

            //Truyền mã hàng hóa lên giao diện
            frmSua.MaHang = maHH;

            //Hiển thị form
            frmSua.ShowDialog();

            //Reload lại danh sách 
            HienThiDanhSachHangHoa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin hàng hóa này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                //Thực hiện xóa
                string maHH = "";

                //lấy mã hh chọn trên grid
                maHH = "" + gridHangHoa.CurrentRow.Cells[0].Value;


                bool ketQua = DataProvider.HangHoaBus.Xoa(maHH);

                if (ketQua)
                {
                    //Reload lại danh sách
                    HienThiDanhSachHangHoa();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
