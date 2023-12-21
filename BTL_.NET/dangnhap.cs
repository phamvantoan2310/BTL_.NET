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
    public partial class dangnhap : Form
    {
        nguoidung nguoidung = new nguoidung();
        DataTable dt;
        public dangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = nguoidung.layNguoiDung(textBox1.Text);
            if(dt.Rows.Count > 0 )
            {
                object obj = dt.Rows[0]["matkhau"];
                string matkhau = obj.ToString();
                if (matkhau == textBox2.Text)
                {
                    cuasonguoidung csnd = new cuasonguoidung(dt);
                    csnd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nhập sai mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Nhập sai tên đăng nhập!");
            }
        }
    }
}
