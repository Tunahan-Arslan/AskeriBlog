using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return View(by);
        }
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return View(by);
        }

        [HttpPost()]
        public ActionResult AddYorum([Form] YorumlarDto yorumlar)
        {
            var dosya = yorumlar.KullaniciFoto;

            if (dosya != null)
            {
                var yuklenenDosyaYolu = Path.Combine(Server.MapPath("/image/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(yuklenenDosyaYolu);

                yuklenenDosyaYolu=yuklenenDosyaYolu.Replace("C:\\Users\\MONSTER\\OneDrive\\Masaüstü\\MVC Projesi\\TravelTripProje\\TravelTripProje", "");
                yuklenenDosyaYolu = yuklenenDosyaYolu.Replace("\\", "/");

                //C:\Users\MONSTER\OneDrive\Masaüstü\MVC Projesi\TravelTripProje\TravelTripProje\image\poh2.gif
                var entity2 = new Yorumlar
                {
                    Blogid = yorumlar.Blogid,
                    ID = yorumlar.ID,
                    KullaniciAdi = yorumlar.KullaniciAdi,
                    Yorum = yorumlar.Yorum,
                    Mail = yorumlar.Mail,
                    KullaniciFoto = yuklenenDosyaYolu
                };
                c.Yorumlars.Add(entity2);
                c.SaveChanges();

            }

            else
            {
                var entity = new Yorumlar
                {
                    Blogid = yorumlar.Blogid,
                    ID = yorumlar.ID,
                    KullaniciAdi = yorumlar.KullaniciAdi,
                    Yorum = yorumlar.Yorum,
                    Mail = yorumlar.Mail,
                    KullaniciFoto = ""
                };
                c.Yorumlars.Add(entity);
                c.SaveChanges();
            }
            return Redirect("/Blog/BlogDetay/" + yorumlar.Blogid);
        }


    }
}