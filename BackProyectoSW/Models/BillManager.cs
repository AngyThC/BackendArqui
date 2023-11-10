using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class BillManager
    {
        public List<Bill> GetBills()
        {
            List<Bill> bill = new List<Bill>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Bill_All1"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0); // BillID
                    string typemenu = dr.GetString(1); // TypePay
                    string descriptionorder = dr.GetString(2);
                    DateTime billdate = dr.GetDateTime(3); // BillDate
                    decimal total = dr.GetDecimal(4); // Total

                    Bill bills = new Bill(id, typemenu, descriptionorder, billdate, total);

                    bill.Add(bills);
                }
                dr.Close();
            }
            return bill;
        }

        public List<TypePay> GetNametypepay()
        {
            List<TypePay> typePays = new List<TypePay>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "getTypePayName"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string typepayName = dr.GetString(0).Trim();


                    TypePay custom = new TypePay(typepayName);

                    typePays.Add(custom);
                }

                dr.Close();
            }

            return typePays;
        }

        public List<Order> GetDescriptionOrder()
        {
            List<Order> orders = new List<Order>();
            string strCon = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "getDescriptionOrder"; // Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string descriptionorder = dr.GetString(0).Trim();


                    Order order = new Order(descriptionorder);

                    orders.Add(order);
                }

                dr.Close();
            }

            return orders;
        }


        public bool AddBill(Bill bill)
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
                cmd.CommandText = "Bill_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TipoPago", bill.TypePay);
                cmd.Parameters.AddWithValue("@OrderName", bill.DescriptionOrder);

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

        public bool UpdateBill(int id, Bill bill)
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
                cmd.CommandText = "Bill_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BillID", bill.BillID);
                cmd.Parameters.AddWithValue("@TipoPago", bill.TypePay);
                cmd.Parameters.AddWithValue("@OrderName", bill.DescriptionOrder);

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