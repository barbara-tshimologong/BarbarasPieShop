using BarbarasPieShop.Models;
using System;
using System.Collections.Generic;

namespace BarbarasPieShop.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }

        Category GetCategory(int categoryId);

        String GetCategoryName(int categoryId);

    }
}
