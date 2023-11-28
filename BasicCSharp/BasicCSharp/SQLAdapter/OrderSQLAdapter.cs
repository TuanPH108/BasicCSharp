using BasicCSharp.Object;
using Microsoft.Data.SqlClient;
using System.Data;

namespace basic_csharp.SQLAdapter
{
    public class OrderSQLAdapter : ISQLAdapter<Orders>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public OrderSQLAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "Orders";
        }

        public List<Orders> GetData()
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Orders", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            List<Orders> Orders_Selected = new List<Orders>();

            foreach (DataRow row in temp_table.Rows)
            {
                Orders temp_orders = new Orders();
                temp_orders.Orders_ID = (Guid)row["Orders_ID"];
                temp_orders.Orders_User_ID = (Guid)row["Orders_User_ID"];
                temp_orders.Orders_Product_ID = (Guid)row["Orders_Product_ID"];
                Orders_Selected.Add(temp_orders);
            }
            connection.Close();
            return Orders_Selected;
        }

        public Orders Get(Guid id)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Orders", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            Orders temp_orders = new Orders();

            foreach (DataRow row in temp_table.Rows)
            {
                if (id.CompareTo((Guid)row["Orders_ID"]) == 0)
                {
                    temp_orders.Orders_ID = (Guid)row["Orders_ID"];
                    temp_orders.Orders_User_ID = (Guid)row["Orders_User_ID"];
                    temp_orders.Orders_Product_ID = (Guid)row["Orders_Product_ID"];

                }
            }
            connection.Close();
            return temp_orders;
        }

        public int Insert(Orders item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);


            //Insert Data
            string stringQuery = "INSERT INTO Users ( Orders_ID, Orders_User_ID, Orders_Product_ID) " +
                "VALUES ( @Orders_ID, @Orders_User_ID, @Orders_Product_ID)";
            SqlCommand command = new SqlCommand(stringQuery, connection);

            command.Parameters.AddWithValue("@Orders_ID", item.Orders_ID);
            command.Parameters.AddWithValue("@Orders_User_ID", item.Orders_User_ID);
            command.Parameters.AddWithValue("@Orders_Product_ID", item.Orders_Product_ID);

            command.ExecuteNonQuery();

            adapter.InsertCommand = command;

            

            connection.Close();
            //1 row added
            return 1;
        }

        public int Update(Orders item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Update
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Orders SET Orders.Orders_User_ID = @Orders_User_ID  WHERE Orders.Orders_ID = @Orders_ID", connection);

                adapter.TableMappings.Add("Table", TableName);

                command.Parameters.AddWithValue("@Orders_ID", item.Orders_ID);
                command.Parameters.AddWithValue("@Orders_User_ID", item.Orders_User_ID);

                command.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unidentify value to update");
            }
            return 1;
        }

        public int Delete(Guid id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(ConnectionString);
            adapter.TableMappings.Add("Table", TableName);

            try
            {
                SqlCommand command = new SqlCommand(@"DELETE FROM Orders WHERE Orders.Orders_ID = @Orders_ID ");
                command.Parameters.AddWithValue("@Orders_ID", id);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unidentify to Delete");
            }
            return 1;
        }
    }
}