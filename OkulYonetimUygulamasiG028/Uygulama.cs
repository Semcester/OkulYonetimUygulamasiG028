using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulYonetimSistemi_GoldenMade_son_ödev;

namespace OkulYonetimUygulamasiG028
{
    class Uygulama
    {
        public Okul Okul = new Okul();

        public void Calistir()
        {
            //Sahte Veri
            SahteVeriGir();
            //Menüyazdır
            Menu();
            //SwitchCase
            SecimAl();
            //gitinit
        }
        public void Menu() //Semih Senan 16.06.2022
        {
            Console.WriteLine();
            Console.WriteLine("------  Okul Yönetim Uygulamasi  -----");
            Console.WriteLine();
            Console.WriteLine("1-Bütün öğrencileri listele");
            Console.WriteLine("2-Şubeye göre öğrencileri listele");
            Console.WriteLine("3-Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4-Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5-İllere göre sıralayarak öğrencileri listele"); //(Alfabetik sıralama olacak )
            Console.WriteLine("6-Öğrencinin tüm notlarını listele"); //(Derse göre sıralayıp listelenecek)
            Console.WriteLine("7-Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8-Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9-Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10-Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11-Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12-Öğrencinin not ortalamasını gör"); //(Öğrenciye ait ortalama özelliği olacak, set özelliği olmayacak, get özelliği içinde hesaplanıp döndürülecek)
            Console.WriteLine("13-Şubenin not ortalamasını gör");
            Console.WriteLine("14-Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15-Öğrenci ekle");
            Console.WriteLine("16-Öğrenci güncelle"); //(yeni öğrenci yaratılmayacak, var olan öğrenci nesnesi üzerinden güncelleme yapılacak.)
            Console.WriteLine("17-Öğrenci sil");
            Console.WriteLine("18-Öğrencinin adresini gir"); //  (Öğrencinin adresi farklı bir class olacak )
            Console.WriteLine("19-Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20-Öğrencinin notunu gir"); // (Metot ile giriş yapılacak)
            Console.WriteLine();
            Console.WriteLine("Çıkış yapmak için “çıkış” yazıp “enter”a basın.");
            Console.WriteLine();


        }

        public void SecimAl() //Semih Senan 16.06.2022
        {
            while (true)
            {
                Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Okul.OgrenciListesiGetir("1");
                        break;
                    case "2":
                        Okul.OgrenciListesiGetir("2");
                        break;
                    case "3":
                        Okul.OgrenciListesiGetir("3");
                        break;
                    case "4":
                        Okul.OgrenciListesiGetir("4");
                        break;
                    case "5":
                        Okul.OgrenciListesiGetir("5");
                        break;
                    case "6":
                        Okul.OgrenciNotlariGoruntule();
                        break;
                    case "7":
                        OkunanKitaplar();
                        break;
                    case "8":
                        Okul.EnYuksekNotluBesOgrenci();  //"Okuldaki en yüksek notlu 5 öğrenciyi listele"
                        break;
                    case "9":
                        Okul.EnDusukUc();
                        break;
                    case "10":
                        Okul.OgrenciListesiGetir("10");
                        break;
                    case "11":
                        Okul.EnDusukUcSube();
                        break;
                    case "12":
                        OgrenciOrt();
                        break;
                    case "13":
                        SubeNotOrt();
                        break;
                    case "14":
                        Okul.OgrenciListesiGetir("14");
                        break;
                    case "15":
                        Okul.YeniOgrenci();
                        break;
                    case "16":
                        Okul.OgrenciGuncelle();
                        break;
                    case "17":
                        Okul.OgrenciSil();
                        break;
                    case "18":
                        Okul.OgrenciAdresi();
                        break;
                    case "19":
                        Console.WriteLine("Öğrencinin okuduğu kitabı gir");
                        break;
                    case "20":
                        NotGir();
                        break;
                    case "liste":
                        Menu();
                        break;
                    case "çıkış":
                        Console.WriteLine("Uygulamadan çıktınız...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Böyle bir seçim yok tekrar deneyin.");
                        break;
                }
            }
        }

        //1. ✓  Şubeye yanlış girilince yanlış girildi diyecek.... ✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓
        //2  ✓  cinsiyette sayı girilince hatalı giriş olacak....  ✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓
        //3.   5. metot düzenlenicek. ===Semih Senan'a aittir :D
        //4.  ✓  başharf metodu ==>>>>>>>> < >>  > < < > > > > > >  <=Y ✓✓✓✓✓✓✓✓✓✓✓✓✓✓✓
        //5.  ✓  öğrenicinin notu yoksa notu yok yazacak listelemeyecek 6 ==== ✓✓✓✓✓✓✓✓✓✓
        //6.     8. metot ve ORTALAMA KONTROL
        //7.     15. METOT düzenlenecek numara verirken sorun var 
        //8.    not gir düzenlenecek

