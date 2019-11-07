using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using wangyou.Models;
using System.Data;
namespace wangyou.Controllers
{
    public class InfoController : Controller
    {
        //
        // GET: /Info/

        public ActionResult Info(int? id)
        {

            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                IEnumerable<WenZhang> wz = db.WenZhang.ToList();
                viewModel models = new viewModel();

                var wenz = db.WenZhang.Find(id);
                ViewBag.wenzhangBiaoTI = wenz.wenzhangBiaoTI;
                ViewBag.wenzhangHTML = wenz.wenzhangHTML;
                ViewBag.wenzhangDateTime = wenz.wenzhangDateTime;
                ViewBag.wenzhangid = id;

                return View(models);
            }
        }


        [Authorize]
        public ActionResult Edit()
        {
            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                IEnumerable<WenZhang> wz = db.WenZhang.ToList();
                viewModel models = new viewModel();
                ViewBag.wenzhangTypeID = new SelectList(db.WanZhangType, "WenZhangTypeID", "WenZhangTypeNmae");
                return View(models);
            }

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(string biaoti, string text1,string text2)
        {
            if (text1 == null)
            {
                return Content("提交失败");
            }
            else
            {
                WenZhang wenz = new WenZhang()
                {
                    wenzhangID = 1,//id    
                    wenzhangDateTime = System.DateTime.Now,//sj
                    wenzhangImg = "images/t02.jpg",//默认图片
                    wenzhangBiaoTI = biaoti,
                    wenzhangContent = text2,
                     wenzhangHTML= text1,

                    wenzhangTypeID = 2,

                };
                using (WangYouBKEntities db = new WangYouBKEntities())
                {
                    db.WenZhang.Add(wenz);
                    db.SaveChanges();
                }
                return Content("<script>alert('"+ biaoti + "');history.go(-1);</script>");
            }

        }


        public ActionResult xiangce()
        {
            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                IEnumerable<WenZhang> wz = db.WenZhang.ToList();
                viewModel models = new viewModel();
                ViewBag.wenzhangTypeID = new SelectList(db.WanZhangType, "WenZhangTypeID", "WenZhangTypeNmae");
                return View(models);
            }

        }

        public ActionResult meiri()
        {
            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                IEnumerable<WenZhang> wz = db.WenZhang.ToList();
                viewModel models = new viewModel();
                ViewBag.wenzhangTypeID = new SelectList(db.WanZhangType, "WenZhangTypeID", "WenZhangTypeNmae");
                return View(models);



            }

        }


    }
}
