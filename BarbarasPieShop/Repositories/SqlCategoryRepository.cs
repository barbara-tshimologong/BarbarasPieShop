using BarbarasPieShop.Models;
using System.Collections.Generic;

namespace BarbarasPieShop.Repositories
{
    internal class SqlCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => throw new System.NotImplementedException();

        public Category GetCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public string GetCategoryName(int categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}