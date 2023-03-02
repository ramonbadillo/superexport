
namespace FeatherExport.Utilities
{
    using FeatherExport.Properties;
    using MySql.Data.MySqlClient;
        using System;
        using System.Data;
        using System.IO;
        using System.Windows.Forms;

        public static class ConnectionConfig
        {
            public static readonly int CamaleonBuild = 146;
            public static string ConnectionString = "datasource = localhost; port = 3306; username = root; password = antonio  ; SslMode=none; convert zero datetime=True;Allow User Variables=True; database= smbc_paseo;";

            public static bool GetDataBases(ComboBox comboBox1, ComboBox comboBox2, string server, string port, string username, string password)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                bool ConectionMaked = false;
                string conectionString = "datasource = " + server + " ; Port = " + port + " ; User Id = " + username + " ; password = " + password + " ; SslMode = none; ";
                MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(conectionString);
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SHOW DATABASES;";
                    MySqlDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row += reader.GetValue(i).ToString() + "";
                        }
                        comboBox1.Items.Add(row);
                        comboBox2.Items.Add(row);
                    }
                    ConectionMaked = true;
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
                return ConectionMaked;
            }

            public static void SavefilenameMTDB()
            {
                try
                {

                    StreamWriter sw = new StreamWriter(@"C:\Program Files (x86)\Camaleon Systems\filenameMTDB");


                    sw.WriteLine(Settings.Default.localServer);
                    sw.WriteLine(Settings.Default.localDatabase);
                    sw.WriteLine(Settings.Default.localUser);
                    sw.WriteLine(Settings.Default.localPassword);


                    sw.Close();
                    MessageBox.Show("Database Changed", "Camaleon Control Center");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }


            }

            public static void LoadFromMDFile(string FilePath)
            {
                try
                {

                    StreamReader file = new StreamReader(FilePath);
                    Settings.Default.localServer = file.ReadLine().Replace("\"", "");
                    Settings.Default.localPort = "3306";
                    Settings.Default.localDatabase = file.ReadLine().Replace("\"", "");
                    Settings.Default.localUser = file.ReadLine().Replace("\"", "");
                    Settings.Default.localPassword = file.ReadLine().Replace("\"", "");
                    Settings.Default.Save();
                    file.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }


            }

            public static int GetProcessList()
            {
                int ProcessCount = 0;
                MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(ConnectionString);
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SHOW PROCESSLIST;";
                    MySqlDataReader Reader;
                    connection.Open();
                    Reader = command.ExecuteReader();

                    while (Reader.Read())
                    {
                        //CurrentVersion = Reader.GetString("CamaleonVER");
                        ProcessCount++;
                    }
                    Reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }

                return ProcessCount;
            }

            public static int CheckCamaleonVersion()
            {
                int CurrentBuild = 0;
                MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(ConnectionString);
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT CamaleonVER, Camaleon_Build FROM it_tcompany;";
                    MySqlDataReader Reader;
                    connection.Open();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        //CurrentVersion = Reader.GetString("CamaleonVER");
                        CurrentBuild = Reader.GetInt16("Camaleon_Build");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }

                return CurrentBuild;
            }

            public static void LoadConnStringSettings()
            {
                ConnectionString = "datasource = " + Settings.Default.localServer + "; ";
                ConnectionString += "port = " + Settings.Default.localPort + "; ";
                ConnectionString += "username = " + Settings.Default.localUser + "; ";
                ConnectionString += "password = " + Settings.Default.localPassword + "; ";
                ConnectionString += "database = " + Settings.Default.localDatabase + "; ";
                ConnectionString += "SslMode = none;";

               
            }
        }
    }