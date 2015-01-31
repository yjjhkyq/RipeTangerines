using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RipeTangerines.Models.Catalog
{
    public partial class SearchBoxModel
    {
        public bool AutoCompleteEnabled { get; set; }
        public bool ShowProductImagesInSearchAutoComplete { get; set; }
        public int SearchTermMinimumLength { get; set; }
    }
}