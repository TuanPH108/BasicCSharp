using BasicCSharp.Object;

namespace basic_csharp.SQLAdapter
{
    public class OrderSQLAdapter : ISQLAdapter<Orders>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public OrderSQLAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "ORDERS";
        }

        public List<Orders> GetData()
        {
            throw new NotImplementedException();
        }

        public Orders Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Orders item)
        {
            throw new NotImplementedException();
        }

        public int Update(Orders item)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}