﻿using BasicCSharp.Object;
using Microsoft.Data.SqlClient;
using System.Data;

namespace basic_csharp.SQLAdapter
{
    public class CartSQLAdapter : ISQLAdapter<Cart>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public CartSQLAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "Cart";
        }

        public List<Cart> GetData()
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Cart", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            List<Cart> Cart_Selected = new List<Cart>();

            foreach (DataRow row in temp_table.Rows)
            {
                Cart temp_cart = new Cart();
                temp_cart.Cart_ID = (Guid)row["Cart_ID"];
                temp_cart.Cart_User_ID = (Guid)row["Cart_User_ID"];
                Cart_Selected.Add(temp_cart);
            }
            connection.Close();
            return Cart_Selected;
        }

        public Cart Get(Guid id)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Cart", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            Cart temp_cart = new Cart();

            foreach (DataRow row in temp_table.Rows)
            {
                if (id.CompareTo((Guid)row["Cart_ID"]) == 0)
                {
                    temp_cart.Cart_ID = (Guid)row["Cart_ID"];
                    temp_cart.Cart_User_ID = (Guid)row["Cart_User_ID"];
                    
                }
            }
            connection.Close();
            return temp_cart;
        }

        public int Insert(Cart item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            int Notify = 0;

            connection.Open();

            //Insert Data
            string stringQuery = "INSERT INTO Cart ( Cart_ID, Cart_User_ID) " +
                "VALUES ( @Cart_ID, @Cart_User_ID)";
            SqlCommand command = new SqlCommand(stringQuery, connection);

            command.Parameters.AddWithValue("@Cart_ID", item.Cart_ID);
            command.Parameters.AddWithValue("@Cart_User_ID", item.Cart_User_ID);

            Notify = command.ExecuteNonQuery();

            connection.Close();
            //1 row added
            return Notify;
        }

        public int Update(Cart item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            int Notify = 0;

            connection.Open();

            //Update
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Cart SET Cart.Cart_User_ID = @Cart_User_ID  WHERE Cart.Cart_ID = @Cart_ID", connection);

                command.Parameters.AddWithValue("@Cart_ID", item.Cart_ID);
                command.Parameters.AddWithValue("@Cart_User_ID", item.Cart_User_ID);

                Notify = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unidentify value to update");
            }

            connection.Close();
            return Notify;
        }

        public int Delete(Guid id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            int Notify = 0;

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(@"DELETE FROM Cart WHERE Cart.Cart_ID = @Cart_ID ");
                command.Parameters.AddWithValue("@Cart_ID", id);

               Notify = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unidentify to Delete");
            }
            connection.Close();
            return Notify;
        }
    }
}