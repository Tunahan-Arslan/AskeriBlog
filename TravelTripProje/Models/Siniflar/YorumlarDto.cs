using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class YorumlarDto
    {
        public int ID { get; set; }
        public HttpPostedFileBase KullaniciFoto { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int Blogid { get; set; }
    }
}