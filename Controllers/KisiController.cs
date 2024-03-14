using MvcRehber.Models.Context;
using MvcRehber.Models.Entities;
using MvcRehber.Models.KisiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcRehber.Controllers
{
    public class KisiController : Controller
    {
        MvcRehberContext db = new MvcRehberContext();

        // GET: Kisi
        public ActionResult Index()
        {
            var model = new KisiIndexViewModel
            {
                Kisiler = db.Kisiler.ToList(),
                Sehirler = db.Sehirler.ToList(),
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KisiEkleViewModel
            {
                Kisi = new Kisi(),
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Ekle(Kisi kisi)
        {
            try
            {
                db.Kisiler.Add(kisi);
                db.SaveChanges();

                TempData["BasariliMesaj"] = "Ekleme İşlemi Başarıyla Gerçekleşti.";

            }
            catch (Exception)
            {

                TempData["HataliMesaj"] = "Hata Oluştu Lüften Tekrar Deneyiniz!";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenecek kayıt bulunamadı!";
                RedirectToAction("Index");
            }
            var model = new KisiGuncelleViewModel
            {
                Kisi = kisi,
                Sehirler=db.Sehirler.ToList()
            };

            ViewBag.Sehirler= new SelectList(db.Sehirler.ToList(),"Id","SehirAdi");
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(Kisi kisi)
        {
            var eskiKisi = db.Kisiler.Find(kisi.Id);
            if (eskiKisi==null)
            {
                TempData["HataliMesaj"] = "Güncellenecek kayıt bulunamadı!";
                return RedirectToAction("Index");

            }
            eskiKisi.Ad = kisi.Ad;
            eskiKisi.Soyad = kisi.Soyad;
            eskiKisi.EvTelefon = kisi.EvTelefon;
            eskiKisi.CepTelefon = kisi.CepTelefon;
            eskiKisi.IsTelefon = kisi.IsTelefon;
            eskiKisi.EmailAdres = kisi.EmailAdres;
            eskiKisi.Adres = kisi.Adres;
            eskiKisi.SehirId = kisi.SehirId;

            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kişi Bilgileri Başarıyla Güncellendi!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detay(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            var model = new DetayKisiViewModel
            {
                 Kisi = kisi,
                 Sehirler=db.Sehirler.ToList()
            };
            return View(model);
        }
        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kişi Veritabanından silinmiştir.";
            return RedirectToAction("Index");
        }
        public ActionResult MailGonder(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            return View(kisi);
        }

        [HttpPost]
        public ActionResult MailGonder(string MailAdres,string Baslik,string Mesaj)
        {
            try
            {
                var gonderimail = new MailAddress("alkaptan1991@gmail.com");
                var sifre = "alkaptan123+";
                var aliciMail = new MailAddress(MailAdres);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(gonderimail.Address, sifre)
                };
                using (var msg = new MailMessage(gonderimail, aliciMail)
                {
                    IsBodyHtml = true,
                    Subject=Baslik,
                    Body=Mesaj
                })
                {
                    smtp.Send(msg);
                }
                TempData["BasariliMesaj"] = "Mail Gönderme İşlemi Başarıyla Grçekleşti";
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                TempData["HataliMesaj"] = "Mail Gönderi İşleminde Hata Oluştu";
                return RedirectToAction("Index");
            }
        }
    }
}