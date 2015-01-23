using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RipeTangerines.Models.Catalog;

namespace RipeTangerines.Controllers
{
    public class CatalogController : Controller
    {
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new TopMenuModel();
            model.BlogEnabled = true;
            model.ForumEnabled = true;
            model.RecentlyAddedProductsEnabled = true;
        
            List<CategorySimpleModel> list = new List<CategorySimpleModel>();
            list.Add(new CategorySimpleModel() { Name = "苹果", SeName = "书本" });
            list.Add(new CategorySimpleModel() { Name = "橘子", SeName = "书本" });
            list.Add(new CategorySimpleModel() { Name = "香蕉", SeName = "书本" });
            list.Add(new CategorySimpleModel() { Name = "西瓜", SeName = "书本" });

            CategorySimpleModel simple = new CategorySimpleModel() { Name = "葡萄", SeName = "sdf" };
            simple.SubCategories = new List<CategorySimpleModel>();
            simple.SubCategories.Add(new CategorySimpleModel() { Name = "爱丽可", SeName = "dsff" });
            simple.SubCategories.Add(new CategorySimpleModel() { Name = "红富士", SeName = "dsff" });
            simple.SubCategories.Add(new CategorySimpleModel() { Name = "红宝石无核", SeName = "dsff" });
            simple.SubCategories.Add(new CategorySimpleModel() { Name = "甲州三尺", SeName = "dsff" });
            list.Add(simple);

            model.Categories = list;
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
    }
}
