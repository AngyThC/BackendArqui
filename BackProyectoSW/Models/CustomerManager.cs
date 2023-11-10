using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace BackProyectoSW.Models
{
    public class CustomerManager
    {

        public List<Customer> GetCustomers() 
        { 
         List<Customer> customers = new List<Customer>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();
            //conexion a bd
            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                conecti.Open();

                SqlCommand cmd = conecti.CreateCommand();
                //stored procedure para obtener tipos de menu
                cmd.CommandText = "GetCustomer";
                cmd.CommandType = CommandType.StoredProcedure;

                //ejecutar lector de datos
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //obtener id y el rol
                    int ID = dr.GetInt32(0);
                    string name = dr.GetString(1).Trim();
                    string nit = dr.GetString(2).Trim();
                    string phone = dr.GetString(3).Trim();
                    string addres = dr.GetString(4).Trim();
                    string status = dr.GetString(5);


                    //Agregar objeto a rol
                   Customer customer= new Customer(ID, name, nit, phone, addres, status);

                    //Agregar a lista de role
                    customers.Add(customer);
                }
                dr.Close();
                conecti.Close();
            }
            return customers;
        }//Fin de GetCustomer

        public bool AddCustomers(Customer customer)
        {
            bool res = false;
            // conexión a bd
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                // crear comando para añadir cliente
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // llamar al procedimiento almacenado para añadir cliente
                cmd.CommandText = "AddCustomer";
                cmd.CommandType = CommandType.StoredProcedure;

                // añadir datos del cliente desde el objeto customer
                cmd.Parameters.AddWithValue("@nombre", customer.Name_Customer);
                cmd.Parameters.AddWithValue("@nit", customer.Nit_Customer);
                cmd.Parameters.AddWithValue("@phone", customer.Phone_Customer);
                cmd.Parameters.AddWithValue("@direccion", customer.Addres_Customer);
                cmd.Parameters.AddWithValue("@estado", customer.Status_Customer);

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
        }// Fin de AddCustomer

        public bool UpdateCustomers(int id, Customer customer)
        {
            bool res = false;
            //conexion a bd
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                //crear comando para añadir menu
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //llamar stored procedure añadir menu
                cmd.CommandText = "UpdateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", customer.Name_Customer);
                cmd.Parameters.AddWithValue("@nit", customer.Nit_Customer);
                cmd.Parameters.AddWithValue("@phone", customer.Phone_Customer);
                cmd.Parameters.AddWithValue("@direccion", customer.Addres_Customer);
                cmd.Parameters.AddWithValue("@estado", customer.Status_Customer);

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
        }//Fin de UpdateCustomer

        public bool DeleteCustomers(int id)
        {
            bool res = false;
            //conexion a bd
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                //crear comando para añadir menu
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //llamar stored procedure añadir menu
                cmd.CommandText = "Deletecustomer";
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
        }//Fin de DeleteCustomer



    }

        }
