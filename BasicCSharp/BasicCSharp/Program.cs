using basic_csharp.SQLAdapter;
using BasicCSharp.Object;
using BasicCSharp.Testing;
using Microsoft.Data.SqlClient;
using System.Data;

//Connection through TCP/IP
string SQL_Connection = @"Data Source=tcp:192.168.1.9;Initial Catalog=BasicCSharp;User ID=sa;Password=Tuan01082002;
TrustServerCertificate=True
";



//Testing 1 
TestUserAdapter userTest1 = new TestUserAdapter();

userTest1.test(SQL_Connection);
