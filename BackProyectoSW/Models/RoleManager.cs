using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackProyectoSW.Models
{
    public class RoleManager
    {
        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                conecti.Open();

                SqlCommand cmd = conecti.CreateCommand();
                //stored procedure para obtener tipos de menu
                cmd.CommandText = "GetRole";
                cmd.CommandType = CommandType.StoredProcedure;

                //ejecutar lector de datos
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //obtener id y el rol
                    int id = dr.GetInt32(0);
                    string name = dr.GetString(1).Trim();

                    //Agregar objeto a rol
                    Role role = new Role(id, name);

                    //Agregar a lista de role
                    roles.Add(role);
                }

                dr.Close();
                conecti.Close();
            }
            return roles;
        }//Fin de GetRole

        //AddRole
        public bool AddRole(Role name)
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
                cmd.CommandText = "AddRole";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@role", name.Name_Role);

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
        }//Fin de Add



        //Update
        public bool UpdateRole(int id, Role name)
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
                cmd.CommandText = "UpdateRol";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@role", name.Name_Role);

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
        }//Fin de Update



        //Delete
        public bool DeleteRole(int id)
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
                cmd.CommandText = "DeleteRol";
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
        }//Fin de ADeletedd
    }//fin de clase
}