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
    public partial class quanlynhacungcap : Form
    {
        nhacungcap ncc = new nhacungcap();
        phieunhapkho pnk = new phieunhapkho();
        DataTable dtncc;
        DataTable dtpnk;
        public quanlynhacungcap()
        {
            InitializeComponent();
        }

        public void buocCacDieuKien()
        {
            dtncc = ncc.layDanhSachNhaCungCap();
            dataGridView1.DataSource = dtncc;

            textBox1.DataBindings.Add("text", dtncc, "tennhacungcap");
            textBox2.DataBindings.Add("text", dtncc, "diachi");
            textBox3.DataBindings.Add("text", dtncc, "email");
            textBox4.DataBindings.Add("text", dtncc, "tienconno");
            textBox8.DataBindings.Add("text", dtncc, "tennhacungcap");

            dataGridView1.Columns["manhacungcap"].Width = 130;
            dataGridView1.Columns["tennhacungcap"].Width = 130;
            dataGridView1.Columns["diachi"].Width = 130;
            dataGridView1.Columns["email"].Width = 130;
            dataGridView1.Columns["tienconno"].Width = 130;
        }

        private void quanlynhacungcap_Load(object sender, EventArgs e)
        {
            buocCacDieuKien(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow row = dataGridView1.Rows[index];
            object obj = row.Cells["manhacungcap"].Value;

            if (obj != null)
            {
                int nhacungcapid = int.Parse(obj.ToString());
                dtpnk = pnk.layDanhSachPhieuNhapKhoQuanLyNhaCungCap(nhacungcapid);
                dataGridView2.DataSource = dtpnk;
                dataGridView2.Columns["mahanghoa"].Width = 130;
                dataGridView2.Columns["ngaynhap"].Width = 130;
                dataGridView2.Columns["soluong"].Width = 130;
                dataGridView2.Columns["gia"].Width = 130;
            }
            else
            {
                MessageBox.Show("nhà cung cấp mới được thêm vào chưa có dữ liệu");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtncc].AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                this.BindingContext[dtncc].RemoveAt(index);
            }
            else
            {
                MessageBox.Show("chọn một nhà cung cấp");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ncc.update(dtncc);
            MessageBox.Show("lưu thành công");
        }
    }
}
