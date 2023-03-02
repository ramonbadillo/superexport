using FeatherExport.Models;
using FeatherExport.Utilities;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeatherExport
{
    public static class Camaleon
    {

        public static int CheckClass(string ClassName) {

            int moveId = 0;
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = new MySqlConnection(ConnectionConfig.ConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT Class_ID FROM it_titemclass WHERE Class_Name = '{ClassName}';";
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    moveId = HelpersDatabase.GetInt(reader, "Class_ID");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Logs.SlackMessageNew(LogType.Error, " CheckMove Error: " + e.Message);
            }
            finally
            {
                HelpersDatabase.CloseConnection(ref connection);
            }
            return moveId;
           
        }


        public static int CreateNewClass(string Name) {

            int cuentaLocalId = 0;
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            
            try
            {
                connection = new MySqlConnection(ConnectionConfig.ConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO it_titemclass " +
                                      "(Class_Name,Class_Show,Class_Show_Web ) " +
                                      $"VALUES('{Name}',1 ,1);";

                connection.Open();
                command.ExecuteNonQuery();
                command.CommandText = "SELECT LAST_INSERT_ID() AS 'id';";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cuentaLocalId = HelpersDatabase.GetInt(reader, "id");
                }

                connection.Close();
            }
            catch (MySqlException me)
            {
                Console.WriteLine(me.Message);
                //Logs.SlackMessageNew(LogType.Error, " CreateCuenta Error: " + me.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Logs.SlackMessageNew(LogType.Error, " CreateCuenta Error: " + e.Message);
            }
            finally
            {
                HelpersDatabase.CloseReader(ref reader);
                HelpersDatabase.CloseConnection(ref connection);
            }

            return cuentaLocalId;
        }




        public static string CheckItem(string ItemName) {
            string moveId = "";
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = new MySqlConnection(ConnectionConfig.ConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT ITEM_ID FROM it_titem WHERE ITEM_Description = '{ItemName}';";
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    moveId = HelpersDatabase.GetString(reader, "Move_ID");
                }
            }
            catch (Exception e)
            {
                //Logs.SlackMessageNew(LogType.Error, " CheckMove Error: " + e.Message);
            }
            finally
            {
                HelpersDatabase.CloseConnection(ref connection);
            }
            return moveId;
        }


        public static string CheckCurrentItemID()
        {
            int ItemId = 400001;
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = new MySqlConnection(ConnectionConfig.ConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT MAX(ITEM_ID) AS maximo FROM IT_TItem WHERE LENGTH(ITEM_ID) = 6;";
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ItemId = HelpersDatabase.GetInt(reader, "maximo");
                }
            }
            catch (Exception e)
            {
                //Logs.SlackMessageNew(LogType.Error, " CheckMove Error: " + e.Message);
            }
            finally
            {
                HelpersDatabase.CloseConnection(ref connection);
            }
            return ItemId.ToString();
        }




        public static string CreateItem(Detalle detalle,int ClassId, string ItemId) {
            string cuentaLocalId = "";
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(ConnectionConfig.ConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO it_titemclass " +
                                        "(ITEM_ID, " +
                                        "ITEM_Description," +//1
                                        "ITEM_Det_Description," +//2
                                        "ITEM_Screen_Name, " +//3
                                        "ITEM_kitchen_Name, " +//4
                                        "ITEM_Unit_ID," +//5
                                        "ITEM_Class_ID," +//6
                                        "ITEM_Sale_Price," +//7
                                        "ITEM_Sale_Price2," +//8
                                        "ITEM_Show, " +//9
                                        "Created_date, " +//10
                                        "Modify_date, " +//11
                                        "Modify_by ) " +//12
                                        $"VALUES(" +
                                        $" '{detalle.item}'," +//1
                                        $" '{detalle.item}'," +//2
                                        $" '{detalle.item}'," +//3
                                        $" '{detalle.item}'," +//4
                                        $"1 ," +//5
                                        $"{ClassId} ," +//6
                                        $"{detalle.price} ," +//7
                                        $"{detalle.price} ," +//8
                                        $"1 ," +//9
                                        $"NOW() ," +//10
                                        $"NOW() ," +//11
                                        $"1);";//12

                connection.Open();
                command.ExecuteNonQuery();
                //command.CommandText = "SELECT LAST_INSERT_ID() AS 'id';";
                //reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    cuentaLocalId = HelpersDatabase.GetInt(reader, "id");
                //}

                connection.Close();
            }
            catch (MySqlException me)
            {
                Console.WriteLine(me.Message);
                //Logs.SlackMessageNew(LogType.Error, " CreateCuenta Error: " + me.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Logs.SlackMessageNew(LogType.Error, " CreateCuenta Error: " + e.Message);
            }
            finally
            {
                HelpersDatabase.CloseReader(ref reader);
                HelpersDatabase.CloseConnection(ref connection);
            }

            return cuentaLocalId;

        }






        public static int CheckUser(string UserName) {
            int moveId = 0;
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = new MySqlConnection(ConnectionConfig.ConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT Move_ID FROM it_tuser WHERE USER_Login = '{UserName}';";
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    moveId = HelpersDatabase.GetInt(reader, "Move_ID");
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                HelpersDatabase.CloseConnection(ref connection);
            }
            return moveId;
           
        }


        public static bool CreateUser(string UserName) {
            return true;
        }




    }
}
