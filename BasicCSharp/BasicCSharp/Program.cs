using basic_csharp.SQLAdapter;
using BasicCSharp.Object;

//Connection through TCP/IP
string SQL_Connection = @"Data Source=tcp:10.88.54.12;Initial Catalog=BasicCSharp;User ID=sa;Password=Tuan01082002;
TrustServerCertificate=True
";


UserSQLAdapter User_Adapter = new UserSQLAdapter(SQL_Connection);
CartSQLAdapter Cart_Adapter = new CartSQLAdapter(SQL_Connection);
OrderSQLAdapter Order_Adapter = new OrderSQLAdapter(SQL_Connection);
ProductSQLAdapter Product_Adapter = new ProductSQLAdapter(SQL_Connection);





