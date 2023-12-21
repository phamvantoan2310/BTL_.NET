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
    public partial class quanLyHangHoa : Form
    {
        hanghoa hh = new hanghoa();
        phieunhapkho pnk = new phieunhapkho();
        phieuxuatkho pxk = new phieuxuatkho();
        DataTable dt;
        DataTable dt2;
        DataTable dt3;
        DataTable dt4;
        public quanLyHangHoa()
        {
            InitializeComponent();
        }

        private void buocCacDieuKhien()
        {
            dt = hh.layDanhSachHangHoa();
            dt2 = pnk.layDanhSachPhieuNhapKho();
            dt3 = pxk.layDanhSachPhieuXuatKho();
            dt4 = hh.layDanhSachHangHoaConTon();
     
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;
            dataGridView3.DataSource = dt3;
            dataGridView4.DataSource = dt4;

            textBox1.DataBindings.Add("text", dt, "mahanghoa");
            textBox2.DataBindings.Add("text", dt, "tenhanghoa");
            textBox3.DataBindings.Add("text", dt, "gia");
            textBox4.DataBindings.Add("text", dt, "soluong");

            dataGridView1.Columns["mahanghoa"].Width = 113;
            dataGridView1.Columns["tenhanghoa"].Width = 176;
            dataGridView1.Columns["gia"].Width = 80;
            dataGridView1.Columns["soluong"].Width = 80;

            dataGridView2.Columns["maphieu"].Width = 80;
            dataGridView2.Columns["ngaynhap"].Width = 80;
            dataGridView2.Columns["soluong"].Width = 80;
            dataGridView2.Columns["gia"].Width = 80;
            dataGridView2.Columns["mahanghoa"].Width = 80;
            dataGridView2.Columns["manhacungcap"].Width = 80;

            dataGridView3.Columns["maphieu"].Width = 80;
            dataGridView3.Columns["ngayxuat"].Width = 80;
            dataGridView3.Columns["soluong"].Width = 80;
            dataGridView3.Columns["gia"].Width = 80;
            dataGridView3.Columns["mahanghoa"].Width = 80;
            dataGridView3.Columns["makhachhang"].Width = 80;

            dataGridView4.Columns["tenhanghoa"].Width = 120;
            dataGridView4.Columns["soluong"].Width = 75;
        }

        private void quanLyHangHoa_Load(object sender, EventArgs e)
        {
            buocCacDieuKhien();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hh.update(dt);
            MessageBox.Show("lưu thành công");
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
   
            this.BindingContext[dt].AddNew();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                this.BindingContext[dt].RemoveAt(rowIndex);
             
            }
            else
            {
                MessageBox.Show("chọn một loại hàng hóa");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
