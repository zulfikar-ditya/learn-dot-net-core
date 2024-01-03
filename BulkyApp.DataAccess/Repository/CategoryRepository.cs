using BulkyApp.DataAccess.Data;
using BulkyApp.DataAccess.Repository.Interfaces;
using BulkyApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyApp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, CategoryRepositoryInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            _dbContext.Update(category);
        }
    }
}
