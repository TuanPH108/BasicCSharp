using System.Data;
using System.Reflection.Metadata;
using BasicCSharp.Object;
using Microsoft.Data.SqlClient;

namespace basic_csharp.SQLAdapter
{
    public class UserSQLAdapter : ISQLAdapter<Users>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public UserSQLAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "USERS";
        }

        public List<Users> GetData()
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Users", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            List<Users> User_Selected = new List <Users>();
            foreach(DataRow row in temp_table.Rows)
            {
                Users temp_user = new Users();
                temp_user.User_ID = (Guid) row["User_ID"];
                temp_user.User_Name = (string)row["User_Name"];
                temp_user.User_Birthday = (string)row["User_Birthday"];
                temp_user.User_Email = (string)row["User_Email"];
                temp_user.User_Contact = (string)row["User_Contact"];
                User_Selected.Add(temp_user);
            }
            connection.Close();
            return User_Selected;
        }

        public Users Get(Guid id) 
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Mapping and Filling Data
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);
            adapter.SelectCommand = new SqlCommand(@"Select * From Users", connection);

            DataTable temp_table = new DataTable();
            adapter.Fill(temp_table);

            //Solving
            Users temp_user = new Users();

            foreach (DataRow row in temp_table.Rows)
            {
                if ( id == (Guid) row["User_ID"])
                {
                    temp_user.User_ID = (Guid) row["User_ID"];
                    temp_user.User_Name = (string)row["User_Name"];
                    temp_user.User_Birthday = (string)row["User_Birthday"];
                    temp_user.User_Email = (string)row["User_Email"];
                    temp_user.User_Contact = (string)row["User_Contact"];
                }
            }
            connection.Close();
            return temp_user;
        }

        public int Insert(Users item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", TableName);

            //Insert Data
            SqlCommand command = new SqlCommand("INSERT INTO Users (User_ID, User_Name, User_Birthday, User_Email, User VALUES(@User_ID, @User_Name, @User_Birthday, @User_Email, @User_Contact", connection);

            adapter.InsertCommand.Parameters.Add("@User_ID", SqlDbType.UniqueIdentifier, default, item.User_ID.ToString() );
            adapter.InsertCommand.Parameters.Add("@User_Name", SqlDbType.VarChar, 100, item.User_Name);
            adapter.InsertCommand.Parameters.Add("@User_Birthday", SqlDbType.VarChar, 20, item.User_Birthday);
            adapter.InsertCommand.Parameters.Add("@User_Email", SqlDbType.VarChar, 100, item.User_Email);
            adapter.InsertCommand.Parameters.Add("@User_Contact", SqlDbType.VarChar, 20, item.User_Contact);

            adapter.InsertCommand = command;


            connection.Close();
            //1 row added
            return 1;
        }

        public int Update(Users item)
        {
            //Set up Connection
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Update
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.TableMappings.Add("Table", TableName);
            adapter.UpdateCommand = new SqlCommand("UPDATE Users SET Users.User_Email = @User_Email  WHERE Users.Users_ID = @User_ID",connection);

            adapter.UpdateCommand.Parameters.Add("@User_Email", SqlDbType.VarChar, 100, item.User_Email);
            adapter.UpdateCommand.Parameters.Add("@User_ID", SqlDbType.VarChar, 100, $"{item.User_ID}");
               


            


            connection.Close();

            return 1;
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}