using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class ReservacionesManager
    {
        public List<Reservation> GetReservacion()
        {
            List<Reservation> reservations = new List<Reservation>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();
            //conexion a bd
            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                conecti.Open();

                SqlCommand cmd = conecti.CreateCommand();
                cmd.CommandText = "Reservation_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    int ID = dr.GetInt32(0);
                    string descripcion = dr.GetString(1).Trim();
                    DateTime reservationdate = dr.GetDateTime(2);
                    int quantityPerson = dr.GetInt32(3);
                    string Customerid = dr.GetString(4).Trim();
                    int reservationcost = dr.GetInt32(5);
                    string reservationtime = dr.GetString(6);
                    string status = dr.GetString(7);


                    Reservation resertavion = new Reservation(ID, descripcion, reservationdate, quantityPerson, Customerid, reservationcost, reservationtime, status);

                    reservations.Add(resertavion);
                }
                dr.Close();
                conecti.Close();
            }
            return reservations;
        }//Fin de Reservacion


        public bool AddReservacion(Reservation reservation)
        {
            bool res = false;
            // conexión a bd
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conecti = new SqlConnection(strCon))
            {
                SqlCommand cmd = conecti.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.CommandText = "Reservation_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Descripcion", reservation.Description);
                cmd.Parameters.AddWithValue("@date", reservation.ReservationDate);
                cmd.Parameters.AddWithValue("@quatity", reservation.QuantityPersons);
                cmd.Parameters.AddWithValue("@nameCustomer", reservation.CustomerID);
                cmd.Parameters.AddWithValue("@cost", reservation.ReservationCost);
                cmd.Parameters.AddWithValue("@Time", reservation.ReservationTime);
                cmd.Parameters.AddWithValue("@Status", reservation.Status);

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
        }// Fin de Reservacion

        public bool UpdateReservation(int id, Reservation reservation)
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
                cmd.CommandText = "Reservation_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                //añadir datos seleccionados
                cmd.Parameters.AddWithValue("@ReservationID", id);
                cmd.Parameters.AddWithValue("@Descripcion", reservation.Description);
                cmd.Parameters.AddWithValue("@Date", reservation.ReservationDate);
                cmd.Parameters.AddWithValue("@Quantity", reservation.QuantityPersons);
                cmd.Parameters.AddWithValue("@nameCustomer", reservation.CustomerID);
                cmd.Parameters.AddWithValue("@cost", reservation.ReservationCost);
                cmd.Parameters.AddWithValue("@Time", reservation.ReservationTime);
                cmd.Parameters.AddWithValue("@status", reservation.Status);

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
        }//Fin de UpdateReservation
    }
}