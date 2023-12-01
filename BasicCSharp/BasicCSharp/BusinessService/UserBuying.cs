using basic_csharp.SQLAdapter;
using BasicCSharp.Object;

namespace BasicCSharp.BusinessService
{
    public class UserBuying
    {
        private readonly OrderSQLAdapter _Order_Adapter;
        private readonly CartSQLAdapter _Cart_Adapter;
        private readonly ProductSQLAdapter _Product_Adapter;
        private readonly Users _User;
        private readonly Cart _Cart;
        private readonly string SQL_Connection = @"Data Source= sql.bsite.net\MSSQL2016 ;Initial Catalog=tuanph108_;User ID=tuanph108_;Password=Tuan01082002;TrustServerCertificate=True";
        
        public UserBuying(Users user)
        {
            _Order_Adapter = new OrderSQLAdapter(SQL_Connection);
            _Cart_Adapter = new CartSQLAdapter(SQL_Connection);
            _Product_Adapter = new ProductSQLAdapter(SQL_Connection);
            _User = user;
            _Cart = new Cart() {Cart_User_ID = _User.User_ID };
            _Cart_Adapter.Insert(_Cart);
        }

        //User order item
        public void Order(List<Product> listProduct)
        {
            //Create Obj
            foreach(Product item in listProduct)
            {
                Orders tmpOrder = new Orders()
                {
                    Orders_User_ID = _User.User_ID,
                    Orders_Product_ID = item.Product_ID
                };
                //Adding to DB
                _Order_Adapter.Insert(tmpOrder);
            }
        }
        
        //User view Cart 
        public void ViewCart()
        {
            Console.WriteLine("Order Selected : \n\n\n");
            Product tmpProduct = new Product();
            foreach(Orders order in _Order_Adapter.GetData(_User.User_ID)) //Overload GetData method of Order Adapter
            {
                foreach(Product product in _Product_Adapter.GetData())
                {
                    Guid tmpID = product.Product_ID;
                    if ( tmpID.CompareTo(order.Orders_Product_ID) == 0 ) 
                    {
                        tmpProduct =product;
                        break;
                    }
                }
                Console.WriteLine($"{order.Orders_ID}, {tmpProduct.Product_Name}");        
            }
        }

    }
}
