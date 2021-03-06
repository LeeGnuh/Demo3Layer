using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SanPhamDAL : DataAccessDAL
    {
        List<SanPham> DSSP = new List<SanPham>();
        public List<SanPham> getAllSP()
        {
           openConn();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            command.CommandText = "select * from SanPham";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SanPham sp = new SanPham();

                sp.MaSP = reader.GetInt32(0);
                sp.TenSP = reader.GetString(1);
                sp.GiaSP = reader.GetInt32(2);
                sp.MaDM = reader.GetInt32(3);

                DSSP.Add(sp);
            }
            reader.Close();
            return DSSP;
        }

        public List<SanPham> select_MaDM(int maDM)
        {
            List<SanPham> list = new List<SanPham>();
            openConn();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            command.CommandText = "select * from SanPham where MaDM = @maDM";
            command.Connection = conn;

            command.Parameters.Add("@maDM", SqlDbType.Int).Value = maDM;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SanPham sp = new SanPham();

                sp.MaSP = reader.GetInt32(0);
                sp.TenSP = reader.GetString(1);
                sp.GiaSP = reader.GetInt32(2);
                sp.MaDM = reader.GetInt32(3);

                list.Add(sp);
            }
            reader.Close();
            return list;
        }

        public bool deleteAt(int maSP)
        {
            openConn();

            SqlCommand commnand = new SqlCommand();
            commnand.CommandType = CommandType.Text;

            commnand.CommandText = "delete from SanPham where MaSP = @maSP";
            commnand.Connection = conn;

            commnand.Parameters.Add("@maSP", SqlDbType.Int).Value = maSP;

            int kq = commnand.ExecuteNonQuery();

            return kq > 0;
        }

        public bool deleteAtDM(int maDM)
        {
            openConn();

            SqlCommand commnand = new SqlCommand();
            commnand.CommandType = CommandType.Text;

            commnand.CommandText = "delete from SanPham where MaDM = @maDM";
            commnand.Connection = conn;

            commnand.Parameters.Add("@maDM", SqlDbType.Int).Value = maDM;

            int kq = commnand.ExecuteNonQuery();

            return kq > 0;
        }

        public bool addSP_Object(SanPham sp)
        {
            openConn();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            command.CommandText = " insert into SanPham Values(@ma, @ten,@gia,@mdm)";
            command.Connection = conn;

            command.Parameters.Add("@ma", SqlDbType.Int).Value = sp.MaSP;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = sp.TenSP;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = sp.GiaSP;
            command.Parameters.Add("@mdm", SqlDbType.Int).Value = sp.MaDM;

            int kq = command.ExecuteNonQuery();

            return kq > 0;

        }
        public bool changeSP_At_Object(SanPham sp, int id)
        {
            openConn();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            command.CommandText = "UPDATE SanPham SET TenSP = @ten, GiaSP = @gia, MaDM = @mdm WHERE MaSP = @id;";
            command.Connection = conn;

            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = sp.TenSP;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = sp.GiaSP;
            command.Parameters.Add("@mdm", SqlDbType.Int).Value = sp.MaDM;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            int kq = command.ExecuteNonQuery();

            return kq > 0;
        }
    }
}