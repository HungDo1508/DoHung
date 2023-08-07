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
    public partial class FrmCuaSoChinh : Form
    {
        public FrmCuaSoChinh()
        {
            InitializeComponent();
        }

        private void menuItemKhachHang_Click(object sender, EventArgs e)
        {
            FrmDanhSachKhachHang frmDSKH = new FrmDanhSachKhachHang();
            frmDSKH.MdiParent = this;
            frmDSKH.Show();
        }

        private void menuItemHoaDonMua_Click(object sender, EventArgs e)
        {
            FrmDSHoaDonMua frmDSHDM = new FrmDSHoaDonMua();
            frmDSHDM.MdiParent = this;
            frmDSHDM.Show();
        }

        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemHangHoa_Click(object sender, EventArgs e)
        {
            FrmDSHangHoa frmDSHH = new FrmDSHangHoa();
            frmDSHH.MdiParent = this;
            frmDSHH.Show();
        }

        private void menuItemHoaDonBan_Click(object sender, EventArgs e)
        {
            FrmDSHoaDonBan frmDSHDB = new FrmDSHoaDonBan();
            frmDSHDB.MdiParent = this;
            frmDSHDB.Show();
        }
    }
}
