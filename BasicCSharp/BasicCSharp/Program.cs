using basic_csharp.SQLAdapter;
using BasicCSharp.Object;

//Connection through TCP/IP
string SQL_Connection = @"Data Source=tcp:10.88.54.21;Initial Catalog=BasicCSharp;User ID=sa;Password=Tuan01082002;
TrustServerCertificate=True
";


UserSQLAdapter User_Adapter = new UserSQLAdapter(SQL_Connection);

//Test Get Data base on ID
Users user1 = User_Adapter.Get(Guid.Parse("e4df0fd6-384b-4d8a-8a5b-16f1117852a8"));

Console.WriteLine("#__USERS__#Select * From Users Where Users.User_ID = .... by Get(ID) Method##\n");
Console.WriteLine($"{user1.User_ID}, {user1.User_Name}, {user1.User_Birthday}, {user1.User_Email}, {user1.User_Contact}");


Users insertUser = new Users();

insertUser.User_Name = "Phan Hoang Tuan";
insertUser.User_Birthday = "01-08-2002";
insertUser.User_Email = "TuanPH108@gmail.com";
insertUser.User_Contact = "0857788086";

Console.WriteLine($"____Test Object in Program.cs ____{insertUser.User_ID}, {insertUser.User_Name}, {insertUser.User_Birthday}, {insertUser.User_Contact}, {insertUser.User_Email} \n\n");

int insertRow = User_Adapter.Insert(insertUser);

Console.WriteLine("\n#__USER__##Insert into Users ==> " + insertRow + " row was added");



//Test Get All Data Table
Console.WriteLine("\n#__USERS__#Select * From Users by GetData() Method##\n");
int count = 0;
foreach (Users user in User_Adapter.GetData())
{
    count = count + 1;
    Console.WriteLine($" {count}: {user.User_ID}, {user.User_Name}, {user.User_Birthday}, {user.User_Email}, {user.User_Contact} \n");
}


/*


//Test Update
Console.WriteLine("\n#__USER__##UPDATE Users ==> " + User_Adapter.Update(insertUser) + " row was updated");



*/