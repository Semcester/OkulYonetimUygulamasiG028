using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulYonetimSistemi_GoldenMade_son_ödev;

namespace OkulYonetimUygulamasiG028
{
    class Okul
    {

        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        
        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumtarihi, Ogrenci.CINSIYET cinsiyet, Ogrenci.SUBE sube)
        {
            //Bütün kontroller yapılmış olmalı...


            Ogrenci o = new Ogrenci();
            o.No = no;
            o.Ad = ad;
            o.Soyad = soyad;
            o.DogumTarihi = dogumtarihi;
            o.Cinsiyet = cinsiyet;
            o.Sube = sube;

            this.Ogrenciler.Add(o);
        }
        public void OgrenciOrt()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör " + "".PadRight(20, '-'));
            Ogrenci ogrenci = OgrenciNo();

            Console.WriteLine();
            Console.WriteLine("Öğrencinin Adı Soyadı :" + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.Sube);
            Console.WriteLine();

            Console.WriteLine("Öğrencini not ortalaması : " + ogrenci.Ortalama);


        }
        public void SubeNotOrt()
        {
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör " + "".PadRight(20, '-'));

            Ogrenci.SUBE sube = AracGerec.SubeAl("Bir şube seçin (A/B/C): ");

            if (sube == Ogrenci.SUBE.A)
            {
                double ort = this.Ogrenciler.Where(x => x.Sube == Ogrenci.SUBE.A).Average(x => x.Ortalama);
                Console.WriteLine("A şubesinin not ortalaması: " + ort);
            }
            else if (sube == Ogrenci.SUBE.B)
            {
                double ort = this.Ogrenciler.Where(x => x.Sube == Ogrenci.SUBE.B).Average(x => x.Ortalama);
                Console.WriteLine("B şubesinin not ortalaması: " + ort);
            }
            else if (sube == Ogrenci.SUBE.C)
            {
                double ort = this.Ogrenciler.Where(x => x.Sube == Ogrenci.SUBE.C).Average(x => x.Ortalama);
                Console.WriteLine("C şubesinin not ortalaması: " + ort);
            }



        }
        public void EnYuksekNotluBesOgrenci() // Semih Senan 18.06.2022 00:40
        {
            Console.WriteLine();
            Console.WriteLine("8-Okuldaki en yüksek notlu 5 öğrenciyi listele " + "".PadRight(20, '-'));
            Console.WriteLine();
            List<Ogrenci> EnYuksekNotluBesOgrenci = Ogrenciler.OrderByDescending(a => a.Ortalama).Take(5).ToList();

            try
            {
                if (EnYuksekNotluBesOgrenci.Count == 0)
                {
                    throw new Exception("Notu olan öğrenci yok");
                }
                else
                {
                    OgrenciListele(EnYuksekNotluBesOgrenci);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            
        }
        public void EnDusukUc() // SM 9 numaralı başlık-17.06.2022
        {
            Console.WriteLine();
            Console.WriteLine("9-Okuldaki en düşük notlu 3 öğrenciyi listele " + "".PadRight(20, '-')); // Başlık eklendi. Not olmaması durumu eklendi.
            Console.WriteLine();
            List<Ogrenci> enDusukUc = Ogrenciler.OrderBy(a => a.Ortalama).Take(3).ToList();

            try
            {
                if (enDusukUc.Count == 0)
                {
                    throw new Exception("Notu olan öğrenci yok");
                }
                else
                {
                    OgrenciListele(enDusukUc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            

        }
        public void EnDusukUcSube() // SM 11 numaralı başlık-17.06.2022
        {
            List<Ogrenci> liste = this.Ogrenciler;

            Console.WriteLine("3-Şubedeki en başarısız 3 öğrenciyi listele" + "".PadRight(15, '-'));
        SUBE:
            Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            string sube = Console.ReadLine().ToUpper();
            if (sube == "A")
            {
                liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.A).OrderBy(a => a.Ortalama).ToList();
                OgrenciListele(liste);

            }
            else if (sube == "B")
            {
                liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.B).OrderBy(a => a.Ortalama).ToList();
                OgrenciListele(liste);
            }
            else if (sube == "C")
            {
                liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.C).OrderBy(a => a.Ortalama).ToList();
                OgrenciListele(liste);
            }
            else
            {
                Console.WriteLine("Hatalı Giriş Yaptınız. Tekrar Giriş Yapınız.");
                goto SUBE;
            }

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
        public List<Ogrenci> OgrenciListesiGetir(string a) //16.06.2020 15:30:00 Mert Anıl Deke , Enes Kırış
        {
            // parametreden aldığımız durum veri tipinde aldığımız veri ile okuldaki öğrenci durumlarına göre listeleme gerçekleştiriyoruz.
            List<Ogrenci> liste = this.Ogrenciler;

            if (a == "1")
            {
                OgrenciListele(liste);
            }
            else if (a == "2")
            {
                Console.WriteLine("2-Şubeye Göre Öğrencileri Listele" + "".PadRight(15, '-'));

                Ogrenci.SUBE sube = AracGerec.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");

                if (sube == Ogrenci.SUBE.A)
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.A).ToList();

                    OgrenciListele(liste);

                }
                else if (sube == Ogrenci.SUBE.B)
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.B).ToList();

                    OgrenciListele(liste);
                }
                else if (sube == Ogrenci.SUBE.C)
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.C).ToList();

                    OgrenciListele(liste);
                }

            }
            else if (a == "3")
            {
                Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele" + "".PadRight(15, '-'));
            CINSIYET:
                Console.Write("Listelemek istediğiniz cinsiyeti girin (E/K): ");
                string cinsiyet = Console.ReadLine().ToUpper();
                if (cinsiyet == "E")
                {
                    liste = Ogrenciler.Where(a => a.Cinsiyet == Ogrenci.CINSIYET.Erkek).ToList();
                    OgrenciListele(liste);

                }
                else if (cinsiyet == "K")
                {
                    liste = Ogrenciler.Where(a => a.Cinsiyet == Ogrenci.CINSIYET.Kiz).ToList();
                    OgrenciListele(liste);
                }
                else
                {
                    Console.WriteLine("Böyle bir cinsiyet yok. Lütfen tekrar seçim yapınız.");
                    goto CINSIYET;
                }
            }

            // Buraya 4. Seçenek Gelmeli
            else if (a == "4") //4. Geldiiii by MERTOOO
            {

                Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele ".PadRight(15, '-'));
                DateTime dogum = AracGerec.TarihAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");
                liste = Ogrenciler.Where(x => x.DogumTarihi > dogum).OrderBy(x => x.No).ToList();
                OgrenciListele(liste);


            }


            else if (a == "5") //Semih Senan 17.06.2022 00:00
            {
                //İllere Göre Listele


                Console.WriteLine();
                Console.WriteLine("5-Illere Göre Ögrencileri Listele" + "".PadRight(15, '-'));
                Console.WriteLine();
                string il = AracGerec.YaziAl("Listelemek istediğiniz il girin (Ankara): ");

                liste = Ogrenciler.OrderBy(a => a.Adres.Il == il.ToUpper()).ToList(); //WHERE YAZIYORDU ORDERBY YAPTIM -MERTO
                IllereGoreOgrenciListele(liste);


            }

            else if (a == "10") //Ortalama HATASI YÜZÜNDEN ADA GÖRE SIRALADIM X.AD DEĞİŞECEK 
            {
                Ogrenci.SUBE sube = AracGerec.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                Console.WriteLine();
                liste = Ogrenciler.Where(x => x.Sube == sube).OrderByDescending(x => x.Ad).Take(5).ToList();
                OgrenciListele(liste);
            }

            else if (a == "14")
            {
                Console.WriteLine();
                Console.WriteLine("14 - Ögrencinin okudugu son kitabı listele " + "".PadRight(15, '-'));
            OGRENCIGIR:
                int no = AracGerec.SayiAl("Öğrencinin Numarası: ");
                Ogrenci og = Ogrenciler.Where(x => x.No == no).FirstOrDefault();
                if (og == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    goto OGRENCIGIR;
                }
                Console.WriteLine();
                Console.WriteLine("Ögrencinin Okudugu Son Kitap ");
                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine(og.Kitaplar[og.Kitaplar.Count - 1].ToString());
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");
                Console.WriteLine();

            }
            return liste;

        }

        public void OgrenciNotlariGoruntule()//6 METOT ÇALIŞIYOR FAKAT İLK ÖNCE EKLEME YAPILMASI GEREKİYOR
        {

            Console.WriteLine();
            Console.WriteLine("6-Ögrencinin notlarını görüntüle" + "".PadRight(30, '-'));
            List<Ogrenci> liste = this.Ogrenciler;
            Ogrenci o = OgrenciNo();
            liste = Ogrenciler.Where(x => x.No == o.No).ToList();
            OgrenciAdiSubesi(o.No);
            Console.WriteLine("Ders Adı ".PadRight(14) + "Notu".PadRight(12));
            Console.WriteLine("".PadRight(20, '-'));
            for (int i = 0; i < o.Notlar.Count; i++)
            {

                Console.WriteLine(o.Notlar[i].DersAdi.PadRight(14)+ o.Notlar[i].Not);

            }

            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");
            Console.WriteLine();
        }
       
        public void OgrenciListele(List<Ogrenci> liste)//16.06.2020 15:30:00 Mert Anıl Deke , Enes Kırış
        {
            if (liste.Count == 0 || liste == null)
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(12) + "Adı Soyadı".PadRight(14) + "Not Ort.".PadRight(10) +
                    "Okudugu Kitap Say");
            Console.WriteLine("".PadRight(70, '-'));

            foreach (var item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(12) + item.Ad + " " + item.Soyad.PadRight(10) /*+ item.Ortalama.ToString().PadRight(10)*/);
            }

            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");

        }
        public void IllereGoreOgrenciListele(List<Ogrenci> liste)//18.06.2020 00:33:00 Semih Senan
        {
            if (liste.Count == 0 || liste == null)
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(20) + "Sehir".PadRight(15) +
                    "Semt");
            Console.WriteLine("".PadRight(70, '-'));

            foreach (var item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(12) + item.Ad + " " + item.Soyad.PadRight(10) + item.Adres.Il.ToString().PadRight(10) + item.Adres.Ilce.PadRight(10));
            }

            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");

        }
        public Ogrenci OgrenciNo()//enes kırış
        {
            //99
        NO:
            int no = AracGerec.SayiAl("Öğrencinin numarası: ");//99
            Ogrenci ogrenci = null;

            foreach (var item in this.Ogrenciler)
            {
                if (no == item.No)
                {
                    ogrenci = item;
                }
            }

            if (ogrenci == null)
            {
                Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin."); goto NO;
            }
            return ogrenci;


        }
        public void OgrenciAdiSubesi(int numara)
        {

            Ogrenci o = this.Ogrenciler.Where(x => x.No == numara).FirstOrDefault();
            Console.WriteLine();
            Console.WriteLine("Öğrencinin Adı Soyadı: " + o.Ad + " " + o.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + o.Sube);
            Console.WriteLine();

        }
        public void OgrenciSil() // Semih Senan 18.06.2022
        {
            Console.WriteLine();
            Console.WriteLine("17-Ögrenci sil " + "".PadRight(20, '-'));
            Console.WriteLine();

            Ogrenci a = OgrenciNo();

            Console.WriteLine("Ögrencinin Adı Soyadı: "+ a.Ad + " " + a.Soyad);
            Console.WriteLine("Ögrencinin Subesi: " + a.Sube);
            Console.WriteLine();
            SECIM:
            string secim = AracGerec.YaziAl("Ögrenciyi silmek istediginize emin misiniz (E/H): ");

            switch (secim.ToUpper())
            {
                case "E":
                    Ogrenciler.Remove(a);
                    Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");
                    Console.WriteLine();
                    break;
                case "H":
                    Console.WriteLine("Öğrenci silinmedi.");
                    return;
                default:
                    Console.WriteLine("Hatalı giriş yaptınız");
                    goto SECIM;
            }
        }
        public int NoKontrol(int sayi) //SM 16.06.2022
        {
            Ogrenci a = null;

            foreach (Ogrenci item in Ogrenciler)
            {
                if (item.No == sayi)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                while (true)
                {
                YUKARI:
                    foreach (Ogrenci item in Ogrenciler)
                    {
                        if (item.No == sayi)
                        {
                            sayi += 1;
                            goto YUKARI;
                        }
                    }
                    Console.WriteLine("Numara mevcut bir öğrenciye ait olduğu için sıradaki boş numara atanmıştır: " + sayi);
                    return sayi;
                }
            }
            else
            {
                return sayi;
            }
        }
        public void OgrenciGuncelle()
        {

            Console.WriteLine("16-Öğrenci Güncelle" + "".PadRight(15, '-'));
        TEKRAR:
            int ogrenciNo = AracGerec.SayiAl("Öğrencinin numarası: ");
            Ogrenci g = Ogrenciler.Where(x=>x.No == ogrenciNo).FirstOrDefault();
            if (g != null)
            {
                string ogrenciAdi = AracGerec.YaziAl("Öğrencinin adı: ");
                string ogrenciSoyadi = AracGerec.YaziAl("Öğrencinin soyadı: ");
                DateTime dogumTarihi = AracGerec.TarihAl("Öğrencinin doğun tarihi: ");
                Ogrenci.CINSIYET eOrk = AracGerec.CinsiyetAl("Öğrencinin cinsiyeti (E/K): ");
                Ogrenci.SUBE sube = AracGerec.SubeAl("Öğrencinin Şubesi (A/B/C): ");
                g.Ad = ogrenciAdi;
                g.Soyad = ogrenciSoyadi;
                g.DogumTarihi = dogumTarihi;
                g.Cinsiyet = eOrk;
                g.Sube = sube;
                Console.WriteLine();
                Console.WriteLine("Öğrenci Güncellendi");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Bu numaraya ait bir öğrenci yok Tekrar Deneyin."); goto TEKRAR;
            }


        }

        public void YeniOgrenci() // SM 16.06.2022
        {
            Console.WriteLine("15-Öğrenci Ekle" + "".PadRight(15, '-'));
            int ogrenciNo = NoKontrol(AracGerec.SayiAl("Öğrencinin numarası: "));
            string ogrenciAdi = AracGerec.YaziAl("Öğrencinin adı: ");
            string ogrenciSoyadi = AracGerec.YaziAl("Öğrencinin soyadı: ");
            DateTime dogumTarihi = AracGerec.TarihAl("Öğrencinin doğun tarihi: ");

            Ogrenci.CINSIYET cinsiyet;
            Ogrenci.SUBE eklenecekSube;


            Console.Write("Öğrencinin cinsiyeti (E/K)");

            while (true)
            {
                string secim = Console.ReadLine().ToUpper();

                if (secim == "E")
                {
                    cinsiyet = Ogrenci.CINSIYET.Erkek;
                    break;
                }
                else if (secim == "K")
                {
                    cinsiyet = Ogrenci.CINSIYET.Kiz;
                    break;
                }
                else
                {
                    Console.WriteLine("E veya K olarak giriş yapın");
                }

            }

            Console.Write("Öğrencinin Şubesi (A/B/C)");

            while (true)
            {
                string sube = Console.ReadLine().ToUpper();

                if (sube == "A")
                {
                    eklenecekSube = Ogrenci.SUBE.A;
                    break;

                }
                else if (sube == "B")
                {
                    eklenecekSube = Ogrenci.SUBE.B;
                    break;
                }
                else if (sube == "C")
                {
                    eklenecekSube = Ogrenci.SUBE.C;
                    break;
                }
                else
                {
                    Console.WriteLine("A,B veya C olarak giriş yapın.");
                }
            }
            OgrenciEkle(ogrenciNo, ogrenciAdi, ogrenciSoyadi, dogumTarihi, cinsiyet, eklenecekSube);
        }

    }
}
