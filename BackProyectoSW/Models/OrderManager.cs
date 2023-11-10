using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class OrderManager
    {
        
        public List<Order> GetOrder()
            {

             List<Order> orden = new List<Order>();
             string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Orderfija_All"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string type = dr.GetString(1);
                    string customerid = dr.GetString(2);
                    string description = dr.GetString(3);
                    string estado = dr.GetString(4);

 
                 Order order = new Order( id, type, customerid, description, estado);

                 orden.Add(order);

                }

                 dr.Close(); 
            }

            return orden;

            }


        public List<Customer> GetNameCustom()
        {
            List<Customer> customs = new List<Customer>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "getCustomerName"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string CustomName = dr.GetString(0).Trim();


                    Customer custom = new Customer(CustomName);

                    customs.Add(custom);
                }

                dr.Close();
            }

            return customs;
        }

        public bool AddOrder(Order order)
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
                cmd.CommandText = "Orderfijo_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Tipo", order.TypeOrder);
                cmd.Parameters.AddWithValue("@CustomerName", order.Name_Customer);
                cmd.Parameters.AddWithValue("@Description", order.DescriptionOrder);
                cmd.Parameters.AddWithValue("@status", order.Status);

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

        }

        public bool UpdateOrder(int id, Order order)
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
                cmd.CommandText = "Orderfija_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderID", id);
                cmd.Parameters.AddWithValue("@Tipo", order.TypeOrder);
                cmd.Parameters.AddWithValue("@CustomerName", order.Name_Customer);
                cmd.Parameters.AddWithValue("@Description", order.DescriptionOrder);
                cmd.Parameters.AddWithValue("@status", order.Status);

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

        }




    }
}