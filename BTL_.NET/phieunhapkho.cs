using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class phieunhapkho
    {
        Database db;
        public phieunhapkho()
        {
            db = new Database();
        }
        public DataTable layDanhSachPhieuNhapKho()
        {
            string strSql = "select * from phieunhapkho";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layDanhSachPhieuNhapKhoQuanLyNhaCungCap(int id)
        {
            string strSql = "select mahanghoa, ngaynhap, soluong, gia from phieunhapkho where manhacungcap=" + id;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public void themPhieuNhapKho(int maphieu, DateTime ngaynhap, int soluong, float gia, string mahanghoa, string manhacungcap)
        {
            string strSql = "insert into phieunhapkho(maphieu, ngaynhap, soluong, gia, mahanghoa, manhacungcap) values (" + maphieu + "," + ngaynhap + "," + soluong + "," + gia + "," + mahanghoa + "," +manhacungcap+ ")";
            db.ExecuteNonQuery(strSql);
        }
        public void xoaPhieuNhapKho(int maphieu)
        {
            string strSql = "delete from phieunhapkho where maphieu=" + maphieu;
            db.ExecuteNonQuery(strSql);
        }
        public void suaPhieuNhapKho(int maphieu, DateTime ngaynhap, int soluong, float gia, string mahanghoa, string manhacungcap)
        {
            string strSql = "update phieunhapkho set ngaynhap=" + ngaynhap + ",soluong=" + soluong + ",gia=" + gia + ",mahanghoa=" + mahanghoa +",manhacungcap="+manhacungcap + "where maphieu=" + maphieu;
            db.ExecuteNonQuery(strSql);
        }

        public void update(DataTable dt)
        {
            db.update(dt);
        }

        
    }
}
