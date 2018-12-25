using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using Inventor;
using KybCrypt;

namespace Blastman
{
    public static class DatabaseOLD
    {
        //10.1.10.3
        //10.1.6.178
        private static string ConnectionLogin = @"Data Source="+XMLReader.Ip+@"/" + XMLReader.DatabaseUserName +"; User ID=heimdall; Password=HEIMDALL";
        private static string ConnectionOther= @"Data Source=" + XMLReader.Ip + @"/" + XMLReader.DatabaseUserName +"; User ID=nai; Password=VsYqJFUh";
        //private static string ConnectionOther;


        public static DataTable P_VYKRESYBEZPREDPISU()
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_VYKRESYBEZPREDPISU";
            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 2000).Direction = System.Data.ParameterDirection.Output;

            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                OracleDataReader rdr = orclCmd.ExecuteReader();
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
                orclCon.Close();
            }
        }
        public static void P_LOGIN(string UserName, string Password)
        {
            //kryptovanie passwordu
            string CryptedPassword;
            Crypt crpt = new Crypt();
            CryptedPassword = crpt.EncryptString(Password, "LWRDTN");

            OracleConnection orclCon = new OracleConnection(ConnectionLogin);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "P_LOGIN";
            orclCmd.Parameters.Add("P_APV_KOD", OracleDbType.Varchar2, 20).Value = XMLReader.P_APV_KOD;
            orclCmd.Parameters.Add("P_UZI_LOGIN", OracleDbType.Varchar2, 30).Value = UserName;
            orclCmd.Parameters.Add("P_UZI_HESLO", OracleDbType.Varchar2, 300).Value = CryptedPassword;
            orclCmd.Parameters.Add("P_UZI_KARTA_ID", OracleDbType.Varchar2, 100).Value = XMLReader.P_APV_KOD;
            orclCmd.Parameters.Add("P_CELE_MENO", OracleDbType.Varchar2, 100).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_CON_STRING", OracleDbType.Varchar2, 500).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_CHYBA", OracleDbType.Decimal, 2000).Direction = System.Data.ParameterDirection.Output;

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
               
                if (orclCmd.Parameters["P_CHYBA"].Value.ToString() != "0")
                {
                    if (orclCmd.Parameters["P_CHYBA"].Value.ToString() == "100")
                    {
                        throw new Exception("Nesprávne prihlasovacie meno alebo heslo");
                        
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                        {
                            throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                            
                            
                        }
                        else
                        {
                            throw new Exception("Problém s prihlásením, kontaktuje svojho administrátora.");
                        }
                        
                    }
                }
                if (orclCmd.Parameters["P_CHYBA"].Value.ToString() == "0")
                {
                    ConnectionOther = orclCmd.Parameters["P_CON_STRING"].Value.ToString();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_PREDPISKONTROLA_INS(string CisloVykresu, string Nazov, string Path, string FileName)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_PREDPISKONTROLA_INS";
            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_PRK_NAZOV", OracleDbType.Varchar2, 500).Value = Nazov;
            orclCmd.Parameters.Add("P_PRK_ADRESAR", OracleDbType.Varchar2, 500).Value = Path;
            orclCmd.Parameters.Add("P_PRK_SUBOR_NAZOV", OracleDbType.Varchar2, 500).Value = FileName;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = System.Data.ParameterDirection.Output;

            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();

                if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp; 
                
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_VIRT_DISK_SEL()
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "P_VIRT_DISK_SEL";
            orclCmd.Parameters.Add("P_VID_DISK", OracleDbType.Varchar2, 20).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_VID_CESTA", OracleDbType.Varchar2, 200).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_VID_LOGIN", OracleDbType.Varchar2, 100).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_VID_HESLO", OracleDbType.Varchar2, 100).Direction = System.Data.ParameterDirection.Output;
            //orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
            //orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = System.Data.ParameterDirection.Output;
            
            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();

                //if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                //    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                //    {
                //        throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                //        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                //    }
                AddinGlobal.DriveLetter = orclCmd.Parameters["P_VID_DISK"].Value.ToString();
                AddinGlobal.ServerIPAdress = orclCmd.Parameters["P_VID_CESTA"].Value.ToString();
                AddinGlobal.ServerLoginName = orclCmd.Parameters["P_VID_LOGIN"].Value.ToString();
                AddinGlobal.ServerLoginPassword = orclCmd.Parameters["P_VID_HESLO"].Value.ToString();
            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_PREDPISKONTROLA_INS(string CisloVykresu, string Nazov, string Path, string FileName, string CisloVykresuRodica, string NazovRodica, int StavRodica)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_PREDPISKONTROLA_INS";
            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_PRK_NAZOV", OracleDbType.Varchar2, 500).Value = Nazov;
            orclCmd.Parameters.Add("P_PRK_ADRESAR", OracleDbType.Varchar2, 500).Value = Path;
            orclCmd.Parameters.Add("P_PRK_SUBOR_NAZOV", OracleDbType.Varchar2, 500).Value = FileName;
            orclCmd.Parameters.Add("P_VYK_QMS_RODIC", OracleDbType.Varchar2, 500).Value = CisloVykresuRodica;
            orclCmd.Parameters.Add("P_PRK_NAZOV_RODIC", OracleDbType.Varchar2, 500).Value = NazovRodica;
            orclCmd.Parameters.Add("P_PRK_STAV_RODIC", OracleDbType.Char, 1).Value = StavRodica;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = System.Data.ParameterDirection.Output;

            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();

                if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static DataTable P_VYKRESYSPREDPISOM()
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_VYKRESYSPREDPISOM";
            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 2000).Direction = System.Data.ParameterDirection.Output;

            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                OracleDataReader rdr = orclCmd.ExecuteReader();
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
                orclCon.Close();
            }
        }
        public static void P_PREDPISKONTROLA_SEL(string CisloVykresu, string Nazov, int Stav, out string ModelPath)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_PREDPISKONTROLA_SEL";
            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
           
            orclCmd.Parameters.Add("P_PRK_STAV", OracleDbType.Char, 1).Value = Stav;
            orclCmd.Parameters.Add("P_PRK_NAZOV", OracleDbType.Varchar2, 500).Value = Nazov;


            orclCmd.Parameters.Add("P_PRK_ADRESAR", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_PRK_SUBOR", OracleDbType.Varchar2, 255).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
           
           
            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
                ModelPath = System.IO.Path.Combine(orclCmd.Parameters["P_PRK_ADRESAR"].Value.ToString(), orclCmd.Parameters["P_PRK_SUBOR"].Value.ToString());
            }

            catch (Exception exp)
            {

                ModelPath = null;
                MessageBox.Show(exp.Message);


            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_SKTOLERANCIA_INS(string CisloVykresu, int Typ_skupinovej_tolerancie, double Hodnota1 , double Hodnota2)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_SKTOLERANCIA_INS";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_TLR_KOD", OracleDbType.Int32, 2).Value = Typ_skupinovej_tolerancie;
            orclCmd.Parameters.Add("P_STL_HODNOTA1", OracleDbType.Double, 5).Value = Hodnota1;
            orclCmd.Parameters.Add("P_STL_HODNOTA2", OracleDbType.Double, 5).Value = Hodnota2;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
                if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                    MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
            }


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_VYMAZANIEDATPREDPISU(string CisloVykresu)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_VYMAZANIEDATPREDPISU";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 30).Value = CisloVykresu;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
            }


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_EXPORT_PREDPIS(string CisloVykresu, double TaziskoVyska)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_EXPORT_PREDPIS";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 30).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_TAZISKO_VYSKA", OracleDbType.Double, 6).Value = TaziskoVyska;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();

                if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                orclCon.Close();
            }
        }

        public static void P_SKTOLERANCIA_DEL(string CisloVykresu)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_SKTOLERANCIA_DEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
            }


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_SKTOLERANCIA_SEL(string CisloVykresu, int StavPredpisu, string NazovPredpisu, out double Vzd1, out double Vzd2, out double Uhol1, out double Uhol2, out double Radius1, out double Radius2, out double Povrch)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_SKTOLERANCIA_SEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 30).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_PRK_STAV", OracleDbType.Char, 1).Value = StavPredpisu;
            orclCmd.Parameters.Add("P_PRK_NAZOV", OracleDbType.Varchar2, 30).Value = NazovPredpisu;

            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                Uhol1 = 0;
                Uhol2 = 0;
                Vzd1 = 0;
                Vzd2 = 0;
                Radius1 = 0;
                Radius2 = 0;
                Povrch = 0;

                orclCon.Open();
                OracleDataReader rdr = orclCmd.ExecuteReader();
                dt.Load(rdr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                                   
                    switch (int.Parse(dt.Rows[i][0].ToString()))
                    {
                        case 201:  
                                {
                                Uhol1 = Double.Parse(dt.Rows[i][1].ToString());
                                Uhol2 = Double.Parse(dt.Rows[i][2].ToString());
                                break;
                            }
                        case 202:
                            {
                                Vzd1 = Double.Parse(dt.Rows[i][1].ToString());
                                Vzd2 = Double.Parse(dt.Rows[i][2].ToString());
                                break;
                            }
                        case 203:
                            {
                                Radius1 = Double.Parse(dt.Rows[i][1].ToString());
                                Radius2 = Double.Parse(dt.Rows[i][2].ToString());
                                break;
                            }
                        case 204:
                            {
                                Povrch = Double.Parse(dt.Rows[i][1].ToString());
                                
                                break;
                            }
                        default:
                            
                            break;
                    }
                   
                }
            }


            catch (Exception exp)
            {
                Uhol1 = 0;
                Uhol2 = 0;
                Vzd1 = 0;
                Vzd2 = 0;
                Radius1 = 0;
                Radius2 = 0;
                Povrch = 0;
                MessageBox.Show(exp.Message);
               
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_REZ_INS(string CisloVykresu, int TypRezu, Guid IDRezu, double BasePointX, double BasePointY, double BasePointZ, double VectorX_X, double VectorX_Y, double VectorX_Z, double VectorY_X, double VectorY_Y, double VectorY_Z, double perioda, string NazovDXF, string NazovRezu, string RefKeyPlochyRezu, string NazovRezovejRoviny, double VectorZ_X, double VectorZ_Y, double VectorZ_Z, double LavyBodX, double LavyBodY, double LavyBodZ, double PravyBodX, double PravyBodY, double PravyBodZ, string LavyBodRefKey, string PravyBodRefKey)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_REZ_INS";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("p_trz_kod", OracleDbType.Char, 3).Value = TypRezu;
            orclCmd.Parameters.Add("p_rez_id_nai", OracleDbType.Varchar2, 70).Value = IDRezu.ToString();
            orclCmd.Parameters.Add("p_rez_stred_x", OracleDbType.Double, 10).Value = Math.Round(BasePointX,3);
            orclCmd.Parameters.Add("p_rez_stred_y", OracleDbType.Double, 10).Value = Math.Round(BasePointY, 3);
            orclCmd.Parameters.Add("p_rez_stred_z", OracleDbType.Double, 10).Value = Math.Round(BasePointZ, 3);
            orclCmd.Parameters.Add("p_rez_smerx_x", OracleDbType.Double, 10).Value = Math.Round(VectorX_X, 3);
            orclCmd.Parameters.Add("p_rez_smerx_y", OracleDbType.Double, 10).Value = Math.Round(VectorX_Y, 3);
            orclCmd.Parameters.Add("p_rez_smerx_z", OracleDbType.Double, 10).Value = Math.Round(VectorX_Z, 3);
            orclCmd.Parameters.Add("p_rez_smery_x", OracleDbType.Double, 10).Value = Math.Round(VectorY_X, 3);
            orclCmd.Parameters.Add("p_rez_smery_y", OracleDbType.Double, 10).Value = Math.Round(VectorY_Y, 3);
            orclCmd.Parameters.Add("p_rez_smery_z", OracleDbType.Double, 10).Value = Math.Round(VectorY_Z, 3);
            orclCmd.Parameters.Add("p_rez_perioda", OracleDbType.Double, 10).Value = perioda;
            orclCmd.Parameters.Add("p_rez_subor_dxf", OracleDbType.Varchar2, 70).Value = NazovDXF;
            orclCmd.Parameters.Add("p_rez_nazov_nai", OracleDbType.Varchar2, 100).Value = NazovRezu;
            orclCmd.Parameters.Add("p_rez_cislo_nai", OracleDbType.Varchar2, 200).Value = RefKeyPlochyRezu;
            orclCmd.Parameters.Add("p_rez_nazov_roviny", OracleDbType.Varchar2, 70).Value = NazovRezovejRoviny;
            orclCmd.Parameters.Add("p_rez_smerz_x", OracleDbType.Double, 10).Value = Math.Round(VectorZ_X, 3);
            orclCmd.Parameters.Add("p_rez_smerz_y", OracleDbType.Double, 10).Value = Math.Round(VectorZ_Y, 3);
            orclCmd.Parameters.Add("p_rez_smerz_z", OracleDbType.Double, 10).Value = Math.Round(VectorZ_Z, 3);
            orclCmd.Parameters.Add("p_rez_lavybod_x", OracleDbType.Double, 10).Value = Math.Round(LavyBodX, 3);
            orclCmd.Parameters.Add("p_rez_lavybod_y", OracleDbType.Double, 10).Value = Math.Round(LavyBodY, 3);
            orclCmd.Parameters.Add("p_rez_lavybod_z", OracleDbType.Double, 10).Value = Math.Round(LavyBodZ, 3);
            orclCmd.Parameters.Add("p_rez_pravybod_x", OracleDbType.Double, 10).Value = Math.Round(PravyBodX, 3);
            orclCmd.Parameters.Add("p_rez_pravybod_y", OracleDbType.Double, 10).Value = Math.Round(PravyBodY, 3);
            orclCmd.Parameters.Add("p_rez_pravybod_z", OracleDbType.Double, 10).Value = Math.Round(PravyBodZ, 3);
            orclCmd.Parameters.Add("p_rez_lavybodref", OracleDbType.Varchar2, 200).Value = LavyBodRefKey;
            orclCmd.Parameters.Add("p_rez_pravybodref", OracleDbType.Varchar2, 200).Value = PravyBodRefKey;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();


                orclCmd.ExecuteNonQuery();
                
                    if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                        if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                        {
                            throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                            //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                        }
            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_REZ_DEL(string CisloVykresu)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_REZ_DEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
            }


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_REZ_SEL(string CisloVykresu, int StavPredpisu, string NazovPredpisu, out BindingList<Rez> oListRezov)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_REZ_SEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_PRK_STAV", OracleDbType.Char, 1).Value = StavPredpisu;
            orclCmd.Parameters.Add("P_PRK_NAZOV", OracleDbType.Varchar2, 500).Value = NazovPredpisu;

            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
                oListRezov = new BindingList<Rez>();
                orclCon.Open();
                OracleDataReader rdr = orclCmd.ExecuteReader();
                dt.Load(rdr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Rez oRez = new Rez();
                   
                    
                   

                    oRez.TypRezu =(Typ_rezu) int.Parse(dt.Rows[i][0].ToString());
                    oRez.ID_Rezu = Guid.Parse(dt.Rows[i][1].ToString());
                   
                    oRez.Origin = oTrans.CreatePoint(Double.Parse(dt.Rows[i][2].ToString()), Double.Parse(dt.Rows[i][3].ToString()), Double.Parse(dt.Rows[i][4].ToString()));
                    oRez.X = oTrans.CreateUnitVector(Double.Parse(dt.Rows[i][5].ToString()), Double.Parse(dt.Rows[i][6].ToString()), Double.Parse(dt.Rows[i][7].ToString()));
                    oRez.Y = oTrans.CreateUnitVector(Double.Parse(dt.Rows[i][8].ToString()), Double.Parse(dt.Rows[i][9].ToString()), Double.Parse(dt.Rows[i][10].ToString()));
                    

                    oRez.Perioda = Double.Parse(dt.Rows[i][11].ToString());
                    oRez.DXF = dt.Rows[i][12].ToString();
                    oRez.NazovRezu = dt.Rows[i][13].ToString();
                    oRez.PlaneRefKey = dt.Rows[i][14].ToString();
                    oRez.NazovRoviny = dt.Rows[i][15].ToString();
                    oRez.Z = oTrans.CreateUnitVector(Double.Parse(dt.Rows[i][16].ToString()), Double.Parse(dt.Rows[i][17].ToString()), Double.Parse(dt.Rows[i][18].ToString()));
                    oRez.LavyBod = oTrans.CreatePoint(Double.Parse(dt.Rows[i][19].ToString()), Double.Parse(dt.Rows[i][20].ToString()), Double.Parse(dt.Rows[i][21].ToString()));
                    oRez.PravyBod = oTrans.CreatePoint(Double.Parse(dt.Rows[i][22].ToString()), Double.Parse(dt.Rows[i][23].ToString()), Double.Parse(dt.Rows[i][24].ToString()));
                    oRez.LavyBodRefKey= dt.Rows[i][25].ToString();
                    oRez.PravyBodRefKey = dt.Rows[i][26].ToString();
                    oRez.UpdateRezFromModel();

                    oListRezov.Add(oRez);
                }
            }


            catch (Exception exp)
            {
                oListRezov = new BindingList<Rez>();
                MessageBox.Show(exp.Message);

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void  P_MERANIE_INS(string CisloVykresu, string NazovMerania, int TypMerania, int TypToleranie, int KodChyby, Rez rez1, Rez rez2, string RefKeyPlane1, string RefKeyPlane2, double TolNavestie1, double TolNavestie2, double TolNavestie3, string DXF1, string DXF2, string FileContext)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_MERANIE_INS";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("p_mer_nazov", OracleDbType.Varchar2, 50).Value = NazovMerania;
            orclCmd.Parameters.Add("p_tmr_kod", OracleDbType.Char, 5).Value = TypMerania;
            orclCmd.Parameters.Add("p_tlr_kod", OracleDbType.Char, 5).Value = TypToleranie;
            orclCmd.Parameters.Add("p_chy_kod", OracleDbType.Char, 5).Value = KodChyby;

            if (rez1==null)
            {
                orclCmd.Parameters.Add("p_rez_id_nai1", OracleDbType.Varchar2, 70).Value = null;
               
            }
            else
            {
                orclCmd.Parameters.Add("p_rez_id_nai1", OracleDbType.Varchar2, 70).Value = rez1.ID_Rezu.ToString();
                
            }

            if (rez2 == null)
            {
                orclCmd.Parameters.Add("p_rez_id_nai2", OracleDbType.Varchar2, 70).Value = null;
              
            }
            else
            {
                orclCmd.Parameters.Add("p_rez_id_nai2", OracleDbType.Varchar2, 70).Value = rez2.ID_Rezu.ToString();
               
            }
            if (RefKeyPlane1 == null)
            {
                
                orclCmd.Parameters.Add("p_plo_id_nai1", OracleDbType.Varchar2, 200).Value = null;
            }
            else
            {
                
                orclCmd.Parameters.Add("p_plo_id_nai1", OracleDbType.Varchar2, 200).Value = RefKeyPlane1;
            }
            if (RefKeyPlane2 == null)
            {
                
                orclCmd.Parameters.Add("p_plo_id_nai2", OracleDbType.Varchar2, 200).Value = null;
            }
            else
            {
                
                orclCmd.Parameters.Add("p_plo_id_nai2", OracleDbType.Varchar2, 200).Value = RefKeyPlane2;
            }




            orclCmd.Parameters.Add("p_mer_tol1", OracleDbType.Double, 10).Value = TolNavestie1;
            orclCmd.Parameters.Add("p_mer_tol2", OracleDbType.Double, 10).Value = TolNavestie2;
            orclCmd.Parameters.Add("p_mer_tol3", OracleDbType.Double, 10).Value = TolNavestie3;
            orclCmd.Parameters.Add("p_plo_subor_dxf1", OracleDbType.Varchar2, 70).Value = DXF1;
            orclCmd.Parameters.Add("p_plo_subor_dxf2", OracleDbType.Varchar2, 70).Value = DXF2;
            orclCmd.Parameters.Add("p_ mer_filecontext", OracleDbType.Varchar2, 3000).Value = FileContext;
            

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            //System.IO.File.WriteAllText(@"C:\TEMP\SaveMeranie.txt", FileContext + System.Environment.NewLine+RefKeyPlane1 + System.Environment.NewLine + RefKeyPlane2);

            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
                if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_MERANIE_SEL(string CisloVykresu, int StavPredpisu, string NazovPredpisu, out BindingList<Meranie> oMerania)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_MERANIE_SEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_PRK_STAV", OracleDbType.Char, 1).Value = StavPredpisu;
            orclCmd.Parameters.Add("P_PRK_NAZOV", OracleDbType.Varchar2, 500).Value = NazovPredpisu;

            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();
            oMerania = new BindingList<Meranie>();
            try
            {
                orclCon.Open();
                OracleDataReader rdr = orclCmd.ExecuteReader();
                dt.Load(rdr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Meranie oMeranie = new Meranie((Typ_merania)int.Parse(dt.Rows[i][1].ToString()), dt.Rows[i][0].ToString());

                    int AktualnaTolerancia = int.Parse(dt.Rows[i][2].ToString());
                    switch (AktualnaTolerancia)
                    {
                        case 101:
                            oMeranie.PouzitaSkupinovaTolerancia = false;
                            break;
                        case 102:
                            oMeranie.PouzitaSkupinovaTolerancia = false;
                            break;
                        case 103:
                            oMeranie.PouzitaSkupinovaTolerancia = false;
                            break;
                        case 104:
                            oMeranie.PouzitaSkupinovaTolerancia = false;
                            break;
                        case 105:
                            oMeranie.PouzitaSkupinovaTolerancia = false;
                            break;
                        case 201:
                            oMeranie.PouzitaSkupinovaTolerancia = true;
                            break;
                        case 202:
                            oMeranie.PouzitaSkupinovaTolerancia = true;
                            break;
                        case 203:
                            oMeranie.PouzitaSkupinovaTolerancia = true;
                            break;
                        case 204:
                            oMeranie.PouzitaSkupinovaTolerancia = true;
                            break;
                        default:
                            break;
                    }


                    oMeranie.KodChyby= int.Parse(dt.Rows[i][3].ToString());

                    string IDRezu1= dt.Rows[i][4].ToString();
                    Guid IDRezu1G;
                    Guid.TryParse(IDRezu1, out IDRezu1G);

                    string IDRezu2= dt.Rows[i][5].ToString();
                    Guid IDRezu2G; 
                    Guid.TryParse(IDRezu2, out IDRezu2G);

                    foreach (Rez oRez in AddinGlobal.rezy.ZoznamRezov)
                    {
                        if (oRez.ID_Rezu== IDRezu1G)
                        {
                            oMeranie.Rez1 = oRez;
                        }
                        if (oRez.ID_Rezu == IDRezu2G)
                        {
                            oMeranie.Rez2 = oRez;
                        }
                    }

                    
                    oMeranie.Face1RefKey = dt.Rows[i][6].ToString();
                    oMeranie.Face2RefKey = dt.Rows[i][7].ToString();
                    if (AktualnaTolerancia == 101)
                    {
                        try
                        {
                            oMeranie.NominalValue = Double.Parse(dt.Rows[i][8].ToString());
                        }
                        catch
                        { }
                    }

                    try
                    {
                        oMeranie.Navestie1 = dt.Rows[i][8].ToString();
                    }
                    catch
                    {
                        oMeranie.Navestie1 = "0";
                    }
                    oMeranie.Navestie2 = dt.Rows[i][9].ToString();
                    oMeranie.Navestie3 = dt.Rows[i][10].ToString();
                    oMeranie.DXF1 = dt.Rows[i][11].ToString();
                    oMeranie.DXF2 = dt.Rows[i][12].ToString();

                    //byte[] refKey = new byte[] { };
                    //AddinGlobal.InventorApp.ActiveDocument.ReferenceKeyManager.StringToKey((dt.Rows[i][13].ToString()),ref refKey);
                    //AddinGlobal.byContextHelper = refKey;
                    //AddinGlobal.lContextHelper = AddinGlobal.InventorApp.ActiveDocument.ReferenceKeyManager.LoadContextFromArray(ref refKey);
                    //oMeranie.oContextData = AddinGlobal.lContextHelper;
                    oMerania.Add(oMeranie);
                    //System.IO.File.WriteAllText(@"C:\TEMP\LoadMeranie.txt", dt.Rows[i][13].ToString() + System.Environment.NewLine + dt.Rows[i][6].ToString() + System.Environment.NewLine + dt.Rows[i][7].ToString());
                }

            }


            catch (Exception exp)
            {
               

                MessageBox.Show(exp.Message);

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_MERANIE_DEL(string CisloVykresu)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_MERANIE_DEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
            }


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_NEUPLNYPREDPIS_DEL(string CisloVykresu)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_NEUPLNYPREDPIS_DEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 30).Value = CisloVykresu;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
                if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_POVRCH_INS(string CisloVykresu, int Typ_pohladu, double polomer1, double polomer2, double vyska1, double vyska2, string FaceRefKey, int text, int drazka)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_POVRCH_INS";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("p_poh_kod", OracleDbType.Int16, 2).Value = Typ_pohladu;
            orclCmd.Parameters.Add("p_pov_r1", OracleDbType.Double, 5).Value = Math.Round(polomer1,2);
            orclCmd.Parameters.Add("p_pov_r2", OracleDbType.Double, 5).Value = Math.Round(polomer2,2);
            orclCmd.Parameters.Add("p_pov_z1", OracleDbType.Double, 5).Value = Math.Round(vyska1,2);
            orclCmd.Parameters.Add("p_pov_z2", OracleDbType.Double, 5).Value = Math.Round(vyska2,2);
            orclCmd.Parameters.Add("p_plo_id_nai", OracleDbType.Varchar2, 200).Value = FaceRefKey;
            orclCmd.Parameters.Add("p_pov_priznak_text", OracleDbType.Char, 1).Value = text;
            orclCmd.Parameters.Add("p_pov_priznak_drazka", OracleDbType.Char, 1).Value = drazka;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
                if (orclCmd.Parameters["P_SQLCODE"].Value.ToString() != "0")
                    if (!string.IsNullOrEmpty(orclCmd.Parameters["P_SQLERRM"].Value.ToString()))
                    {
                        throw new Exception(orclCmd.Parameters["P_SQLERRM"].Value.ToString());
                        //MessageBox.Show(orclCmd.Parameters["P_SQLERRM"].Value.ToString(), "Chyba", MessageBoxButtons.OK);
                    }
            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_POVRCH_DEL(string CisloVykresu)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_POVRCH_DEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;

            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
            }


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                orclCon.Close();
            }
        }
        public static void P_POVRCH_SEL(string CisloVykresu, int StavPredpisu, string NazovPredpisu, out BindingList<Povrch> oPovrchy)
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.P_POVRCH_SEL";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 500).Value = CisloVykresu;
            orclCmd.Parameters.Add("P_PRK_STAV", OracleDbType.Char, 1).Value = StavPredpisu;
            orclCmd.Parameters.Add("P_PRK_NAZOV", OracleDbType.Varchar2, 500).Value = NazovPredpisu;

            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();
            oPovrchy = new BindingList<Povrch>();
            try
            {
                orclCon.Open();
                OracleDataReader rdr = orclCmd.ExecuteReader();
                dt.Load(rdr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Povrch oPovrch = new Povrch();
                    oPovrch.Typ_pohladu = (Typ_pohladu)int.Parse(dt.Rows[i][0].ToString());

                    oPovrch.Polomer1 = Double.Parse(dt.Rows[i][1].ToString());
                    oPovrch.Polomer2 = Double.Parse(dt.Rows[i][2].ToString());
                    oPovrch.Vyska1 = Double.Parse(dt.Rows[i][3].ToString());
                    oPovrch.Vyska2 = Double.Parse(dt.Rows[i][4].ToString());

                    string facerefkey = dt.Rows[i][5].ToString();
                    oPovrch.Face1RefKey = facerefkey;
                   
                    oPovrch.Text = Convert.ToBoolean(Int16.Parse(dt.Rows[i][6].ToString()));
                    oPovrch.Drazka = Convert.ToBoolean(Int16.Parse(dt.Rows[i][7].ToString()));



                    oPovrchy.Add(oPovrch);

                }

            }


            catch (Exception exp)
            {


                MessageBox.Show(exp.Message);

            }
            finally
            {
                orclCon.Close();
            }
        }
        public static int p_existujeplatny(string CisloVykresu)
        {
            int ExistujePlatny = 0;
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.p_existujeplatny";

            orclCmd.Parameters.Add("P_VYK_CISLO_QMS", OracleDbType.Varchar2, 30).Value = CisloVykresu;
            orclCmd.Parameters.Add("p_existuje", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();

            try
            {
                orclCon.Open();
                orclCmd.ExecuteNonQuery();
                ExistujePlatny = Int32.Parse(orclCmd.Parameters["p_existuje"].Value.ToString());


               
                return ExistujePlatny;
            }


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return -20014;
            }
            finally
            {
                orclCon.Close();
               
            }
        }
        public static DataTable p_chybovnik_sel()
        {
            OracleConnection orclCon = new OracleConnection(ConnectionOther);
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandType = System.Data.CommandType.StoredProcedure;
            orclCmd.CommandText = "PA_NAI.p_chybovnik_sel";

            orclCmd.Parameters.Add("p_stn_skratka", OracleDbType.Varchar2, 5).Value = "3d";
       

            orclCmd.Parameters.Add("P_RC", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLCODE", OracleDbType.Int32).Direction = ParameterDirection.Output;
            orclCmd.Parameters.Add("P_SQLERRM", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            DataTable dt = new DataTable();
          
            try
            {
                orclCon.Open();
                OracleDataReader rdr = orclCmd.ExecuteReader();
                dt.Load(rdr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   

                }
                return dt;

            }


            catch (Exception exp)
            {


                MessageBox.Show(exp.Message);
                return null;
            }
            finally
            {
                orclCon.Close();
            }
        }
    }

    
}
