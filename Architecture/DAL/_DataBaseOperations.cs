using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{

    /// <summary>
    /// The DataBaseOperation class is to perform the operation on the database.
    /// It is abstract class and the class is inherited by all the class in the DAL in current project
    /// </summary>

  public  abstract class DataBaseOperations
    {

        SqlConnection sqlConnection;
        public SqlCommand sqlCommand;
        /// <summary>
        ///The methos is to create and open the database connaction 
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection DBConnection()
        {
            try
            {
                //to get the database connection string
                string connectionString = ConfigurationManager.ConnectionStrings["DB"].ToString();
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// The method is to close the database connection
        /// </summary>
        /// <returns>true/false</returns>
        private bool CloseDBConnection()
        {
            try
            {
                sqlConnection.Dispose();
                sqlConnection.Close();
                return true;
            }
            catch 
            {
                throw;
            }
        }
        /// <summary>
        /// The method will call the sql server to perform the database operation
        /// </summary>
        /// <param name="sqlCommand">the param usually has stroted procedure and the input variable</param>
        /// <returns>It retrurns the data table which is return by the query</returns>
        public DataTable ExtractData(SqlCommand sqlCommand)
        {
            try
            {
                sqlCommand.Connection = DBConnection();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);
                da.Dispose();
                sqlCommand.Dispose();
                CloseDBConnection();
                return dt;
            }
            catch
            {
                throw;
            }

        }

 
    }
}
