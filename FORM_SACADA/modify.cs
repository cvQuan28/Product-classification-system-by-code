using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FORM_SACADA
{
    class modify
    {
        public modify()
        {
        }
        SqlCommand sqlCommand; // dung de truy van cac cau lenh insert, updrate, delete...
        SqlDataReader dataReader;//dung de doc du lieu trong bang

        public List<Taikhoan> Taikhoans(string query)// check tai khoan
        {
            List<Taikhoan> taikhoans = new List<Taikhoan>();
            using (SqlConnection sqlConnection = ConnectSQL.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    taikhoans.Add(new Taikhoan(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(5)));
                }

                sqlConnection.Close();
                
            }
            return taikhoans;
        }
        public void Command(string query) //dungf de dang ky tai khoan
        {
            using (SqlConnection sql = ConnectSQL.GetSqlConnection())
            {
                sql.Open();
                sqlCommand = new SqlCommand(query, sql);
                sqlCommand.ExecuteNonQuery();// thuc thi cau truy van
                sql.Close();


            }
        }
    }
}
