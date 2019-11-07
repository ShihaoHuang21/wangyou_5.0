using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using wangyou.Models;
namespace wangyou.Controllers
{
    public class AccountController : Controller
    {


        //授权访问
        //get请求/account/Index
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        //
        //
        // GET: /Account/
        public ActionResult Login()
        {


            return View();

        }

        public ActionResult zx()
        {

            Session.Abandon();
            //删除用户票据
            FormsAuthentication.SignOut();
            //重新定向到登陆页面
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("login");

        }




        [HttpPost]
        public ActionResult Login(bk_users user)
        {
            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                if (user.u_email == "admin" && user.u_pwd == "admin")
                {
                    return RedirectToAction("kuang", "Houtai");

                }


                else
                {
                    if (ModelState.IsValid)
                    {
                        string id1 = "";
                        var u = db.bk_users.FirstOrDefault(x => x.u_email == user.u_email && x.u_pwd == user.u_pwd);
                        if (u == null)
                        {
                            ModelState.AddModelError("", "邮箱或密码错误！");
                        }
                        else
                        {

                            using (WangYouBKEntities db1 = new WangYouBKEntities())
                            {
                                var user1 = db.bk_users.Where(p => p.u_email == user.u_email);
                                foreach (var item in user1)
                                {
                                    id1 = item.userid.ToString();
                                }
                            }
                            FormsAuthentication.SetAuthCookie(id1, false);

                            return RedirectToAction("index", "Home");
                        }

                    }

                }




            }
            return View();
        }







        //访问数据库，验证用户登录信息，并使用Forms验证
        private bool ValidateUser(string u_email, string u_pwd)
        {
            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                var u = (from p in db.bk_users where p.u_email == u_email && p.u_pwd == u_pwd select p).FirstOrDefault();
                if (u == null)
                {
                    return false;
                }
                else
                {

                    //FormAuthentication.SetAuthCookie(u_email,false);
                    return true;
                    //return RedirectToAction("Index","Home");
                }
            }
        }



        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        // GET: /reg/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /reg/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(bk_users bk_users)
        {
            using (WangYouBKEntities db = new WangYouBKEntities())
            {
                if (ModelState.IsValid)
                {
                    db.bk_users.Add(bk_users);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Account");
                }
                return View(bk_users);
            }
        }



    }
}
