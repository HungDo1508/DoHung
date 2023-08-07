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
    public partial class FrmHoaDonMuaAdd : Form
    {
        
        public string MaHoaDon { get; set; } = "";
        public string MaHang { get; set; } = "";
        public FrmHoaDonMuaAdd()
        {
            InitializeComponent();
        }
        private void HienThiDanhSachHoaDonMua()
        {
            //Khai báo đối tượng
            HoaDonMuaBusiness HoaDonMuaBusiness = new HoaDonMuaBusiness();

            DataTable dtHDM = HoaDonMuaBusiness.LayDanhSach();

        }

        /// <summary>
        /// Hàm hiển thị thông tin chi tiết sinh viên theo mã
        /// </summary>
        private void HienThiHoaDonMua()
        {
            
            HoaDonMua objHDM = DataProvider.HoaDonMuaBus.LayChiTietTheoMa(MaHoaDon);

            if (objHDM != null)
            {
                txtMaHoaDon.Text = MaHoaDon;
                txtMaHoaDon.ReadOnly = true;
                txtTenHoaDon.Text = objHDM.TenHoaDon;
                dtpNgayMua.Value = objHDM.NgayMua;
                txtMoTa.Text = objHDM.MoTa;

            }
        }
        private void HienThiHoaDonMuaChiTiet()
        {
           
            txtMaHoaDon.Text = MaHoaDon;
            DataTable dtHang = DataProvider.HangBus.LocHoaDon(MaHoaDon);
            GridThemHoaDonBan.DataSource = null;
            GridThemHoaDonBan.DataSource = dtHang;
             
        }
        //private void HienThiTenHang()
        //{
        //    //Khai báo đối tượng
        //    HangBusiness hangBusiness = new HangBusiness();

        //    DataTable dtTenHang = hangBusiness.LayDanhSach();

        //    //Tạo 1 dòng dữ liệu mới để hiển thị tất cả sinh viên
        //    DataRow root = dtTenHang.NewRow();
        //    root["MaHang"] = "";
        //    root["MaHang"] = "---Chọn Hàng---";
        //    //Chèn vào đầu danh sách
        //    dtTenHang.Rows.InsertAt(root, 0);

        //    cboChonHang.DisplayMember = "TenHang";
        //    cboChonHang.ValueMember = "MaHang";
        //    cboChonHang.DataSource = dtTenHang;
        //}



        private void gridHoaDonChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmHoaDonMuaAdd_Load(object sender, EventArgs e)
        {

            HienThiHoaDonMuaChiTiet();
            HienThiDanhSachHoaDonMua();
            //Tính tổng số lượng hàng
            int tsl = GridThemHoaDonBan.Rows.Count;
            int tongSL = 0;
            for (int i = 0; i < tsl - 1; i++)
            {
                tongSL += int.Parse(GridThemHoaDonBan.Rows[i].Cells[2].Value.ToString());
            }
            lbTongHang.Text = tongSL.ToString();
            //Tính tổng tiền 
            int tt = GridThemHoaDonBan.Rows.Count;
            int tongTien = 0;
            for (int i = 0; i < tt - 1; i++)
            {
                tongTien += int.Parse(GridThemHoaDonBan.Rows[i].Cells[4].Value.ToString());
            }
            lbTongTien.Text = tongTien.ToString();



            //TH sửa
            if (!string.IsNullOrEmpty(MaHoaDon))
            {
                this.Text = "Xem chi tiết hóa đơn ";
                //Hiển thị thông tin chi tiết
                HienThiHoaDonMua();
            }
            else
            {
                this.Text = "Thêm mới hóa đơn";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //Khai báo biến
            string maHoaDon = "", tenHoaDon = "", MoTa = "";
            DateTime ngaymua;
            //Lấy thông tin trên giao diện cho các biến
            maHoaDon = txtMaHoaDon.Text.Trim();
            tenHoaDon = txtTenHoaDon.Text.Trim();
            MoTa = txtMoTa.Text;
            ngaymua = dtpNgayMua.Value;
            HoaDonMua objHDM = new HoaDonMua();
            //Gán giá trị cho các thuộc tính
            objHDM.MaHoaDon = maHoaDon;
            objHDM.TenHoaDon =tenHoaDon;
            objHDM.MoTa = MoTa;
            objHDM.NgayMua = ngaymua;

           
            bool ketQua = false;
            //Gọi hàm thêm mới
            //TH sửa
            if (!string.IsNullOrEmpty(MaHoaDon))
            {

                ketQua = DataProvider.HoaDonMuaBus.CapNhat(objHDM);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            else
            {
                //Gọi hàm thêm mới
                ketQua = DataProvider.HoaDonMuaBus.ThemMoi(objHDM);
                MessageBox.Show("Thêm mới hóa đơn thành công", "Thông báo");
            }
           
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            string maHoaDon = "", maHang = "";
            //giaMua ="" , soLuong="";
            int giaMua = 0, soLuong = 0 , thanhTien =0;
            // int giaMua, soLuong, thanhTien;
            //Lấy thông tin trên giao diện cho các biến
            // tenHang = cboChonHang.Text;
            maHoaDon = txtMaHoaDon.Text.Trim();
            maHang = txtMaHang.Text;
            giaMua = int.Parse(txtGiaMua.Text);
            soLuong = int.Parse(txtSoLuong.Text);
            //thanhTien = int.Parse(lbThanhTien.Text);
            thanhTien = soLuong * giaMua;
            lbThanhTien.Text = thanhTien.ToString();

            
            
            Hang objHang = new Hang();
            objHang.MaHoaDon = maHoaDon;
            objHang.MaHang = maHang;
            objHang.GiaMua = giaMua;
            objHang.SoLuong = soLuong;
            objHang.ThanhTien = thanhTien;
           
            bool ketQua = false;
            //Gọi hàm thêm mới
            ketQua = DataProvider.HangBus.ThemMoi(objHang);
            MessageBox.Show("Thêm mới mặt hàng thành công", "Thông báo");
            if (ketQua)
            {
                //Reload lại danh sách
                HienThiHoaDonMuaChiTiet();
                lbTongTien.ResetText();
                lbTongHang.ResetText();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                
                
               string maHang = "" , maHoaDon ="";

                maHang = "" + GridThemHoaDonBan.CurrentRow.Cells[1].Value;
                maHoaDon = "" + GridThemHoaDonBan.CurrentRow.Cells[0].Value;

                bool ketQua = DataProvider.HangBus.Xoa(maHang,maHoaDon);
                MessageBox.Show("Xóa mặt hàng thành công", "Thông báo");
                if (ketQua)
                {
                    //Reload lại danh sách
                    HienThiHoaDonMuaChiTiet();
                    lbTongTien.ResetText();
                    lbTongHang.ResetText();

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
        
}
