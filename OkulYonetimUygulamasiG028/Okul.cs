using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiG028
{
    class Okul
    {

        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumtarihi, Ogrenci.CINSIYET cinsiyet,Ogrenci.SUBE sube)
        {
            //Bütün kontroller yapılmış olmalı...

            Ogrenci o = new Ogrenci();
            o.No = no;
            o.Ad = ad;
            o.Soyad = soyad;
            //
            //
            //
            this.Ogrenciler.Add(o);
        }


        public void NotEkle(int no, string ders, int not)
        {
            //bu noya sahip bir öğrenci olduğundan ve verilerin doğruluğundan eminiz...
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            DersNotu dn = new DersNotu(ders, not);

            o.Notlar.Add(dn);
        }

        public void AdresEkle(int no, string il, string ilce, string mahalle)
        {
            //bu noya sahip bir öğrenci olduğundan ve verilerin doğruluğundan eminiz...
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            o.Adres.Il = il;
            o.Adres.Ilce = ilce;
            o.Adres.Mahalle = mahalle;

        }

        public void ButunOgrencileriListele() //Semih Senan 16.06.2022
        {
            Console.WriteLine();
            Console.WriteLine("1-Bütün Öğrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(5) + "Adı Soyadı".PadRight(20) + "Not Ort.".PadRight(10) + "Okuduğu Kitap Say.");
            Console.WriteLine("",41,"-");

        }


    }
}
