using System.Collections.Generic;
using System.Linq;

namespace wangyou.Models
{
    public class viewModel
    {
        public string Name { get; set; }
        public IEnumerable<WenZhang> WenZhang { get; set; }
        public IEnumerable<WanZhangType> WanZhangType { get; set; }
        public IEnumerable<bk_users> bk_users { get; set; }
        //前5条排行表
        public List<WenZhang> WenZhangjx { get; set; }
       public  WenZhang sousu { get; set; }
        public viewModel()
        {

            WangYouBKEntities db = new WangYouBKEntities();
            this.WenZhang = db.WenZhang.ToList();
            this.WanZhangType = db.WanZhangType.ToList();
            this.bk_users = db.bk_users.ToList();



            this.WenZhangjx = ((from p in WenZhang orderby p.wenzhangID descending select p).Take(5)).ToList();
           
        }

        public class Sample {
            public string Name { get; set; }
        }

    }
}