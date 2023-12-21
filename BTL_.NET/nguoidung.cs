using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class nguoidung
    {
        Database db;
        public nguoidung()
        {
            db = new Database();
        }
        public DataTable layNguoiDung(string tendn)
        {
            string strSql = "select * from nguoidung where tendangnhap='" + tendn+"'";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layDanhSachNguoiDung()
        {
            string strSql = "select * from nguoidung";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public void update(DataTable dt)
        {
            db.update(dt);
        }
    }
}
