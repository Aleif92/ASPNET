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
}