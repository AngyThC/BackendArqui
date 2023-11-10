using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class TypeMenuManager
    {

        //method getTypeMenu
        //obtener tipo menu
        public List<TypeMenu> getTypeMenu() {
            //lista para menu
            List<TypeMenu> listaT  = new List<TypeMenu>();
            //conexion a base de datos restaurante
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                conecti.Open();

                //obtener stored procedure de sql server 
                SqlCommand cmd = conecti.CreateCommand();
                //stored procedure para obtener tipos de menu
                cmd.CommandText = "TypeMenu_All";
                cmd.CommandType = CommandType.StoredProcedure;

                //ejecutar lector de datos
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //obtener id y tipo menu
                    int id = dr.GetInt32(0);
                    string menuType = dr.GetString(1).Trim();
                    string status = dr.GetString(2).Trim();

                    //agregar a objeto menuT
                    TypeMenu menuT = new TypeMenu(id, menuType, status);

                    //agregar a lista de menu
                    listaT.Add(menuT);
                }

                //cerrar conexiones
                dr.Close();
                conecti.Close();
            }
             //retornar a lista
            return listaT;

        }

        //method add Types of menu
        public bool AddTypeMenu(TypeMenu menuT)
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
                cmd.CommandText = "Menu_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@typemenu", menuT.Type_Menus);
                cmd.Parameters.AddWithValue("@estado", menuT.Status);

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

        //method update or edit Types of menu
        public bool UpdateTypeMenu(int id, TypeMenu menuT)
        {
            bool res = false;

            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "TypeMenu_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@typemenu", menuT.Type_Menus);
                cmd.Parameters.AddWithValue("@estado", menuT.Status);

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

     


        //method delete Type of menu
        public bool DeleteTypeMenu(int id)
        {
            bool res = false;
             
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "TypeMenu_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

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