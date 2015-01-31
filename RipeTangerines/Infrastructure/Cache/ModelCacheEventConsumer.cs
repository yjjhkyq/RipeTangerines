using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RipeTangerines.Infrastructure.Cache
{
    public partial class ModelCacheEventConsumer
    {
        /// <summary>
        /// Key for TopMenuModel caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : comma separated list of customer roles
        /// {2} : current store ID
        /// </remarks>
        public const string CATEGORY_MENU_MODEL_KEY = "Nop.pres.category.menu";
        public const string CATEGORY_MENU_PATTERN_KEY = "Nop.pres.category.menu";
    }
}