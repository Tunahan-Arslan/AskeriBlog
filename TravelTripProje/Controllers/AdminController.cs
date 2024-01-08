using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogListele()
        {
            var bloglar = c.Blogs.OrderBy(x => x.ID).ToList();
            return View(bloglar);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Baslik = b.Baslik;
            blg.Aciklama = b.Aciklama;
            blg.Tarih = b.Tarih;
            blg.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListele()
        {
            var yorumlar = c.Yorumlars.OrderBy(x => x.Blog.Baslik).ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListele");
        }
        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            return View("YorumGetir", yrm);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListele");
        }
        public ActionResult Iletisim()
        {
            var iletisim = c.Iletisims.ToList();
            return View(iletisim);
        }
        public ActionResult IletisimSil(int id)
        {
            var i = c.Iletisims.Find(id);
            c.Iletisims.Remove(i);
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }
        public ActionResult Hakkimizda()
        {
            var hakkimizda = c.Hakkimizdas.ToList();
            return View(hakkimizda);
        }
        public ActionResult HakkimizdaGetir(int id)
        {
            var hk = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", hk);
        }
        public ActionResult HakkimdaGuncelle(Hakkimizda h)
        {
            var hk = c.Hakkimizdas.Find(h.ID);
            hk.Aciklama = h.Aciklama;
            hk.FotoUrl = h.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
    }
}