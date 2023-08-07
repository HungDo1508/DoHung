using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Stanford_QLSinhVien_CS0922
{
    public class DataProvider
    {
        private const string _ConnectString = @"Server=DESKTOP-PFDHKRJ\SQLEXPRESS; Database=CS092201CB; Integrated Security = true;";

        /// <summary>
        /// Khai báo 1 chuỗi kết nối đến db cần làm việc
        /// </summary>
        public static string ConnectString
        {
            get
            {
                return _ConnectString;
            }
        }

        /// <summary>
        /// Hàm lấy thông tin từ 1 câu lệnh SQL
        /// </summary>
        /// <param name="strSQL">Câu lệnh SQL cần lấy thông tin</param>
        /// <returns>Bảng dữ liệu lấy được từ database</returns>
        public static DataTable LayDanhSach(string strSQL)
        {
            //Khai báo 1 đối tượng để chứa dữ liệu trả về
            DataTable dt = new DataTable();

            //Khai báo 1 đối tượng kết nối
            SqlConnection conn = new SqlConnection(ConnectString);
            try
            {
                //Mở kết nối đến db cần làm việc
                conn.Open();

                //Khai báo 1 công việc
                SqlCommand comm = new SqlCommand();

                //Thực hiện trên kết nối nào
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSQL;

                //Khai báo 1 đối tượng để chứa dữ liệu lấy đc
                SqlDataAdapter adapter = new SqlDataAdapter(comm);

                //Đổ dữ liệu vào bảng
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Đóng kết nối
                conn.Close();
            }

            return dt;
        }


        /// <summary>
        /// Hàm thực hiện công việc
        /// </summary>
        /// <param name="strSQL">Câu lệnh như insert, update, delete,...</param>
        /// <param name="pars">Tham số của câu lệnh nếu có</param>
        /// <returns>True nếu thực hiện thành công, false nếu thất bại</returns>
        public static bool ThucHien(string strSQL, SqlParameter[] pars)
        {
            //Khai báo 1 đối tượng trả về kết quả
            bool isKetQua = false;

            //Khai báo 1 đối tượng kết nối
            SqlConnection conn = new SqlConnection(ConnectString);
            try
            {
                //Mở kết nối đến db cần làm việc
                conn.Open();

                //Khai báo 1 công việc
                SqlCommand comm = new SqlCommand();

                //Thực hiện trên kết nối nào
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSQL;

                if(pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }    
                //Thực hiện công việc insert, update, delete,...
                isKetQua = comm.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Đóng kết nối
                conn.Close();
            }

            return isKetQua;
        }

        /// <summary>
        /// Khai báo 1 thuộc tính ở dạng static để có thể truy xuất từ nhiều nơi để làm việc với các thành phần trong đối tượng thuộc lớp SinhVienBusiness
        /// </summary>
        private static SinhVienBusiness _sinhVienBus = null;

        public static SinhVienBusiness SinhVienBus
        {
            get
            {
                if(_sinhVienBus == null)
                {
                    _sinhVienBus = new SinhVienBusiness();//Singletone
                }

                return _sinhVienBus;
            }
        }
    }
}
