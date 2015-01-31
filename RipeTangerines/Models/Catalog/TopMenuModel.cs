using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RipeTangerines.Models.Catalog
{
    public partial class TopMenuModel
    {
        public TopMenuModel()
        {
            Categories = new List<CategorySimpleModel>();
        }

        public IList<CategorySimpleModel> Categories { get; set; }

        public bool BlogEnabled { get; set; }
        public bool RecentlyAddedProductsEnabled { get; set; }
        public bool ForumEnabled { get; set; }
    }
}