using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_.NET
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quanLyHangHoa qlhh = new quanLyHangHoa();
            qlhh.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            phieu phieu = new phieu();
            phieu.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            quanlykhachhang qlkh = new quanlykhachhang();
            qlkh.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            quanlynhacungcap qlncc = new quanlynhacungcap();
            qlncc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hoaDonkh hoaDonkh = new hoaDonkh();
            hoaDonkh.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hoadonnhacungcap hdncc = new hoadonnhacungcap();
            hdncc.ShowDialog();
        }
    }
}
