using BasicCSharp.Object;

namespace basic_csharp.SQLAdapter
{
    public class ProductSQLAdapter : ISQLAdapter<Product>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public ProductSQLAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "PRODUCT";
        }

        public List<Product> GetData()
        {
            throw new NotImplementedException();
        }

        public Product Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product item)
        {
            throw new NotImplementedException();
        }

        public int Update(Product item)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}