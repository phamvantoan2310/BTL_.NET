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
    public partial class cuasonguoidung : Form
    {
        DataTable dtnd;
        public cuasonguoidung(DataTable dt)
        {
            InitializeComponent();
            this.dtnd = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doimatkhau dmk = new doimatkhau(dtnd);
            dmk.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Index index = new Index();
            index.ShowDialog();
        }
    }
}
