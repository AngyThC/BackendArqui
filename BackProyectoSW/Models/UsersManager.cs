using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace BackProyectoSW.Models
{
    public class UsersManager
    {
        public List<Users> GetUsers() //METODO GET
        {
            List<Users> users = new List<Users>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUsers"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int userid = dr.GetInt32(0);
                    string rolename = dr.GetString(2).Trim();
                    string username = dr.GetString(3).Trim();

                    Users user = new Users(userid, rolename, username);

                    users.Add(user);
                }
                dr.Close();
            }
            return users;

        }//fin get 


        public List<Role> GetRol()
        {
            List<Role> rols = new List<Role>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "getRolName"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string typeROl = dr.GetString(0).Trim();


                    Role rol = new Role(typeROl);

                    rols.Add(rol);
                }

                dr.Close();
            }

            return rols;
        }


        public List<Users> GetLog(Users users)
        {
            List<Users> roles = new List<Users>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUserData"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InputUserName", users.UserName);
                cmd.Parameters.AddWithValue("@InputPassword", users.Password);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string role = dr.GetString(2).Trim();
                    string username = dr.GetString(0).Trim();
                    string password = dr.GetString(1).Trim();

                    Users user = new Users(role, username, password);

                    roles.Add(user);
                }

                dr.Close();
            }

            return roles;
        }



        public bool AddUsers(Users users) //METODO ADD
        {
            bool res = false;
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();
            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                // crear comando para añadir User
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // llamar al procedimiento almacenado para añadir User
                cmd.CommandText = "AddUsers";
                cmd.CommandType = CommandType.StoredProcedure;

                //A;adir datos del cliente desde el objeto User
                cmd.Parameters.AddWithValue("@rolename", users.RoleName);
                cmd.Parameters.AddWithValue("@username", users.UserName);

                try
                {
                    conecti.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch(Exception ex)
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
        }// FIN ADD


        public bool UpdateUsers(int id, Users users)//METODO UPDATE
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
                cmd.CommandText = "UpdateUser";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@username", users.UserName);
                cmd.Parameters.AddWithValue("@rolename", users.RoleName);

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
        }//FIN UPDATE

        public bool DeleteUsers(int id)
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
                cmd.CommandText = "DeleteUsers";
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
        }
    }
}