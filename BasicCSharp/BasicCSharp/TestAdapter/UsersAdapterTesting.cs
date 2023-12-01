using basic_csharp.SQLAdapter;
using BasicCSharp.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCSharp.TestAdapter
{
    public class UsersAdapterTesting
    {
        private string SQL_Connection = string.Empty;
        public UsersAdapterTesting(string ConnectionString) 
        {
            this.SQL_Connection = ConnectionString;
        }

        public void display()
        {
            UserSQLAdapter User_Adapter = new UserSQLAdapter(SQL_Connection);


            //Test Insert temp user
            Users tmp_user = new Users()
            {
                User_ID = Guid.NewGuid(),
                User_Name = "Phan Hoang Tuan",
                User_Birthday = "01-08-2002",
                User_Contact = "0857788086",
                User_Email = "ph.hoangtuan18@gmail.com"
            };
            Console.WriteLine("Insert " + User_Adapter.Insert(tmp_user) + " row completed\n");


            //Test Get All Records in Users Table
            Console.WriteLine("Get all records in Users table\n");
            foreach (Users user in User_Adapter.GetData())
            {
                Console.WriteLine($"{user.User_ID}, {user.User_Name}, {user.User_Birthday}, {user.User_Contact}, {user.User_Email}");
            }


            //Create obj to view 
            Users getUser = User_Adapter.Get(new Guid("32507FA7-FD94-4B06-9909-26A5A6F00CFF"));
            //Test Get User by ID
            Console.WriteLine("Get User by ID = 32507FA7-FD94-4B06-9909-26A5A6F00CFF \n");
            Console.WriteLine($"{getUser.User_ID}, {getUser.User_Name}, {getUser.User_Birthday}, {getUser.User_Contact}, {getUser.User_Email}");

            //Test Update User Email by User Name
            Console.WriteLine("Update User by Name \n");
            Users updateUser = new Users()
            {
                User_ID = Guid.NewGuid(),
                User_Name = "Phan Hoang Tuan",
                User_Birthday = "2002/08/01",
                User_Contact = "0857788086",
                User_Email = "TuanPH108@gmail.com"
            };
            Console.WriteLine("Update " + User_Adapter.Update(updateUser) + " row");

            //Review Update Record
            foreach (Users user in User_Adapter.GetData())
            {
                Console.WriteLine($"{user.User_ID}, {user.User_Name}, {user.User_Birthday}, {user.User_Contact}, {user.User_Email}");
            }



            //Test Delete User by ID
            //Create obj to view 
            Users deleteUser = User_Adapter.Get(new Guid("392E1C82-9095-4572-80FC-489D0070C9B1"));

            //Delte User
            Console.WriteLine("Delete " + User_Adapter.Delete(deleteUser.User_ID) + " row");

            //Test Get User by ID
            Console.WriteLine("Get User by ID = 392E1C82-9095-4572-80FC-489D0070C9B1 \n");
            Console.WriteLine($"{deleteUser.User_ID}, {deleteUser.User_Name}, {deleteUser.User_Birthday}, {deleteUser.User_Contact}, {deleteUser.User_Email}");
        }
    }
}
