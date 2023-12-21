using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_.NET
{
    public partial class hoaDonkh : Form
    {
        hoadonkhachhang hdkh = new hoadonkhachhang();
        khachhang kh = new khachhang();
        DataTable dtkh;
        DataTable dthdtkh;
        DataTable dttiendatra;
        DataTable dthdkh;
        public hoaDonkh()
        {
            InitializeComponent();
        }

        private void hoaDonkh_Load(object sender, EventArgs e)
        {
            dtkh = kh.layDanhSachTenKhachHang();
            DataColumn khcolumn = dtkh.Columns["tenkhachhang"];
            foreach (DataRow row in dtkh.Rows)
            {
                comboBox1.Items.Add(row[khcolumn]);
                comboBox2.Items.Add(row[khcolumn]);
                comboBox3.Items.Add(row[khcolumn]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dthdkh = hdkh.layDanhSachHoaDon();
            float tientra = float.Parse(textBox2.Text);
            int index = comboBox1.SelectedIndex;
            object obj = dtkh.Rows[index]["makhachhang"];
            int khachhangid = int.Parse(obj.ToString());

            DataRow newRow = dthdkh.NewRow();

            // Gán giá trị từ TextBox vào các cột của DataRow
            newRow["ngaytra"] = dateTimePicker1.Text;
            newRow["tientra"] = textBox2.Text;
            newRow["makhachhang"] = khachhangid;

            // Thêm DataRow mới vào DataTable
            dthdkh.Rows.Add(newRow);
            hdkh.update(dthdkh);


            object obj2 = dtkh.Rows[index]["tienconno"];
            float tienconno = float.Parse(obj2.ToString());

            kh.suaTienConNoKhachHang(khachhangid, (tienconno - tientra));

            MessageBox.Show("viết hóa đơn thành công");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtkh = kh.layDanhSachTenKhachHang();

            int index = comboBox3.SelectedIndex;
            object obj = dtkh.Rows[index]["makhachhang"];
            int khachhangid = int.Parse(obj.ToString());
            dttiendatra = hdkh.layTienDaTra(khachhangid);

            float tongtiendatra = 0;
            foreach (DataRow dr in dttiendatra.Rows)
            {
                float tientra = float.Parse(dr["tientra"].ToString());
                tongtiendatra += tientra;
            }

            object obj2 = dtkh.Rows[index]["tienconno"];
            float tienconno = float.Parse(obj2.ToString());

            textBox1.Text = tongtiendatra.ToString();
            textBox3.Text = tienconno.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dtkh = kh.layDanhSachTenKhachHang();
            int index = comboBox2.SelectedIndex;
            object obj = dtkh.Rows[index]["makhachhang"];
            int khachhangid = int.Parse(obj.ToString());

            dthdtkh = hdkh.layHoaDonKhachHang(khachhangid);
            dataGridView1.DataSource = dthdtkh;
            dataGridView1.Columns["mahoadon"].Width = 160;
            dataGridView1.Columns["ngaytra"].Width = 160;
            dataGridView1.Columns["tientra"].Width = 160;


        }

    }
}
