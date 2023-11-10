using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class DrinkManager 
    {
        public List<Drink> GetDrinks()
        {
            List<Drink> drinks = new List<Drink>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Drink_All"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int drinkID = dr.GetInt32(0);
                    string drinkName = dr.GetString(1).Trim();
                    string drinkDescripcion = dr.GetString(2).Trim();
                    decimal drinkPrice = dr.GetDecimal(3);
                    string typeMenuName = dr.GetString(4).Trim();
                    string status = dr.GetString(5).Trim();


                    Drink drink = new Drink(drinkID, drinkName, drinkDescripcion,  drinkPrice, typeMenuName, status);

                    drinks.Add(drink);
                }

                dr.Close();
            }

            return drinks;
        }
        public List<TypeMenu> GetTypeMenu()
        {
            List<TypeMenu> menus = new List<TypeMenu>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "getTypeAll"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string typeMenuName = dr.GetString(0).Trim();
                    string status = dr.GetString(1).Trim();


                    TypeMenu menu = new TypeMenu(typeMenuName, status);

                    menus.Add(menu);
                }

                dr.Close();
            }

            return menus;
        }



        public bool AddDrink(Drink drinks)
        {
            bool res = false;
            // conexión a bd
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                // crear comando para añadir Drink
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // llamar al procedimiento almacenado para añadir Drink
                cmd.CommandText = "Drink_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                // añadir datos del cliente desde el objeto Drink
                cmd.Parameters.AddWithValue("@DrinkName", drinks.DrinkName);
                cmd.Parameters.AddWithValue("@DrinkDescription", drinks.DrinkDescription);
                cmd.Parameters.AddWithValue("@DrinkPrice", drinks.DrinkPrice);
                cmd.Parameters.AddWithValue("@TypeMenuName", drinks.TypeMenuName);
                cmd.Parameters.AddWithValue("@Status", drinks.Status);

                try
                {
                    conecti.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conecti.Close();
                }

                return res;
            }
        }// Fin de AddDrink


        public bool UpdateDrink(int id, Drink drinks)
        {
            bool res = false;
            //conexion a bd
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                //crear comando para añadir Drink
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //llamar stored procedure añadir Drink
                cmd.CommandText = "Drink_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@DrinkName", drinks.DrinkName);
                cmd.Parameters.AddWithValue("@DrinkDescription", drinks.DrinkDescription);
                cmd.Parameters.AddWithValue("@DrinkPrice", drinks.DrinkPrice);
                cmd.Parameters.AddWithValue("@TypeMenuName", drinks.TypeMenuName);
                cmd.Parameters.AddWithValue("@Status", drinks.Status);

                try
                {
                    conecti.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conecti.Close();
                }

                return res;
            }
        }//Fin de UpdateDrink


        public bool DeleteDrink(int id)
        {
            bool res = false;
            //conexion a bd
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                //crear comando para añadir Drink
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //llamar stored procedure añadir Drink
                cmd.CommandText = "Drink_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conecti.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conecti.Close();
                }

                return res;
            }
        }//Fin de DeleteDrink
    }
}