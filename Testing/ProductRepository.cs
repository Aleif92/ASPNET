using System.Collections.Generic;
using System.Data;
using Testing.Models;
using Dapper;
namespace Testing;

public class ProductRepository: IProductRepository
{
    //Field (variable in a class)
    private readonly IDbConnection _connection;
    
    
    //Constructor    
    public ProductRepository(IDbConnection conn)
    {
        _connection = conn;
    }
    
    //Method
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
    }

    // public Product GetCategory(int id)
    // {
    //     throw new System.NotImplementedException();
    // }

    public Product GetProduct(int id)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
    }

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new {name = product.Name, price = product.Price, id = product.ProductID });
    }

    public void InsertProduct(Product productToInsert)
    {
        _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
            new {name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
    }

    public IEnumerable<Category> GetCategories()
    {
        return _connection.Query<Category>("SELECT * FROM categories;");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }
}