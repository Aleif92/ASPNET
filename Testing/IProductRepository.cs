namespace Testing;
using System;
using System.Collections.Generic;
using Testing.Models;


public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    
    public Product GetProduct(int id);
    
    
    
    
    
    
    
    
}
