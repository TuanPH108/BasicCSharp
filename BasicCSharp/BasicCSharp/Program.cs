using basic_csharp.SQLAdapter;
using BasicCSharp.Object;
using BasicCSharp.TestAdapter;
using BasicCSharp.BusinessService;

//Connection hosting online
string SQL_Connection = @"Data Source= sql.bsite.net\MSSQL2016 ;Initial Catalog=tuanph108_;User ID=tuanph108_;Password=Tuan01082002;
TrustServerCertificate=True";


/*//Testing User Adapter
UsersAdapterTesting UserTest = new UsersAdapterTesting(SQL_Connection);
Console.WriteLine("Testing Users Adapter Process");
UserTest.display();
*/


//Business Service
Console.WriteLine("\nTesting BusinessService");
Users BuyingUser = new Users()
{
    User_Name = "Phan Hoang Tuan",
    User_Birthday = "2002/08/01",
    User_Contact = "0857788086",
    User_Email = "TuanPH108@gmail.com"
};

//Create new buying transaction
UserBuying NewBuyingTransaction = new UserBuying(BuyingUser);

//Create Product
Product product1 = new Product() { Product_Name = "Iphone xs max" };
Product product2 = new Product() { Product_Name = "Samsung Galaxy S3" };
Product product3 = new Product() { Product_Name = "Airpod pro 3" };

//Add to list product ordered
List<Product> ListProductOrder = new List<Product>();
ListProductOrder.Add(product1);
ListProductOrder.Add(product2);
ListProductOrder.Add(product3);

NewBuyingTransaction.Order(ListProductOrder);

NewBuyingTransaction.ViewCart();

