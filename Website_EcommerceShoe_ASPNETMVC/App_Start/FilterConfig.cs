﻿using System.Web;
using System.Web.Mvc;

namespace Website_EcommerceShoe_ASPNETMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