        public void NotGir()
        {

            Console.WriteLine("20-Not Gir -----------------------------------------------");

            Ogrenci o = Okul.OgrenciNo();
            Okul.OgrenciAdiSubesi(o.No);
            string ders = AracGerec.YaziAl("Not eklemek istediğiniz ders: ");
            int adet = AracGerec.SayiAl("Eklemek istediginiz not adedi: ");
            int sayac = 0;
            do
            {
                sayac++;
               
                int not = AracGerec.SayiAl(sayac+" Notu Giriniz: ");
               
                Okul.NotEkle(o.No, ders, not);

            } while (sayac!=adet);
            Console.WriteLine();
            Console.WriteLine("Bilgiler Sisteme Girilmiştir.");
            AracGerec.MenuMesaji();

        }
        public void OgrenciOrt()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör " + "".PadRight(20, '-'));
            Ogrenci ogrenci = Okul.OgrenciNo();

            Console.WriteLine();
            Console.WriteLine("Öğrencinin Adı Soyadı :" + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.Sube);
            Console.WriteLine();

            Console.WriteLine("Öğrencini not ortalaması : " + ogrenci.Ortalama);


        }

        public void OkunanKitaplar() // 13:20 EKŞ
        {
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele " + "".PadRight(20, '-'));
            Ogrenci o = Okul.OgrenciNo();
            Okul.OgrenciAdiSubesi(o.No);

            List<string> kitaplar;
            kitaplar = o.Kitaplar;
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Öğrencinin okuduğu bir kitap yok.");
            }
            else
            {
                Console.WriteLine("Okuduğu Kitaplar");
                Console.WriteLine("".PadRight(10, '-'));
                foreach (var item in kitaplar)
                {
                    Console.WriteLine(item);
                }

            }
            AracGerec.MenuMesaji();


        }
        public void SubeNotOrt()//13
        {
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör " + "".PadRight(20, '-'));

            Ogrenci.SUBE sube = AracGerec.SubeAl("Bir şube seçin (A/B/C): ");

            if (sube == Ogrenci.SUBE.A)
            {
                double ort = Okul.Ogrenciler.Where(x => x.Sube == Ogrenci.SUBE.A).Average(x => x.Ortalama);
                Console.WriteLine("A şubesinin not ortalaması: " + ort);
            }
            else if (sube == Ogrenci.SUBE.B)
            {
                double ort = Okul.Ogrenciler.Where(x => x.Sube == Ogrenci.SUBE.B).Average(x => x.Ortalama);
                Console.WriteLine("B şubesinin not ortalaması: " + ort);
            }
            else if (sube == Ogrenci.SUBE.C)
            {
                double ort = Okul.Ogrenciler.Where(x => x.Sube == Ogrenci.SUBE.C).Average(x => x.Ortalama);
                Console.WriteLine("C şubesinin not ortalaması: " + ort);
            }



        }

        public void SahteVeriGir()
        {


            Okul.OgrenciEkle(1, "Aydın", "Kaya", new DateTime(2009, 7, 9), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.C);
            Okul.OgrenciEkle(2, "Yunus", "Emre", new DateTime(1975, 8, 27), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(3, "Ayşe", "Fatma", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.B);
            Okul.OgrenciEkle(41, "Ebru", "Demir", new DateTime(2000, 4, 6), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(4, "Murat", "Kurt", new DateTime(1987, 1, 7), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.C);
            Okul.OgrenciEkle(5, "Ayşe", "Fatma", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.B);
            Okul.OgrenciEkle(6, "Burak", "Tok", new DateTime(1990, 3, 27), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(7, "Hayriye", "Durak", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.B);
            Okul.OgrenciEkle(8, "Nadir", "Işık", new DateTime(2003, 2, 19), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(9, "Nadide", "Başak", new DateTime(1989, 3, 11), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.C);
            Okul.OgrenciEkle(10, "Bartu", "Özgün", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.B);
            Okul.AdresEkle(1, "Mersin", "Yenişehir", "Gül");
            Okul.AdresEkle(2, "Ankara", "Çankaya", "çıkmaz");
            Okul.AdresEkle(3, "İstanbul", "Kartal", "Gül");
            Okul.AdresEkle(41, "Trabzon", "Uzun Burun", "Gül");
            Okul.AdresEkle(4, "Zonguldak", "Kömür", "Maden");
            Okul.AdresEkle(5, "Ankara", "Çinçin", "dikkat");
            Okul.AdresEkle(6, "İzmir", "Buca", "Sarmaşık");
            Okul.AdresEkle(7, "İzmir", "Konak", "Atatürk");
            Okul.AdresEkle(8, "İstanbuk", "Beydağı", "nilüfer");
            Okul.AdresEkle(9, "Mersin", "Mezitli", "köy");
            Okul.AdresEkle(10, "Hakkari", "Çatışma", "kurşun");



        }

    }
}
