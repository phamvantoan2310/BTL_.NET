using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class nhacungcap
    {
        Database db;
        public nhacungcap()
        {
            db = new Database();
        }
        public DataTable layDanhSachNhaCungCap()
        {
            string strSql = "select * from nhacungcap";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layNhaCungCap(int id)
        {
            string strSql = "select * from nhacungcap where manhacungcap=" + id;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layDanhSachTenNhaCungCap()
        {
            string strSql = "select manhacungcap, tennhacungcap, tienconno from nhacungcap";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public void themNhaCungCap(int manhacungcap, string tennhacungcap, string diachi, string email, float tienconno)
        {
            string strSql = "insert into nhacungcap(manhacungcap, tennhacungcap, diachi, email, tienconno) values (" + manhacungcap + "," + tennhacungcap + "," + diachi + "," + email + "," + tienconno + ")";
            db.ExecuteNonQuery(strSql);
        }
        public void xoaNhaCungCap(int manhacungcap)
        {
            string strSql = "delete from nhacungcap where manhacungcap=" + manhacungcap;
            db.ExecuteNonQuery(strSql);
        }
        public void suaNhaCungCap(int manhacungcap, string tennhacungcap, string diachi, string email, float tienconno)
        {
            string strSql = "update nhacungcap set tennhacungcap=" + tennhacungcap + ",diachi=" + diachi + ",email=" + email + ",tienconno=" + tienconno + "where manhacungcap=" + manhacungcap;
            db.ExecuteNonQuery(strSql);
        }
        public void suaTienConNoNhaCungCap(int manhacungcap,float tienconno)
        {
            string strSql = "update nhacungcap set tienconno=" + tienconno + "where manhacungcap=" + manhacungcap;
            db.ExecuteNonQuery(strSql);
        }
        public void update(DataTable dt)
        {
            db.update(dt);
        }
    }
}
