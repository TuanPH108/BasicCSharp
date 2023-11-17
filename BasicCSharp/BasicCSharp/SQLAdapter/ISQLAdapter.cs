namespace basic_csharp.SQLAdapter
{
    public interface ISQLAdapter
    {
        public string ConnectionString { get; set; }

        public string TableName { get; set; }

        List<T> GetData<T>() where T : class, new();

        T Get<T>(Guid id) where T : class, new();

        int Insert<T>(T item) where T : class, new();

        int Update<T>(T item) where T : class, new();

        int Delete<T>(Guid id) where T : class, new();
    }
}