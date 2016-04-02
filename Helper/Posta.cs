using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Helper
{
   public class Posta
   {
       SmtpClient gonderici = new SmtpClient();
       string adres;

       public Posta()
       {
           gonderici.Credentials = new NetworkCredential("bemardeneme@gmail.com", "bemar123456");
               
           gonderici.EnableSsl = true;
           gonderici.Host = "smtp.gmail.com";
           gonderici.Port = 587;
           adres = "bemardeneme@gmail.com";
       }
       public Posta(string mail,string sifre,string servername,int serverport,bool ssl)
       {
           gonderici.Credentials = new NetworkCredential(mail,sifre);
           gonderici.EnableSsl = ssl;
           gonderici.Host = servername;
           gonderici.Port = serverport;
           adres = mail;
       }



       public string MailGonder(string kime, string konu, string mesaj)
       {
           string sonuc = "";

           try
           {
               MailMessage eposta = new MailMessage();
               eposta.Body = mesaj;
               eposta.Subject = konu;
               eposta.To.Add(kime);
               eposta.From = new MailAddress(adres);
               eposta.IsBodyHtml = true;
               gonderici.Send(eposta);
               sonuc = "Eposta İletildi";
           }
           catch (Exception)
           {
               sonuc = "Mail gönderirken hata yaşandı";
           }
           return sonuc;
       }
       
   }
}
