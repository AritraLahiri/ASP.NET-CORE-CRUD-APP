using System.Collections.Generic;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Add()
        {
            List<DataAccessLibrary.Models.Hobby> hobbyList = ProcessData.GetHobbies();
            List<Hobby> hobby = new List<Hobby>();
            foreach (DataAccessLibrary.Models.Hobby hb in hobbyList)
            {
                hobby.Add(new Hobby()
                {
                    Id = hb.Id,
                    Name = hb.Name
                });
            }
            ViewBag.data = hobby;
            return View(hobby);

            return View();
        }





    }
}