using BulkyApp.DataAccess.Data;
using BulkyApp.DataAccess.Repository.Interfaces;
using BulkyApp.Models.Models;
using System.Linq.Expressions;

namespace BulkyApp.DataAccess.Repository;

public class ProductRepository : Repository<Product>, ProductRepositoryInterface
{

    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext _db): base(_db)
    {
        _dbContext = _db;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void Update(Product product)
    {
        _dbContext.Update(product);
    }
} 