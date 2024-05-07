using System;
using System.Web;
using System.Web.Routing;

namespace PUXTask
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Kód, který je spuštěn při spuštění aplikace
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}