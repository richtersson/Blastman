using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;    //*local DB

using System.Data;              //*ConnectionState, DataTable
using System.Threading.Tasks;
using System.Windows;

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
                throw new Exception("Nesprávne prihlasovacie údaje."); 
        }

        public static void P_PROGRAM_INSERT(string ProgramName)
        {
            SqlConnection cn_connection;
            try
            {
                cn_connection = Get_DB_Connection();

            }
            catch
            {
                throw new Exception("Problém s pripojením k databázi. Kontaktujte podporu.");

            }

            SqlCommand cmd_Command = cn_connection.CreateCommand();
            cmd_Command.CommandType = CommandType.StoredProcedure;
            cmd_Command.CommandText = ("P_PROGRAM_INS");
            cmd_Command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = ProgramName;
            cmd_Command.Parameters.Add("@P_SQLCODE", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            cmd_Command.Parameters.Add("@P_SQLERRM", SqlDbType.NVarChar,500).Direction = System.Data.ParameterDirection.Output;


            try
            {
                cmd_Command.ExecuteNonQuery();
                if (cmd_Command.Parameters["@P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                cn_connection.Close();
            }


            

        }
        public static void P_PROGRAM_UPDATE(string programname, string author, string description)
        {
            SqlConnection cn_connection;
            try
            {
                cn_connection = Get_DB_Connection();

            }
            catch
            {
                throw new Exception("Problém s pripojením k databázi. Kontaktujte podporu.");

            }

            SqlCommand cmd_Command = cn_connection.CreateCommand();
            cmd_Command.CommandType = CommandType.StoredProcedure;
            cmd_Command.CommandText = ("P_PROGRAM_UPDATE");
            cmd_Command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = programname;
            cmd_Command.Parameters.Add("@author", SqlDbType.NVarChar, 50).Value = author;
            cmd_Command.Parameters.Add("@programDesc", SqlDbType.NVarChar, 50).Value = (object)description ?? DBNull.Value; ;
            
            cmd_Command.Parameters.Add("@P_SQLCODE", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            cmd_Command.Parameters.Add("@P_SQLERRM", SqlDbType.NVarChar, 500).Direction = System.Data.ParameterDirection.Output;


            try
            {
                cmd_Command.ExecuteNonQuery();
                if (cmd_Command.Parameters["@P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                cn_connection.Close();
            }
        }
        public static void P_VYMAZANIEDATPROGRAMU(string ProgramName)
        {
            SqlConnection cn_connection;
            try
            {
                cn_connection = Get_DB_Connection();

            }
            catch
            {
                throw new Exception("Problém s pripojením k databázi. Kontaktujte podporu.");

            }

            SqlCommand cmd_Command = cn_connection.CreateCommand();
            cmd_Command.CommandType = CommandType.StoredProcedure;
            cmd_Command.CommandText = ("P_VYMAZANIEDATPROGRAMU");
            cmd_Command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = ProgramName;
            cmd_Command.Parameters.Add("@P_SQLCODE", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            cmd_Command.Parameters.Add("@P_SQLERRM", SqlDbType.NVarChar, 500).Direction = System.Data.ParameterDirection.Output;


            try
            {
                cmd_Command.ExecuteNonQuery();
                if (cmd_Command.Parameters["@P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                cn_connection.Close();
            }




        }
        public static void P_NEUPLNYPROGRAM_DEL (string ProgramName)
        {
            SqlConnection cn_connection;
            try
            {
                cn_connection = Get_DB_Connection();

            }
            catch
            {
                throw new Exception("Problém s pripojením k databázi. Kontaktujte podporu.");

            }

            SqlCommand cmd_Command = cn_connection.CreateCommand();
            cmd_Command.CommandType = CommandType.StoredProcedure;
            cmd_Command.CommandText = ("P_NEUPLNYPROGRAM_DEL");
            cmd_Command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = ProgramName;
            cmd_Command.Parameters.Add("@P_SQLCODE", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            cmd_Command.Parameters.Add("@P_SQLERRM", SqlDbType.NVarChar, 500).Direction = System.Data.ParameterDirection.Output;


            try
            {
                cmd_Command.ExecuteNonQuery();
                if (cmd_Command.Parameters["@P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                cn_connection.Close();
            }




        }
        public static DataTable P_PROGRAMYNEEXPORTOVANE()
        {
            SqlConnection cn_connection;
            try
            {
                cn_connection = Get_DB_Connection();

            }
            catch
            {
                throw new Exception("Problém s pripojením k databázi. Kontaktujte podporu.");

            }

            SqlCommand cmd_Command = cn_connection.CreateCommand();
            cmd_Command.CommandType = CommandType.StoredProcedure;
            cmd_Command.CommandText = ("P_PROGRAMYNEEXPORTOVANE");
           
           

            DataTable dt = new DataTable();
            try
            {

               SqlDataReader rdr= cmd_Command.ExecuteReader();
                dt.Load(rdr);
                return dt;

                
            }
            catch (Exception exp)
            {
                MessageBox.Show("Problém s pripojením na databázu. Kontaktuje svojho administrátora.");
                return null;
            }
            finally
            {
                cn_connection.Close();
            }




        }
        public static void P_POSITION_INS(string programname, int positionnumber, string time_or_axle, string joint_speed, string blasting_state, string swing_axle, string swing_angle, string swing_speed, double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8)
        {
            SqlConnection cn_connection;
            try
            {
                cn_connection = Get_DB_Connection();

            }
            catch
            {
                throw new Exception("Problém s pripojením k databázi. Kontaktujte podporu.");

            }
           // VALUES(@name, @positionNumber, @swing_angle, @swing_axle, @swing_speed, @time_or_axle, @blasting_state, @joint_speed, @P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8)
            SqlCommand cmd_Command = cn_connection.CreateCommand();
            cmd_Command.CommandType = CommandType.StoredProcedure;
            cmd_Command.CommandText = ("P_POSITION_INS");
            cmd_Command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = programname;
            cmd_Command.Parameters.Add("@positionNumber", SqlDbType.Int).Value = positionnumber;
            cmd_Command.Parameters.Add("@swing_angle", SqlDbType.NVarChar, 10).Value = swing_axle;
            cmd_Command.Parameters.Add("@swing_axle", SqlDbType.NVarChar, 10).Value = swing_axle;
            cmd_Command.Parameters.Add("@swing_speed", SqlDbType.NVarChar, 10).Value = swing_axle;
            cmd_Command.Parameters.Add("@time_or_axle", SqlDbType.NVarChar, 10).Value = swing_axle;
            cmd_Command.Parameters.Add("@blasting_state", SqlDbType.NVarChar, 10).Value = swing_axle;
            cmd_Command.Parameters.Add("@joint_speed", SqlDbType.NVarChar, 10).Value = swing_axle;
            cmd_Command.Parameters.Add("@P1", SqlDbType.Float).Value = p1;
            cmd_Command.Parameters.Add("@P2", SqlDbType.Float).Value = p2;
            cmd_Command.Parameters.Add("@P3", SqlDbType.Float).Value = p3;
            cmd_Command.Parameters.Add("@P4", SqlDbType.Float).Value = p4;
            cmd_Command.Parameters.Add("@P5", SqlDbType.Float).Value = p5;
            cmd_Command.Parameters.Add("@P6", SqlDbType.Float).Value = p6;
            cmd_Command.Parameters.Add("@P7", SqlDbType.Float).Value = p7;
            cmd_Command.Parameters.Add("@P8", SqlDbType.Float).Value = p8;

            cmd_Command.Parameters.Add("@P_SQLCODE", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            cmd_Command.Parameters.Add("@P_SQLERRM", SqlDbType.NVarChar, 500).Direction = System.Data.ParameterDirection.Output;


            try
            {
                cmd_Command.ExecuteNonQuery();
                if (cmd_Command.Parameters["@P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(cmd_Command.Parameters["@P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                cn_connection.Close();
            }
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
