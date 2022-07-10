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

        public Product AssignCategory()
        {
            var categoryList=GetCategories();
            var product=new Product();
            product.Categories = categoryList;
            return product;
            
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * from products");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("Select * from categories;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("Select * from Products where ProductID=@id", new {id=id});
        }

        public void InsertProduct(Product product)
        {
            _conn.Execute("INSERT INTO `bestbuy`.`products`(`ProductID`,`Name`, `Price`, `CategoryID`, `OnSale`, `StockLevel`) VALUES ( @productID, @name, @price, @categoryID, @onSale, @stockLevel);"
    , new { productID = product.ProductID, name = product.Name, price = product.Price, categoryID = product.CategoryID, onSale = product.OnSale, stockLevel = product.StockLevel });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("Update products set Name=@name, Price=@price where productID=@productID", new { name=product.Name, price=product.Price, productID = product.ProductID });
        }
    }
}
