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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_.NET
{
    public partial class doimatkhau : Form
    {
        nguoidung nd = new nguoidung();
        DataTable dtdn;
        DataTable dtnd;
        public doimatkhau(DataTable dt)
        {
            InitializeComponent();
            this.dtdn = dt;
        }

        private void doimatkhau_Load(object sender, EventArgs e)
        {
            dtnd = nd.layDanhSachNguoiDung();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataRow rowToUpdate = dtdn.Rows[0];
            object obj = dtdn.Rows[0]["matkhau"];
            string matkhau = obj.ToString();


            if (matkhau == textBox1.Text && textBox2.Text != "")
            {
                object obj2 = dtdn.Rows[0]["manguoidung"];
                int nguoidungid = int.Parse(obj2.ToString());

                foreach (DataRow row in dtnd.Rows)
                {
                    if (Convert.ToInt32(row["manguoidung"]) == nguoidungid)
                    {
                        row["matkhau"] = textBox2.Text;
                        break; // Khi tìm thấy và sửa xong, thoát khỏi vòng lặp
                    }
                }
                nd.update(dtnd);
                MessageBox.Show("đổi mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Kiểm tra lại mật khẩu hoặc mật khẩu mới");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
