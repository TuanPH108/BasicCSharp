using BasicCSharp.Object;
using Microsoft.Data.SqlClient;
using System.Data;

namespace basic_csharp.SQLAdapter
{
    public class ProductSQLAdapter : ISQLAdapter<Product>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public ProductSQLAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "Products";
        }

        public List<Product> GetData()
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Products", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            List<Product> products_Selected = new List<Product>();

            foreach (DataRow row in temp_table.Rows)
            {
                Product temp_product = new Product();
                
                temp_product.Product_ID = (Guid)row["Product_ID"];
                temp_product.Product_Name = (string)row["Name"];
                temp_product.Product_Version = (string)row["Version"];
                temp_product.Product_Price = float.Parse((string)row["Price"]);
                temp_product.Product_Category = (string)row["Category"];
                temp_product.Product_Description = (string)row["Description"];
                temp_product.Product_Type = (string)row["Type"];



                products_Selected.Add(temp_product);
            }
            connection.Close();
            return products_Selected;
        }

        public Product Get(Guid id)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Products", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            Product temp_product = new Product();

            foreach (DataRow row in temp_table.Rows)
            {
                if (id.CompareTo((Guid)row["Product_ID"]) == 0)
                {
                    temp_product.Product_ID = (Guid)row["Product_ID"];
                    temp_product.Product_Name = (string)row["Product_Name"];
                    temp_product.Product_Description = (string)row["Product_Description"];
                    temp_product.Product_Type = (string)row["Product_Type"];
                    temp_product.Product_Price = float.Parse((string)row["Product_Price"]);
                    temp_product.Product_Category = (string)row["Product_Category"];
                    temp_product.Product_Version = (string)row["Product_Version"];

                }
            }
            connection.Close();
            return temp_product;
        }

        public int Insert(Product item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();
            int Notify = 0;
            //Insert Data
            string stringQuery = "INSERT INTO Products (Product_Name, Product_Description, Product_Category, Product_Version, Product_Type, Product_Price) " +
                "VALUES (@Product_Name, @Product_Description, @Product_Category, @Product_Version, @Product_Type, @Product_Price)";
            SqlCommand command = new SqlCommand(stringQuery, connection);

            command.Parameters.AddWithValue("@Product_Name", item.Product_Name);
            command.Parameters.AddWithValue("@Product_Description", item.Product_Description);
            command.Parameters.AddWithValue("@Product_Type", item.Product_Type);
            command.Parameters.AddWithValue("@Product_Price", item.Product_Price);
            command.Parameters.AddWithValue("@Product_Category", item.Product_Category);
            command.Parameters.AddWithValue("@Product_Version", item.Product_Version);


            Notify = command.ExecuteNonQuery();

            connection.Close();
            //1 row added
            return Notify;
        }

        public int Update(Product item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();
            int Notify = 0;
            //Update
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Products SET Products.Product_Name = @Product_Name  WHERE Products.Product_ID = @Product_ID", connection);

                command.Parameters.AddWithValue("@Product_ID", item.Product_ID);
                command.Parameters.AddWithValue("@Product_Name", item.Product_Name);

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
                SqlCommand command = new SqlCommand(@"DELETE FROM Products WHERE Products.Product_ID = @Product_ID ", connection);
                command.Parameters.AddWithValue("@Product_ID", id);

                command.ExecuteNonQuery();
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