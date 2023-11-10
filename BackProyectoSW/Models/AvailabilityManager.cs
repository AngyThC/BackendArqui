using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class AvailabilityManager
    {
        public List<Availability> GetAvailability()
        {
            List<Availability> available = new List<Availability>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();
            //conexion a bd
            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                conecti.Open();

                SqlCommand cmd = conecti.CreateCommand();
                //stored procedure para obtener tipos de menu
                cmd.CommandText = "Availability_All";
                cmd.CommandType = CommandType.StoredProcedure;

                //ejecutar lector de datos
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //obtener id y el Availability
                    int id = dr.GetInt32(0);
                    int pMAX = dr.GetInt32(1);
                    int pMIN = dr.GetInt32(2);
                    int dMAX = dr.GetInt32(3);
                    int wMAX = dr.GetInt32(4);
                    int mMAX = dr.GetInt32(5);
 


                    //Agregar objeto a Availability
                    Availability availability = new Availability(id, pMAX, pMIN, dMAX, wMAX, mMAX);

                    //Agregar a lista de Availability
                    available.Add(availability);
                }
                dr.Close();
                conecti.Close();
            }
            return available;
        }//Fin de GetAvailability

        public bool AddAvailability(Availability availability)
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
                cmd.CommandText = "Availability_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                // añadir datos del cliente desde el objeto customer
                cmd.Parameters.AddWithValue("@PersonsMAX", availability.AvailibityPersonsMAX);
                cmd.Parameters.AddWithValue("@PersonsMIN", availability.AvailibityPersonsMIN);
                cmd.Parameters.AddWithValue("@DailyMAX", availability.AvailibityReservationDailyMAX);
                cmd.Parameters.AddWithValue("@WeeklyMAX", availability.AvailibityReservationWeeklyMAX);
                cmd.Parameters.AddWithValue("@MonthlyMAX", availability.AvailibityReservationMonthlyMAX);

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
        }// Fin de AddAvailability

        public bool UpdateAvailability(int id, Availability availability)
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
                cmd.CommandText = "Availability_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@PersonsMAX", availability.AvailibityPersonsMAX);
                cmd.Parameters.AddWithValue("@PersonsMIN", availability.AvailibityPersonsMIN);
                cmd.Parameters.AddWithValue("@DailyMAX", availability.AvailibityReservationDailyMAX);
                cmd.Parameters.AddWithValue("@WeeklyMAX", availability.AvailibityReservationWeeklyMAX);
                cmd.Parameters.AddWithValue("@MonthlyMAX", availability.AvailibityReservationMonthlyMAX);

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
        }//Fin de UpdateAvailability

        public bool DeleteAvailability(int id)
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
                cmd.CommandText = "Availability_Delete";
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
        }//Fin de DeleteAvailability
    }
}