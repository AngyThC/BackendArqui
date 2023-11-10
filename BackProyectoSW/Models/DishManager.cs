using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class DishManager
    {
        public List<Dish> DishGets()
        {
            List<Dish> dishes = new List<Dish>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Dish_All"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int dishID = dr.GetInt32(0);
                    string dishName = dr.GetString(1).Trim();
                    string dishDescripcion = dr.GetString(2).Trim();
                    decimal dishPrice = dr.GetDecimal(3);
                    string typeMenuName = dr.GetString(4).Trim();
                    string status = dr.GetString(5).Trim();

                    Dish dish = new Dish(dishID, dishName, dishDescripcion, dishPrice, typeMenuName, status);

                    dishes.Add(dish);
                }
                dr.Close();
            }
            return dishes;
        }//fin de get

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




        public bool AddDishes(Dish dishes)
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
                cmd.CommandText = "Dish_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                // añadir datos del cliente desde el objeto Drink
                cmd.Parameters.AddWithValue("@DishName", dishes.DishName);
                cmd.Parameters.AddWithValue("@DishDescription", dishes.DishDescription);
                cmd.Parameters.AddWithValue("@DishPrice", dishes.DishPrice);
                cmd.Parameters.AddWithValue("@TypeMenuName", dishes.TypeMenuName);
                cmd.Parameters.AddWithValue("@Status", dishes.Status);

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
        }//fin del add

        public bool UpdateDish(int id, Dish dishes)
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
                cmd.CommandText = "Dish_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@DishName", dishes.DishName);
                cmd.Parameters.AddWithValue("@DishDescription", dishes.DishDescription);
                cmd.Parameters.AddWithValue("@DishPrice", dishes.DishPrice);
                cmd.Parameters.AddWithValue("@TypeMenuName", dishes.TypeMenuName);
                cmd.Parameters.AddWithValue("@Status", dishes.Status);
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
        }//fin del update

        public bool DeleteDish(int id)
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
                cmd.CommandText = "Dish_Delete";
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
        }//fin del Delete
    }
}