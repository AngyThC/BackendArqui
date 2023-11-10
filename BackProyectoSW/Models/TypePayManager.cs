using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class TypePayManager
    {
        public List<TypePay> GetTypePays()
        {
            List<TypePay> typePays = new List<TypePay>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                conecti.Open();

                SqlCommand cmd = conecti.CreateCommand();
                //stored procedure para obtener tipos de menu
                cmd.CommandText = "GetTypePay";
                cmd.CommandType = CommandType.StoredProcedure;

                //ejecutar lector de datos
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //obtener el id y el typepay
                    int id = dr.GetInt32(0);
                    string name = dr.GetString(1).Trim();
                    string status = dr.GetString(2).Trim();

                    //agregar objeto al typepay
                    TypePay typePay = new TypePay(id, name, status);

                    //agregar a la lista del typepay
                    typePays.Add(typePay);
                }
                dr.Close();
                conecti.Close();
            }
            return typePays;
        }//fin de GetTypePay

        //AddTypePay
        public bool AddTypePays(TypePay name)
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
                cmd.CommandText = "AddTypePay";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@typePAY", name.Name_typepay);
                cmd.Parameters.AddWithValue("@status", name.Status);

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
        }//Fin del AddTypePay

        //Update
        public bool UpdateTypePays(int id, TypePay name)
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
                cmd.CommandText = "UpdateTypePay";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@idtypePAY", id);
                cmd.Parameters.AddWithValue("@typePAY", name.Name_typepay);
                cmd.Parameters.AddWithValue("@status", name.Status);

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
        }//fin update

        //Delete
        public bool DeletetypePays(int id)
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
                cmd.CommandText = "DeletetypePay";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@idtypePAY", id);

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
        }//Fin de Delete
    }//fin de la clase
}