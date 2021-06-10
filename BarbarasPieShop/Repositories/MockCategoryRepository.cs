using BarbarasPieShop.Models;
using System;
using System.Collections.Generic;

namespace BarbarasPieShop.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Fruit Pies", Description="All fruit fillings"},
                new Category{CategoryId=2,CategoryName="Cheese Cakes", Description="Cheesy fillings"},
                new Category{CategoryId=3,CategoryName="Seasonal Pies", Description="Seasonal fillings"}
            };

        public Category GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public string GetCategoryName(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
