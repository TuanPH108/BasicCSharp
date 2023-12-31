﻿using System.Data;
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
			this.TableName = "Users";
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
				if ( id.CompareTo((Guid) row["User_ID"]) == 0)
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

		public int Insert (Users item)
		{
			//Set up Connection
			SqlConnection connection = new SqlConnection(ConnectionString);

			connection.Open();

			//Insert Data
			string stringQuery = "INSERT INTO Users ( User_Name, User_Birthday, User_Email, User_Contact) " +
				"VALUES ( @UserName, @UserBirthday, @UserEmail, @UserContact)";
            SqlCommand command = new SqlCommand(stringQuery, connection);

			command.Parameters.AddWithValue("@UserName", item.User_Name);
            command.Parameters.AddWithValue("@UserBirthday", item.User_Birthday);
            command.Parameters.AddWithValue("@UserEmail", item.User_Email);
            command.Parameters.AddWithValue("@UserContact", item.User_Contact);

            int Notify = command.ExecuteNonQuery();

            connection.Close();
			//1 row added
			return Notify;
		}

		public int Update(Users item)
		{
			//Set up Connection
			SqlConnection connection = new SqlConnection(ConnectionString);
			int Notify = 0;
			connection.Open();

			//Update
			try
			{
                SqlCommand command = new SqlCommand("UPDATE Users SET Users.User_Email = @User_Email  WHERE Users.User_Name = @User_Name", connection);

                command.Parameters.AddWithValue("@User_Email", item.User_Email);
                command.Parameters.AddWithValue("@User_Name", item.User_Name);

                Notify = command.ExecuteNonQuery();

                connection.Close();
            }
			catch(Exception ex) 
			{
				Console.WriteLine("Unidentify value to update");
            }
            return Notify;
        }

		public int Delete(Guid id)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);
			string DeleteQuery = "DELETE FROM  Users WHERE Users.User_ID = @User_ID";

			connection.Open();

            int Notify = 0;
			try
			{
				SqlCommand command = new SqlCommand(DeleteQuery, connection);
				command.Parameters.AddWithValue("@User_ID", id);

				Notify = command.ExecuteNonQuery();
				connection.Close();
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.ToString());
			}

			connection.Close();
			return Notify;
		}
    }
}