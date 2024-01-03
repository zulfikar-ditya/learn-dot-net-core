using System.Linq.Expressions;
using BulkyApp.Models.Models;

namespace BulkyApp.DataAccess.Repository.Interfaces;

public interface ProductRepositoryInterface : RepositoryInterface<Product>
{
    void Update(Product product);

    void Save();
}