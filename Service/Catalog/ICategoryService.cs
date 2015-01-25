

using Core.Domain.Catalog;
using System;
using System.Collections.Generic;
namespace Service.Catalog
{
    public partial interface ICategoryService
    {
        /// <summary>
        /// 获得在主页显示的产品种类
        /// </summary>
        /// <returns></returns>
        IList<Category> GetAllCategoriesDisplayedOnHomePage();

        IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden = false);
    }
}
