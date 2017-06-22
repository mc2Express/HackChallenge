<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
=======
﻿using System.Web.Mvc;
>>>>>>> 02d8369d4c5274a86039e9f946b917038c358699
using System.Web.Routing;

namespace WebApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
