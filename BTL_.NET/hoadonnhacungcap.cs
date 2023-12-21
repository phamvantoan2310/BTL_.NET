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
    public partial class hoadonnhacungcap : Form
    {
        hoadonncc hdncc = new hoadonncc();
        nhacungcap ncc = new nhacungcap();
        DataTable dthdtncc;
        DataTable dthdncc;
        DataTable dtncc;
        DataTable dttiendatra;
        public hoadonnhacungcap()
        {
            InitializeComponent();
        }

        private void hoadonnhacungcap_Load(object sender, EventArgs e)
        {

            dtncc = ncc.layDanhSachTenNhaCungCap();
            DataColumn ncccolumn = dtncc.Columns["tennhacungcap"];
            foreach (DataRow row in dtncc.Rows)
            {
                comboBox1.Items.Add(row[ncccolumn]);
                comboBox2.Items.Add(row[ncccolumn]);
                comboBox3.Items.Add(row[ncccolumn]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dthdncc = hdncc.layDanhSachHoaDon();
            float tientra = float.Parse(textBox2.Text);
            int index = comboBox1.SelectedIndex;
            object obj = dtncc.Rows[index]["manhacungcap"];
            int nhacungcapid = int.Parse(obj.ToString());

            DataRow newRow = dthdncc.NewRow();

            // Gán giá trị từ TextBox vào các cột của DataRow
            newRow["ngaytra"] = dateTimePicker1.Text;
            newRow["tientra"] = textBox2.Text;
            newRow["manhacungcap"] = nhacungcapid;

            // Thêm DataRow mới vào DataTable
            dthdncc.Rows.Add(newRow);
            hdncc.update(dthdncc);


            object obj2 = dtncc.Rows[index]["tienconno"];
            float tienconno = float.Parse(obj2.ToString());

            ncc.suaTienConNoNhaCungCap(nhacungcapid, (tienconno-tientra));

            MessageBox.Show("viết hóa đơn thành công");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtncc = ncc.layDanhSachTenNhaCungCap();

            int index = comboBox3.SelectedIndex;
            object obj = dtncc.Rows[index]["manhacungcap"];
            int nhacungcapid = int.Parse(obj.ToString());
            dttiendatra = hdncc.layTienDaTra(nhacungcapid);

            float tongtiendatra = 0;
            foreach (DataRow dr in dttiendatra.Rows)
            {
                float tientra = float.Parse(dr["tientra"].ToString());
                tongtiendatra += tientra;
            }

            object obj2 = dtncc.Rows[index]["tienconno"];
            float tienconno = float.Parse(obj2.ToString());

            textBox1.Text = tongtiendatra.ToString();
            textBox3.Text = tienconno.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dtncc = ncc.layDanhSachTenNhaCungCap();
            int index = comboBox2.SelectedIndex;
            object obj = dtncc.Rows[index]["manhacungcap"];
            int nhacungcapid = int.Parse(obj.ToString());

            dthdtncc = hdncc.layHoaDonNhaCungCap(nhacungcapid);
            dataGridView1.DataSource = dthdtncc;
            dataGridView1.Columns["mahoadon"].Width = 160;
            dataGridView1.Columns["ngaytra"].Width = 160;
            dataGridView1.Columns["tientra"].Width = 160;
        }
    }
}
