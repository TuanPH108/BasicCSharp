namespace basic_csharp.SQLAdapter
{
    /// <summary>
    /// SQL Adapter Interface
    /// </summary>
    public interface ISQLAdapter<T> where T : class, new()
    {
        public string ConnectionString { get; set; }

        public string TableName { get; set; }

        List<T> GetData();

        T Get(Guid id);

        int Insert(T item);

        int Update(T item);

        int Delete(Guid id);
    }
}