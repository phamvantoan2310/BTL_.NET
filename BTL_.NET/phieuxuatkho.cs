using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class phieuxuatkho
    {
        Database db;
        public phieuxuatkho()
        {
            db = new Database();
        }
        public DataTable layDanhSachPhieuXuatKho()
        {
            string strSql = "select * from phieuxuatkho";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layDanhSachPhieuXuatKhoQuanLyKhachHang(int id)
        {
            string strSql = "select mahanghoa, ngayxuat, soluong, gia from phieuxuatkho where makhachhang=" + id;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public void themPhieuXuatKho(int maphieu, DateTime ngayxuat, int soluong, float gia, string mahanghoa, string makhachhang)
        {
            string strSql = "insert into phieuxuatkho(maphieu, ngayxuat, soluong, gia, mahanghoa, makhachhang) values (" + maphieu + "," + ngayxuat + "," + soluong + "," + gia + "," + mahanghoa + "," + makhachhang + ")";
            db.ExecuteNonQuery(strSql);
        }
        public void xoaPhieuXuatKho(int maphieu)
        {
            string strSql = "delete from phieuxuatkho where maphieu=" + maphieu;
            db.ExecuteNonQuery(strSql);
        }
        public void suaPhieuXuatKho(int maphieu, DateTime ngayxuat, int soluong, float gia, string mahanghoa, string makhachhang)
        {
            string strSql = "update phieuxuatkho set ngayxuat=" + ngayxuat + ",soluong=" + soluong + ",gia=" + gia + ",mahanghoa=" + mahanghoa + ",makhachhang=" + makhachhang + "where maphieu=" + maphieu;
            db.ExecuteNonQuery(strSql);
        }
        public void update(DataTable dt)
        {
            db.update(dt);
        }
    }
}
