using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_.NET
{
    class hanghoa
    {
        Database db;
        public hanghoa()
        {
            db = new Database();
        }
        public DataTable layDanhSachHangHoa()
        {
            string strSql = "select * from hanghoa";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layDanhSachHangHoaConTon()
        {
            string strSql = "select tenhanghoa, soluong from hanghoa";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layDanhSachTenHangHoa()
        {
            string strSql = "select mahanghoa, tenhanghoa from hanghoa";
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public DataTable layHangHoa(int id)
        {
            string strSql = "select * from hanghoa where mahanghoa=" + id;
            DataTable dt = db.Execute(strSql);
            return dt;
        }
        public void themHangHoa(int mahanghoa, string tenhanghoa, float gia, int soluong)
        {
            string strSql = "insert into hanghoa(mahanghoa, tenhanghoa, gia, soluong) values (" + mahanghoa + "," + tenhanghoa + "," + gia + "," + soluong + ")";
            db.ExecuteNonQuery(strSql);
        }
        public void xoaHangHoa(int mahanghoa)
        {
            string strSql = "delete from hanghoa where mahanghoa=" + mahanghoa;
            db.ExecuteNonQuery(strSql);
        }
        public void suaHangHoa(int mahanghoa, string tenhanghoa, float gia, int soluong)
        {
            string strSql = "update hanghoa set tenhanghoa=" + tenhanghoa +",gia=" + gia + ",soluong=" + soluong +"where mahanghoa=" + mahanghoa;
            db.ExecuteNonQuery(strSql);
        }
        public void suaSoLuongHangHoa(int mahanghoa, int soluong)
        {
            string strSql = "update hanghoa set soluong=" + soluong + "where mahanghoa=" + mahanghoa;
            db.ExecuteNonQuery(strSql);
        }

        public void update(DataTable dt)
        {
            db.update(dt);
        }

    }
}
