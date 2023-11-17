using basic_csharp.SQLAdapter;
using Microsoft.Data.SqlClient;
using System.Data;

//Connection through TCP/IP
var SQL_Connection = @"Data Source=tcp:192.168.1.9;Initial Catalog=BasicCSharp;User ID=sa;Password=Tuan01082002;
TrustServerCertificate=True
";

UserSQLAdapter User_Adapter = new UserSQLAdapter(sqlconnection);