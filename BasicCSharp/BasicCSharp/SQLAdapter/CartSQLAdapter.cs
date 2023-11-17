using BasicCSharp.Object;

namespace basic_csharp.SQLAdapter
{
    public class CartSQLAdapter : ISQLAdapter<Cart>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public CartSQLAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "CART";
        }

        public List<Cart> GetData()
        {
            throw new NotImplementedException();
        }

        public Cart Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Cart item)
        {
            throw new NotImplementedException();
        }

        public int Update(Cart item)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}