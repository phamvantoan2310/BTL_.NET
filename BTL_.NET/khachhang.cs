using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class khachhang
    {
        Database db;
        public khachhang()
        {
            db = new Database();
        }
        public DataTable layDanhSachKhachHang()
        {
            string strSql = "select * from khachhang";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layKhachHang(int id)
        {
            string strSql = "select * from khachhang where makhachhang=" + id;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layDanhSachTenKhachHang()
        {
            string strSql = "select makhachhang, tenkhachhang, tienconno from khachhang";
            DataTable dt = db.Execute(strSql);
            return dt;
        }

        public void themKhachHang(int makhachhang, string tenkhachhang, string diachi, string email, float tienconno)
        {
            string strSql = "insert into khachhang(makhachhang, tenkhachhang, diachi, email, tienconno) values (" + makhachhang + "," + tenkhachhang + "," + diachi + "," + email + ","+tienconno+")";
            db.ExecuteNonQuery(strSql);
        }
        public void xoaKhachHang(int makhachhang)
        {
            string strSql = "delete from khachhang where makhachhang=" + makhachhang;
            db.ExecuteNonQuery(strSql);
        }
        public void suaKhachHang(int makhachhang, string tenkhachhang, string diachi, string email, float tienconno)
        {
            string strSql = "update khachhang set tenkhachhang=" + tenkhachhang + ",diachi=" + diachi + ",email=" + email +",tienconno=" + tienconno + "where makhachhang=" + makhachhang;
            db.ExecuteNonQuery(strSql);
        }
        public void suaTienConNoKhachHang(int makhachhang,float tienconno)
        {
            string strSql = "update khachhang set tienconno=" + tienconno + "where makhachhang=" + makhachhang;
            db.ExecuteNonQuery(strSql);
        }
        public void update(DataTable dt)
        {
            db.update(dt);
        }
    }
}
