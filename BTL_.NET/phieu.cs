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
    public partial class phieu : Form
    {
        phieunhapkho pnk = new phieunhapkho();
        phieuxuatkho pxk = new phieuxuatkho();
        hanghoa hh = new hanghoa();
        nhacungcap ncc = new nhacungcap();
        khachhang kh = new khachhang();
        DataTable dtpnk;
        DataTable dtpxk;
        DataTable dthh;
        DataTable dtncc;
        DataTable dtkh;

        public void buocCacDieuKien()
        {
            dtpnk = pnk.layDanhSachPhieuNhapKho();
            dthh = hh.layDanhSachTenHangHoa();
            dtncc = ncc.layDanhSachTenNhaCungCap();
            dataGridView1.DataSource = dtpnk;
            DataColumn hhcolumn = dthh.Columns["tenhanghoa"];
            foreach (DataRow row in dthh.Rows)
            {
                comboBox1.Items.Add(row[hhcolumn]);
            }
            DataColumn ncccolumn = dtncc.Columns["tennhacungcap"];
            foreach (DataRow row in dtncc.Rows)
            {
                comboBox2.Items.Add(row[ncccolumn]);
            }


            dtpxk = pxk.layDanhSachPhieuXuatKho();
            dtkh = kh.layDanhSachTenKhachHang();
            dataGridView2.DataSource = dtpxk;
            foreach (DataRow row in dthh.Rows)
            {
                comboBox3.Items.Add(row[hhcolumn]);
            }
            DataColumn khcolumn = dtkh.Columns["tenkhachhang"];
            foreach (DataRow row in dtkh.Rows)
            {
                comboBox4.Items.Add(row[khcolumn]);
            }
        }
        public phieu()
        {
            InitializeComponent();
        }
        private void phieu_Load(object sender, EventArgs e)
        {
            buocCacDieuKien();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //lấy mã hàng hóa theo chỉ mục của datatable
            int index = comboBox1.SelectedIndex;
            object obj = dthh.Rows[index]["mahanghoa"];
            string strobj = obj.ToString();
            int hanghoaid = int.Parse(strobj);

            int index2 = comboBox2.SelectedIndex;
            object obj2 = dtncc.Rows[index2]["manhacungcap"];
            string strobj2 = obj2.ToString();
            int nhacungcapid = int.Parse(strobj2);


            DataRow newRow = dtpnk.NewRow();

            newRow["mahanghoa"] = hanghoaid;
            newRow["ngaynhap"] = dateTimePicker1.Text;
            newRow["gia"] = textBox2.Text;
            newRow["soluong"] = textBox3.Text;
            newRow["manhacungcap"] = nhacungcapid;

            //update số lượng
            DataTable dt1 = hh.layHangHoa(hanghoaid);
            object obj3 = dt1.Rows[0]["soluong"];
            string strobj3 = obj3.ToString();
            int soluong = int.Parse(strobj3);

            soluong += int.Parse(textBox3.Text);
            hh.suaSoLuongHangHoa(hanghoaid, soluong);

            //update tiền còn nợ
            DataTable dt2 = ncc.layNhaCungCap(nhacungcapid);
            object obj4 = dt2.Rows[0]["tienconno"];
            float tienconno = float.Parse(obj4.ToString());

            tienconno += float.Parse(textBox2.Text);
            ncc.suaTienConNoNhaCungCap(nhacungcapid, tienconno);
            dtpnk.Rows.Add(newRow);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                //update số lượng
                object obj1 = row.Cells["mahanghoa"].Value;
                int hanghoaid = int.Parse(obj1.ToString());
                object obj2 = row.Cells["soluong"].Value;
                int soluongdathem = int.Parse(obj2.ToString());

                DataTable dt1 = hh.layHangHoa(hanghoaid);
                object obj3 = dt1.Rows[0]["soluong"];
                int soluong = int.Parse(obj3.ToString());
                soluong -= soluongdathem;

                hh.suaSoLuongHangHoa(hanghoaid, soluong);
                //update tiền còn nợ
                object obj4 = row.Cells["manhacungcap"].Value;
                int nhacungcapid = int.Parse(obj4.ToString());
                object obj5 = row.Cells["gia"].Value;
                int tienconnodatang = int.Parse(obj5.ToString());

                DataTable dt2 = ncc.layNhaCungCap(nhacungcapid);
                object obj6 = dt2.Rows[0]["tienconno"];
                float tienconno = float.Parse(obj6.ToString());

                tienconno -= tienconnodatang;

                ncc.suaTienConNoNhaCungCap(nhacungcapid, tienconno);

                this.BindingContext[dtpnk].RemoveAt(rowIndex);

            }
            else
            {
                MessageBox.Show("chọn một phiếu");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            


            pnk.update(dtpnk);
            MessageBox.Show("lưu thành công");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //lấy mã hàng hóa theo chỉ mục của datatable
            int index = comboBox3.SelectedIndex;
            object obj = dthh.Rows[index]["mahanghoa"];
            string strobj = obj.ToString();
            int hanghoaid = int.Parse(strobj);

            int index2 = comboBox4.SelectedIndex;
            object obj2 = dtkh.Rows[index2]["makhachhang"];
            string strobj2 = obj2.ToString();
            int khachhangid = int.Parse(strobj2);


            DataRow newRow = dtpxk.NewRow();

            newRow["mahanghoa"] = hanghoaid;
            newRow["ngayxuat"] = dateTimePicker2.Text;
            newRow["gia"] = textBox4.Text;
            newRow["soluong"] = textBox1.Text;
            newRow["makhachhang"] = khachhangid;

            //update số lượng
            DataTable dt1 = hh.layHangHoa(hanghoaid);
            object obj3 = dt1.Rows[0]["soluong"];
            string strobj3 = obj3.ToString();
            int soluong = int.Parse(strobj3);
            int soluongbot = int.Parse(textBox1.Text);

            soluong -= soluongbot;
            hh.suaSoLuongHangHoa(hanghoaid, soluong);

            //update tiền còn nợ
            DataTable dt2 = kh.layKhachHang(khachhangid);
            object obj4 = dt2.Rows[0]["tienconno"];
            float tienconno = float.Parse(obj4.ToString());
            tienconno += float.Parse(textBox4.Text);

            kh.suaTienConNoKhachHang(khachhangid, tienconno);
            dtpxk.Rows.Add(newRow);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView2.SelectedRows[0].Index;
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                //update số lượng
                object obj1 = row.Cells["mahanghoa"].Value;
                int hanghoaid = int.Parse(obj1.ToString());
                object obj2 = row.Cells["soluong"].Value;
                int soluongdathem = int.Parse(obj2.ToString());

                DataTable dt1 = hh.layHangHoa(hanghoaid);
                object obj3 = dt1.Rows[0]["soluong"];
                int soluong = int.Parse(obj3.ToString());
                soluong += soluongdathem;

                hh.suaSoLuongHangHoa(hanghoaid, soluong);

                //update tiền còn nợ
                object obj4 = row.Cells["makhachhang"].Value;
                int khachhangid = int.Parse(obj4.ToString());
                DataTable dt2 = kh.layKhachHang(khachhangid);
                object obj5 = dt2.Rows[0]["tienconno"];
                float tienconno = float.Parse(obj5.ToString());

                object obj6 = row.Cells["gia"].Value;
                float tienconnotangthem = float.Parse(obj6.ToString());
                tienconno -= tienconnotangthem;

                kh.suaTienConNoKhachHang(khachhangid, tienconno);

                this.BindingContext[dtpxk].RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("chọn một phiếu");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pxk.update(dtpxk);
            MessageBox.Show("lưu thành công");
        }
    }
}
