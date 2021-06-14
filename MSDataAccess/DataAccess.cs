using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSDataAccess
{
    public class DataAccess<T>
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CommandType CommandType { get; set; }

        public string CommandText { get; set; }

        public List<SqlParameter> Params { get; set; } = new List<SqlParameter>();
        
        public T GetScalar { 
            get
            {
                using SqlConnection cn = new SqlConnection(_connectionString);

                using SqlCommand cmd = new SqlCommand
                {
                Connection = cn,
                CommandType = this.CommandType,
                CommandText = this.CommandText
                };

                try
                {
                    cn.Open();
                    var result = cmd.ExecuteScalar();
                    return (T)result;
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public List<Object> GetList_DataReader()
        {
            List<Object> rows = new List<object>();

            using SqlConnection cn = new SqlConnection(_connectionString);

            using SqlCommand cmd = new SqlCommand
            {
                Connection = cn,
                CommandType = this.CommandType,
                CommandText = this.CommandText
            };

            try
            {
                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<object> cols = new List<object>();

                    foreach (var item in reader.GetColumnSchema())
                    {
                        cols.Add(reader[item.ColumnName]);
                    }
                  
                    rows.Add(cols);
                }

                reader.Close();

                return rows;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DataSet GetCollection_DataAdapter()
        {
            DataSet ds = new DataSet();

            using SqlConnection cn = new SqlConnection(_connectionString);

            using SqlCommand cmd = new SqlCommand(this.CommandText, cn);

            using SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                cn.Open();

                var result = da.Fill(ds);

                return ds;
                
            }
            catch (SqlException)
            {

                throw;
            }
        }

        public int NonQuery()
        {
            using SqlConnection cn = new SqlConnection(_connectionString);

            using SqlCommand cmd = new SqlCommand
            {
                Connection = cn,
                CommandType = this.CommandType,
                CommandText = this.CommandText
            };

            foreach (var param in Params)
            {
                cmd.Parameters.Add(param);
            }

            try
            {
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
