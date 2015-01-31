using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RipeTangerines.Models.Catalog;
using Service.Catalog;
using RipeTangerines.Infrastructure.Cache;
using Core.Caching;

namespace RipeTangerines.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICacheManager _cacheManager;

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            string cacheKey = string.Format(ModelCacheEventConsumer.CATEGORY_MENU_MODEL_KEY);
            var cachedModel = _cacheManager.Get(cacheKey, () =>
            {
                return PrepareCategorySimpleModels(0, null, 0, 3, true).ToList();
            });

            var model = new TopMenuModel()
            {
                Categories = cachedModel,
                RecentlyAddedProductsEnabled = true,
                BlogEnabled = true,
                ForumEnabled = true

            };
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult SearchBox()
        {
            var model = new SearchBoxModel()
            {
                AutoCompleteEnabled = true,
                ShowProductImagesInSearchAutoComplete = false,
                SearchTermMinimumLength = 3
            };
            return PartialView(model);
        }

        public ActionResult Category(int categoryId)
        {
            return View();
        }

        /// <summary>
        /// Prepare category (simple) models
        /// </summary>
        /// <param name="rootCategoryId">Root category identifier</param>
        /// <param name="loadSubCategoriesForIds">Load subcategories only for the specified category IDs; pass null to load subcategories for all categories</param>
        /// <param name="level">Current level</param>
        /// <param name="levelsToLoad">A value indicating how many levels to load (max)</param>
        /// <param name="validateIncludeInTopMenu">A value indicating whether we should validate "include in top menu" property</param>
        /// <returns>Category models</returns>
        [NonAction]
        protected IList<CategorySimpleModel> PrepareCategorySimpleModels(int rootCategoryId,
            IList<int> loadSubCategoriesForIds, int level, int levelsToLoad, bool validateIncludeInTopMenu)
        {
            var result = new List<CategorySimpleModel>();
            foreach (var category in _categoryService.GetAllCategoriesByParentCategoryId(rootCategoryId))
            {
                if (validateIncludeInTopMenu && !category.IncludeInTopMenu)
                {
                    continue;
                }

                var categoryModel = new CategorySimpleModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                   
                };

                ////product number for each category
                //if (_catalogSettings.ShowCategoryProductNumber)
                //{
                //    categoryModel.NumberOfProducts = GetCategoryProductNumber(category.Id);
                //}

                //load subcategories?
                bool loadSubCategories = false;
                if (loadSubCategoriesForIds == null)
                {
                    //load all subcategories
                    loadSubCategories = true;
                }
                else
                {
                    //we load subcategories only for certain categories
                    for (int i = 0; i <= loadSubCategoriesForIds.Count - 1; i++)
                    {
                        if (loadSubCategoriesForIds[i] == category.Id)
                        {
                            loadSubCategories = true;
                            break;
                        }
                    }
                }
                if (levelsToLoad <= level)
                {
                    loadSubCategories = false;
                }
                if (loadSubCategories)
                {
                    var subCategories = PrepareCategorySimpleModels(category.Id, loadSubCategoriesForIds, level + 1, levelsToLoad, validateIncludeInTopMenu);
                    categoryModel.SubCategories.AddRange(subCategories);
                }
                result.Add(categoryModel);
            }

            return result;
        }
    }
}
