using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wangyou.Models;
namespace wangyou.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {


            var name = User.Identity.Name;//获取cookin
            ViewBag.name = name;
            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                IEnumerable<WenZhang> wz = db.WenZhang.ToList();
                viewModel models = new viewModel();
                return View(models);
            }
        }

        //public ActionResult Index2()
        //{
        //    using (WangYouBKEntities db = new WangYouBKEntities())
        //    {
        //        IEnumerable<WenZhang> wz = db.WenZhang.ToList();
        //        viewModel models = new viewModel();
        //        return View(models);
        //    }
        //}

        //public ActionResult Info()
        //{
        //    using (WangYouBKEntities db = new WangYouBKEntities())
        //    {
        //        IEnumerable<WenZhang> wz = db.WenZhang.ToList();
        //        viewModel models = new viewModel();
        //        return View(models);
        //    }
        //}



        //个人中心
        public ActionResult MyInfo()
        {

            return View();
        }




    }
}
