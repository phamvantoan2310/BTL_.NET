using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class hoadonkhachhang
    {
        Database db;
        public hoadonkhachhang()
        {
            db = new Database();
        }
        public DataTable layDanhSachHoaDon()
        {
            string strSql = "select * from hoadonkhachhang";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layHoaDonKhachHang(int maKhachHang)
        {
            string strSql = "select mahoadon, ngaytra, tientra from hoadonkhachhang where makhachhang=" + maKhachHang;
            DataTable dt = db.Execute(strSql); 
            return dt;
        }
        public DataTable layTienDaTra(int maKhachHang)
        {
            string strSql = "select tientra from hoadonkhachhang where makhachhang=" + maKhachHang;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public void themHoaDonKhachHang(DateTime ngaytra, float tientra, int makhachhang)
        {
            string strSql = "insert into hoadonkhachhang(ngaytra, tientra, makhachhang) values ("+ ngaytra + "," + tientra + "," + makhachhang + ")";
           
            db.ExecuteNonQuery(strSql);
        }
        public void xoaHoaDonKhachHang(string mahoadon)
        {
            string strSql = "delete from hoadonkhachhang where mahoadon=" + mahoadon;
            db.ExecuteNonQuery(strSql);
        }
        public void suaHoaDonKhachHang(string mahoadon, DateTime ngaytra, float tientra, int makhachhang)
        {
            string strSql = "update hoadonkhachhang set ngaytra=" + ngaytra + ",tientra=" + tientra + ",makhachhang=" + makhachhang + "where mahoadon=" + mahoadon;
            db.ExecuteNonQuery(strSql);
        }

        public void update(DataTable dt)
        {
            db.update(dt);
        }
    }
}
