using System.Web.Mvc;

namespace THDShop.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manager",
                "Manager/{controller}/{action}/{id}",
                new {  action = "Index", id = UrlParameter.Optional }              
            );
        }
    }
}