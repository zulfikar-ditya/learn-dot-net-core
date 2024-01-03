using BulkyApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyApp.DataAccess.Repository.Interfaces
{
    public interface CategoryRepositoryInterface : RepositoryInterface<Category>
    {
        void Update(Category category);

        void Save();
    }
}
