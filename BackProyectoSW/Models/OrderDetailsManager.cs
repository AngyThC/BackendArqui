using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class OrderDetailsManager
    {
        public List<OrderDetails> GetOrderDetails()
        {
            List<OrderDetails> details = new List<OrderDetails>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Order_All"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string dishid = dr.GetString(1).Trim();
                    decimal quantitydish = dr.GetDecimal(2);
                    string drinkid = dr.GetString(3).Trim();
                    decimal quatityid = dr.GetDecimal(4);
                    decimal totalamount = dr.GetDecimal(5);
                    int orderid = dr.GetInt32(6);


                    OrderDetails detail = new OrderDetails( id,  dishid,  quantitydish,  drinkid,  quatityid, totalamount, orderid);

                    details.Add(detail);
                }

                dr.Close();
            }

            return details;
        }


        public List<Drink> GetNameDrink()
        {
            List<Drink> drinks = new List<Drink>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "getDrinkName"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string drinkName = dr.GetString(0).Trim();


                    Drink custom = new Drink(drinkName);

                    drinks.Add(custom);
                }

                dr.Close();
            }

            return drinks;
        }


        public List<Dish> GetNameDish()
        {
            List<Dish> dishes = new List<Dish>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "getDishName"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string drinkName = dr.GetString(0).Trim();


                    Dish dish = new Dish(drinkName);

                    dishes.Add(dish);
                }

                dr.Close();
            }

            return dishes;
        }





        public bool AddDetails(OrderDetails details)
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
                cmd.CommandText = "Order_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                // añadir datos del cliente desde el objeto Drink
                cmd.Parameters.AddWithValue("@DishName", details.DishID);
                cmd.Parameters.AddWithValue("@DrinkName", details.DrinkID);
                cmd.Parameters.AddWithValue("@OrderID", details.OrderID);

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
        }// Fin de AddOrderDetails

        public bool UpdateDetails(int id, OrderDetails details)
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
                cmd.CommandText = "Order_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@OrderID ", id);
                cmd.Parameters.AddWithValue("@DishName", details.DishID);
                cmd.Parameters.AddWithValue("@DrinkName", details.DrinkID);
                cmd.Parameters.AddWithValue("@Oderid", details.OrderID);
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
        }//Fin de UpdateOrderDetails


    }
}