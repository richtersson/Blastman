using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;    //*local DB

using System.Data;              //*ConnectionState, DataTable
using System.Threading.Tasks;

namespace Blastman
{
    public static class cldDB
    {
        private static string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = F:\OneDrive - map.sk\_Projekt Blastman\Nadstavba Visual Studio\PaintableAreaCSharp\Blastman.mdf; Integrated Security = True";

        public static SqlConnection Get_DB_Connection()

        {

            //--------< db_Get_Connection() >--------

            //< db oeffnen >

           

            SqlConnection cn_connection = new SqlConnection(ConnectionString);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            //</ db oeffnen >



            //< output >

            return cn_connection;

            //</ output >

            //--------</ db_Get_Connection() >--------

        }
        public static bool P_LOGIN(string UserName, string Password)
        {
            SqlConnection cn_connection;
            try
            {
                cn_connection=Get_DB_Connection();

            }
            catch
            {
                throw new  Exception("Problém s pripojením k databázi. Kontaktujte podporu.");
                
            }
            DataTable table = new DataTable();
            string query = "SELECT * FROM [tblUser] WHERE username='" + UserName + "' AND password='" + Password + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, cn_connection);
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                return true;
            }
            else
                throw new Exception("Nesprávne prihlasovacie meno alebo heslo"); 
        }



        public static DataTable Get_DataTable(string SQL_Text)

        {

            //--------< db_Get_DataTable() >--------

            SqlConnection cn_connection = Get_DB_Connection();



            //< get Table >

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);

            adapter.Fill(table);

            //</ get Table >



            //< output >

            return table;

            //</ output >

            //--------</ db_Get_DataTable() >--------

        }



        public static void Execute_SQL(string SQL_Text)

        {

            //--------< Execute_SQL() >--------

            SqlConnection cn_connection = Get_DB_Connection();



            //< get Table >

            SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);

            cmd_Command.ExecuteNonQuery();

            //</ get Table >



            //--------</ Execute_SQL() >--------

        }







        public static void Close_DB_Connection()

        {

            //--------< Close_DB_Connection() >--------

            //< db oeffnen >

            

            SqlConnection cn_connection = new SqlConnection(ConnectionString);

            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();

            //</ db oeffnen >



            //--------</ Close_DB_Connection() >--------

        }
    }
}
