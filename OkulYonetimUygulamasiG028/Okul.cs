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
            catch (Exception e)
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
        public void EnDusukUcSube() // SM 11 numaralı başlık-17.06.2022  ---------- String olarak alınan şube, şube al metotu ile değiştirldi.
        {
            List<Ogrenci> liste = this.Ogrenciler;
            Console.WriteLine();
            Console.WriteLine("11-Subedeki en düsük notlu 3 ögrenciyi listele" + "".PadRight(15, '-'));
            Console.WriteLine();
        SUBE:

            Ogrenci.SUBE sube = AracGerec.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            if (sube == Ogrenci.SUBE.A)
            {
                liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.A).OrderBy(a => a.Ortalama).Take(3).ToList();

            }
            else if (sube == Ogrenci.SUBE.B)
            {
                liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.B).OrderBy(a => a.Ortalama).Take(3).ToList();

            }
            else if (sube == Ogrenci.SUBE.C)
            {
                liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.C).OrderBy(a => a.Ortalama).Take(3).ToList();

            }
            else
            {
                Console.WriteLine("Hatalı Giriş Yaptınız. Tekrar Giriş Yapınız.");
                goto SUBE;
            }
            OgrenciListele(liste);
        }


        public List<Ogrenci> OgrenciListesiGetir(string a) //16.06.2020 15:30:00 Mert Anıl Deke , Enes Kırış
        {
            // parametreden aldığımız durum veri tipinde aldığımız veri ile okuldaki öğrenci durumlarına göre listeleme gerçekleştiriyoruz.
            List<Ogrenci> liste = this.Ogrenciler;

            if (a == "1")
            {
                Console.WriteLine();
                Console.WriteLine("1-Bütün Öğrencileri Listele" + "".PadRight(15, '-'));

                liste = liste.OrderBy(a => a.No).ToList();

                OgrenciListele(liste);
            }
            else if (a == "2")
            {
                Console.WriteLine();
                Console.WriteLine("2-Şubeye Göre Öğrencileri Listele" + "".PadRight(15, '-'));

                Ogrenci.SUBE sube = AracGerec.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");



                if (sube == Ogrenci.SUBE.A)
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.A).OrderBy(b=> b.No).ToList();

                }
                else if (sube == Ogrenci.SUBE.B)
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.B).OrderBy(b => b.No).ToList();

                }
                else if (sube == Ogrenci.SUBE.C)
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.C).OrderBy(b => b.No).ToList();

                }
                OgrenciListele(liste);
            }
            else if (a == "3")
            {
                Console.WriteLine();
                Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele" + "".PadRight(15, '-'));
            CINSIYET:
                Console.Write("Listelemek istediğiniz cinsiyeti girin (E/K): ");
                string cinsiyet = Console.ReadLine().ToUpper();
                if (cinsiyet == "E")
                {
                    liste = Ogrenciler.Where(a => a.Cinsiyet == Ogrenci.CINSIYET.Erkek).OrderBy(b => b.No).ToList();


                }
                else if (cinsiyet == "K")
                {
                    liste = Ogrenciler.Where(a => a.Cinsiyet == Ogrenci.CINSIYET.Kiz).OrderBy(b => b.No).ToList();

                }
                else
                {
                    Console.WriteLine("Böyle bir cinsiyet yok. Lütfen tekrar seçim yapınız.");
                    goto CINSIYET;
                }
                OgrenciListele(liste);
            }

            // Buraya 4. Seçenek Gelmeli
            else if (a == "4") //4. Geldiiii by MERTOOO
            {

                Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele ".PadRight(15, '-'));
                DateTime dogum = AracGerec.TarihAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");
                liste = Ogrenciler.Where(x => x.DogumTarihi > dogum).OrderBy(x => x.No).ToList();
                OgrenciListele(liste);


            }

            else if (a == "5") //Semih Senan 19.06.2022 01:55 İllere Göre Listele
            {

                Console.WriteLine();
                Console.WriteLine("5-Illere Göre Ögrencileri Listele" + "".PadRight(15, '-'));
                Console.WriteLine();

                liste = this.Ogrenciler.Where(a => a.Adres.Il != null).ToList();
                IllereGoreOgrenciListele(liste);


            }

            else if (a == "10") //Ortalama çözüldü -Merto
            {
                Console.WriteLine();
                Console.WriteLine("10-Şubedeki en yüksek notlu 5 öğrenciyi listele " + "".PadRight(15, '-'));
                Console.WriteLine();
                Ogrenci.SUBE sube = AracGerec.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                Console.WriteLine();
                liste = Ogrenciler.Where(x => x.Sube == sube).OrderByDescending(x => x.Ortalama).Take(5).ToList();
                OgrenciListele(liste);
            }

            else if (a == "14")
            {
                Console.WriteLine();
                Console.WriteLine("14 - Ögrencinin okudugu son kitabı listele " + "".PadRight(15, '-'));
                Ogrenci og = OgrenciNo();
                if (og.Kitaplar.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Listelenecek Kitap Yok.");

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + og.Ad + " " + og.Soyad);
                    Console.WriteLine("Ögrencinin Şubesi: " + og.Sube);
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Okudugu Son Kitap ");
                    Console.WriteLine("".PadRight(30, '-'));
                    Console.WriteLine(og.Kitaplar[og.Kitaplar.Count - 1].ToString());
                }

                AracGerec.MenuMesaji();

            }
            return liste;

        }

        public void OgrenciAdresi() // SM 18.06.2022	
        {
            Adres a = new Adres();
            Console.WriteLine();
            Console.WriteLine("18-Ögrencinin adresini gir " + "".PadRight(20, '-'));
        TEKRARNUMARASECIM:
            int ogrenciNoGirdi = AracGerec.SayiAl("Öğrencinin numarası: ");
            Ogrenci test = null;
            foreach (Ogrenci item in Ogrenciler)
            {
                if (ogrenciNoGirdi == item.No)
                {
                    test = item;
                }
            }
            if (test != null)
            {
                OgrenciAdiSubesi(ogrenciNoGirdi);
            }
            else
            {
                Console.WriteLine("Bu numarada bir öğrenci yok. Tekrar deneyin.");
                goto TEKRARNUMARASECIM;
            }
            string il = AracGerec.YaziAl("İl: ");
            string ilce = AracGerec.YaziAl("İlçe: ");
            string mahalle = AracGerec.YaziAl("Mahalle: ");
            AdresEkle(ogrenciNoGirdi, il, ilce, mahalle);
            Console.WriteLine("");
            Console.WriteLine("Bilgileri Sisteme Girilmiştir...");
            Console.WriteLine("");
            AracGerec.MenuMesaji();
        }

        public void OgrenciNotlariGoruntule()//6 METOT ÇALIŞIYOR FAKAT İLK ÖNCE EKLEME YAPILMASI GEREKİYOR
        {

            Console.WriteLine();
            Console.WriteLine("6-Ögrencinin notlarını görüntüle" + "".PadRight(30, '-'));
            List<Ogrenci> liste = this.Ogrenciler;
            Ogrenci o = OgrenciNo();
            liste = Ogrenciler.Where(x => x.No == o.No).ToList();
            OgrenciAdiSubesi(o.No);
            if (o.Notlar.Count != 0)
            {
                Console.WriteLine("Ders Adı ".PadRight(14) + "Notu".PadRight(12));
                Console.WriteLine("".PadRight(20, '-'));
                for (int i = 0; i < o.Notlar.Count; i++)
                {
                    Console.WriteLine(o.Notlar[i].DersAdi.PadRight(14) + o.Notlar[i].Not);
                }
            }
            else
            {
                Console.WriteLine("Öğrencinin Girilmiş Notu Yok.");
            }

            AracGerec.MenuMesaji();




        }

        public void OgrenciListele(List<Ogrenci> liste)//16.06.2020 15:30:00 Mert Anıl Deke , Enes Kırış
        {
            if (liste.Count == 0 || liste == null)
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(12) + "Adı Soyadı".PadRight(20) + "Not Ort.".PadRight(16) + "Okudugu Kitap Say.");
            Console.WriteLine("".PadRight(90, '-'));

            foreach (var item in liste)
            {
                string adSoyad = item.Ad + " " + item.Soyad;
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(12) + adSoyad.PadRight(20) + Math.Round(item.Ortalama, 1).ToString().PadRight(20) + item.Kitaplar.Count());
            }

            AracGerec.MenuMesaji();

        }
        public void IllereGoreOgrenciListele(List<Ogrenci> liste)//18.06.2020 00:33:00 Semih Senan
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Öğrenci adres bilgisi yok.");
                Console.WriteLine();
                return;
            }
            liste = liste.OrderBy(b => b.Adres.Il).ToList();


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(20) + "Sehir".PadRight(15) + "Semt".PadRight(14) + "Mahalle");
            Console.WriteLine("".PadRight(90, '-'));


            foreach (Ogrenci item in liste)
            {
                string adSoyad = item.Ad + " " + item.Soyad;


                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + adSoyad.PadRight(20) + item.Adres.Il.ToString().PadRight(15) + item.Adres.Ilce.PadRight(15) + item.Adres.Mahalle);

            }

            Console.WriteLine();

            AracGerec.MenuMesaji();

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
                    break;
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

            Ogrenci a = OgrenciNo();
            OgrenciAdiSubesi(a.No);

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
                    break;
                default:
                    Console.WriteLine("Hatalı giriş yaptınız");
                    goto SECIM;
            }
            AracGerec.MenuMesaji();
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
            Ogrenci g = Ogrenciler.Where(x => x.No == ogrenciNo).FirstOrDefault();
            if (g != null)
            {
                string ogrenciAdi = AracGerec.AdGuncelle("Öğrencinin adı: ",g);
                string ogrenciSoyadi = AracGerec.SoyAdGuncelle("Öğrencinin soyadı: ",g);
                DateTime dogumTarihi = AracGerec.TarihGuncelle("Öğrencinin doğum tarihi: ", g);
                Ogrenci.CINSIYET eOrk = AracGerec.CinsiyetGuncelle("Öğrencinin cinsiyeti (E/K): ", g);                
                Ogrenci.SUBE sube = AracGerec.SubeGuncelle("Öğrencinin Şubesi (A/B/C): ",g);

                if(ogrenciAdi == "")
                {
                    g.Ad = g.Ad;
                }else if(ogrenciSoyadi == "")
                {
                    g.Soyad = g.Soyad;
                }else if(dogumTarihi != DateTime.MinValue)
                {
                    g.DogumTarihi = g.DogumTarihi;
                }else if(eOrk == 0)
                {
                    g.Cinsiyet = g.Cinsiyet;
                }else if(sube == 0)
                {
                    g.Sube = g.Sube;
                }


                g.Ad = ogrenciAdi;
                g.Soyad = ogrenciSoyadi;
                g.DogumTarihi = dogumTarihi;
                g.Cinsiyet = eOrk;
                g.Sube = sube;
                Console.WriteLine();
                Console.WriteLine("Öğrenci Güncellendi");
                AracGerec.MenuMesaji();
            }
            else
            {
                Console.WriteLine("Bu numaraya ait bir öğrenci yok Tekrar Deneyin."); goto TEKRAR;
            }


        }
        public void KitapGir(int no, string kitapAdi)
        {
            Ogrenci o = this.Ogrenciler.Where(x => x.No == no).FirstOrDefault();

            o.Kitaplar.Add(kitapAdi);

        }
        public void KitapEkle()
        {
            Console.WriteLine();
            Console.WriteLine("19-Öğrencinin okuduğu kitabı gir" + "".PadRight(20, '-'));
            Ogrenci ogr = OgrenciNo();
            OgrenciAdiSubesi(ogr.No);

            Console.Write("Eklenecek Kitabin Adı: ");
            string kitap = AracGerec.BasHarfBuyut(Console.ReadLine());

            KitapGir(ogr.No, kitap);
            Console.WriteLine();
            Console.WriteLine("Bilgiler sisteme girilmistir.");
            
            AracGerec.MenuMesaji();


        }
        public void YeniOgrenci() // SM 16.06.2022
        {
            Console.WriteLine();
            Console.WriteLine("15-Öğrenci Ekle" + "".PadRight(15, '-'));
            int ogrenciNo = NoKontrol(AracGerec.SayiAl("Öğrencinin numarası: "));

            string ogrenciAdi = AracGerec.YaziAl("Öğrencinin adı: ");
            string ogrenciSoyadi = AracGerec.YaziAl("Öğrencinin soyadı: ");

            DateTime dogumTarihi = AracGerec.TarihAl("Öğrencinin doğum tarihi: ");

            Ogrenci.CINSIYET cins = AracGerec.CinsiyetAl("Öğrencinin cinsiyeti (E/K): ");
            Ogrenci.SUBE sube = AracGerec.SubeAl("Öğrencinin Şubesi (A/B/C): ");
            Console.WriteLine();
            OgrenciEkle(ogrenciNo, ogrenciAdi, ogrenciSoyadi, dogumTarihi, cins, sube);
            //11 numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.
            Console.WriteLine(ogrenciNo + " Nolu Öğrenci sisteme basarılı bir sekilde eklenmistir. ");
            AracGerec.MenuMesaji();
        }

    }
}
