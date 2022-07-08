using Dapper;
using System.Collections.Generic;
using System.Data;
using Testing.Models;

namespace Testing
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * from products");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("Select * from Products where ProductID=@id", new {id=id});
        }
    }
}
