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
    public partial class quanlykhachhang : Form
    {
        khachhang kh = new khachhang();
        phieuxuatkho pxk = new phieuxuatkho();
        DataTable dtkh;
        DataTable dtpxk;
        public quanlykhachhang()
        {
            InitializeComponent();
        }

        public void buocCacDieuKien()
        {
            dtkh = kh.layDanhSachKhachHang();
            dataGridView1.DataSource = dtkh;
            textBox1.DataBindings.Add("text", dtkh, "tenkhachhang");
            textBox2.DataBindings.Add("text", dtkh, "diachi");
            textBox3.DataBindings.Add("text", dtkh, "email");
            textBox4.DataBindings.Add("text", dtkh, "tienconno");
            textBox8.DataBindings.Add("text", dtkh, "tenkhachhang");

            dataGridView1.Columns["makhachhang"].Width = 130;
            dataGridView1.Columns["tenkhachhang"].Width = 130;
            dataGridView1.Columns["diachi"].Width = 130;
            dataGridView1.Columns["email"].Width = 130;
            dataGridView1.Columns["tienconno"].Width = 130;

            
        }

        private void quanlykhachhang_Load(object sender, EventArgs e)
        {
            buocCacDieuKien();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow row = dataGridView1.Rows[index];
            object obj = row.Cells["makhachhang"].Value;

            if(obj != null)
            {
                int khachhangid = int.Parse(obj.ToString());
                dtpxk = pxk.layDanhSachPhieuXuatKhoQuanLyKhachHang(khachhangid);
                dataGridView2.DataSource = dtpxk;
                dataGridView2.Columns["mahanghoa"].Width = 130;
                dataGridView2.Columns["ngayxuat"].Width = 130;
                dataGridView2.Columns["soluong"].Width = 130;
                dataGridView2.Columns["gia"].Width = 130;
            }
            else
            {
                MessageBox.Show("khách hàng mới được thêm vào chưa có dữ liệu");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtkh].AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                this.BindingContext[dtkh].RemoveAt(index);
            }
            else
            {
                MessageBox.Show("chọn một khách hàng");
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            kh.update(dtkh);
            MessageBox.Show("lưu thành công");
        }

    }
}
