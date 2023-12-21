using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class hoadonncc
    {
        Database db;
        public hoadonncc()
        {
            db = new Database();
        }
        public DataTable layDanhSachHoaDon()
        {
            string strSql = "select * from hoadonnhacungcap";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layHoaDonNhaCungCap(int mancc)
        {
            string strSql = "select mahoadon, ngaytra, tientra from hoadonnhacungcap where manhacungcap=" + mancc;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layTienDaTra(int mancc)
        {
            string strSql = "select tientra from hoadonnhacungcap where manhacungcap=" + mancc;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public void themHoaDonNhaCungCap(DateTime ngaytra, float tientra, int manhacungcap)
        {
            string strSql = "insert into hoadonnhacungcap(ngaytra, tientra, manhacungcap) values (" + ngaytra + "," + tientra + "," + manhacungcap + ")";

            db.ExecuteNonQuery(strSql);
        }
        public void xoaHoaDonNhaCungCap(string mahoadon)
        {
            string strSql = "delete from hoadonnhacungcap where mahoadon=" + mahoadon;
            db.ExecuteNonQuery(strSql);
        }
        public void suaHoaDonKhachHang(string mahoadon, DateTime ngaytra, float tientra, int manhacungcap)
        {
            string strSql = "update hoadonnhacungcap set ngaytra=" + ngaytra + ",tientra=" + tientra + ",manhacungcap=" + manhacungcap + "where mahoadon=" + mahoadon;
            db.ExecuteNonQuery(strSql);
        }

        public void update(DataTable dt)
        {
            db.update(dt);
        }
    }
}
