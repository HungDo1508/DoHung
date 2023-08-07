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
    public partial class FrmHangHoaAdd : Form
    {
        public string MaHang { get; set; } = "";
        public FrmHangHoaAdd()
        {
            InitializeComponent();
        }
        private void HienThiChiTietHangHoa()
        {

            HangHoa objHangHoa = DataProvider.HangHoaBus.LayChiTietTheoMa(MaHang);

            if (objHangHoa != null)
            {
                txtMaHH.Text = MaHang;
                txtMaHH.ReadOnly = true;
                txtTenHH.Text = objHangHoa.TenHang;
                txtMoTa.Text = objHangHoa.MoTa;
                txtXuatXu.Text = objHangHoa.XuatXu;
                
            }
        }

        private void FrmHangHoaAdd_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MaHang))
            {
                this.Text = "Sửa thông tin hàng hóa";
                //Hiển thị thông tin chi tiết
                HienThiChiTietHangHoa();
            }
            else
            {
                this.Text = "Thêm mới hàng hóa";
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Khai báo biến
            string maHH = "", tenHang = "", MoTa = "", xuatXu = "";
            //Lấy thông tin trên giao diện cho các biến
            maHH = txtMaHH.Text.Trim();
            tenHang = txtTenHH.Text.Trim();
            MoTa = txtMoTa.Text;
            xuatXu = txtXuatXu.Text;
            
            
            HangHoa objHangHoa = new HangHoa();
            //Gán giá trị cho các thuộc tính
            objHangHoa.MaHang = maHH;
            objHangHoa.TenHang = tenHang;
            objHangHoa.MoTa = MoTa;
            objHangHoa.XuatXu = xuatXu;
            
    

            bool ketQua = false;

            //TH sửa
            if (!string.IsNullOrEmpty(MaHang))
            {
                //Gọi hàm sửa
                ketQua = DataProvider.HangHoaBus.CapNhat(objHangHoa);
            }
            else
            {
                //Gọi hàm thêm mới
                ketQua = DataProvider.HangHoaBus.ThemMoi(objHangHoa);
            }
            if (ketQua)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
