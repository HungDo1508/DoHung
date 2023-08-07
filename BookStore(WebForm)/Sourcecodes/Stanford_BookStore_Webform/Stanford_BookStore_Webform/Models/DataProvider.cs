using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Khai báo thư viện để làm việc với db
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Security.AccessControl;

namespace Stanford_BookStore_Webform.Models
{
    public class DataProvider
    {
        /// <summary>
        /// Khai báo chuỗi kết nối cần làm việc
        /// </summary>
        private static string _ConnectString = "Server=DESKTOP-PFDHKRJ\\SQLEXPRESS; Database=A032301DEV; Integrated Security=True;";

        public static string ConnectString
        {
            get
            {
                return _ConnectString;
            }
        }

        /// <summary>
        /// Hàm lấy danh sách từ 1 câu lệnh truy vấn
        /// </summary>
        /// <param name="strSQL">Câu lệnh truy vấn</param>
        /// <param name="pars">Tham số nếu có</param>
        /// <returns>Danh sách lấy được từ câu lệnh</returns>
        public static DataTable LayDanhSach(string strSQL, SqlParameter[] pars=null, bool isProcedured = false)
        {
            //Khai báo biến
            DataTable dt = new DataTable();

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(ConnectString);

                //Mở kết nối
                conn.Open();

                //Khai báo công việc
                SqlCommand comm = new SqlCommand();

                comm.Connection = conn;
                if (isProcedured)
                {
                    comm.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    comm.CommandType = CommandType.Text;
                }
                comm.CommandText = strSQL;

                if(pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                //Khai báo 1 đối tượng để chứa kết quả
                SqlDataAdapter adapter = new SqlDataAdapter(comm);

                //Đổi dữ liệu
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        /// <summary>
        /// Hàm lấy thực hiện công việc insert, update, delete,...
        /// </summary>
        /// <param name="strSQL">Câu lệnh truy vấn</param>
        /// <param name="pars">Tham số nếu có</param>
        /// <returns>true nếu thực hành công, false nếu thất bại</returns>
        public static bool ThucHien(string strSQL, SqlParameter[] pars=null, bool isProcedured = false)
        {
            //Khai báo biến
            bool ketQua = false;

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(ConnectString);

                //Mở kết nối
                conn.Open();

                //Khai báo công việc
                SqlCommand comm = new SqlCommand();

                comm.Connection = conn;
                //Gọi thủ tục
                if (isProcedured)
                {
                    comm.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    comm.CommandType = CommandType.Text;
                }
                comm.CommandText = strSQL;

                if (pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                //Thực hiện công việc
                ketQua = (comm.ExecuteNonQuery() > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return ketQua;
        }

        private static BookBusiness _BookBus = null;

        /// <summary>
        /// Khai báo 1 thuộc tính trả về 1 đối tượng thuộc lớp BookBusiness
        /// </summary>
        public static BookBusiness BookBus
        {
            get//read
            {
                if(_BookBus == null)
                {
                    _BookBus = new BookBusiness();
                }

                return _BookBus;
            }
        }
    }
}