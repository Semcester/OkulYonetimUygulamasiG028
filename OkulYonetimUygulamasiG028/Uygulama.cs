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
                        Okul.OgrenciListesiGetir("1"); //enes
                        break;
                    case "2":
                        Okul.OgrenciListesiGetir("2");
                        break;
                    case "3":
                        Okul.OgrenciListesiGetir("3"); //EKŞ 19:46
                        break;
                    case "4":
                        Console.WriteLine("Şu tarihten sonra doğan öğrencileri listele");
                        break;
                    case "5":
                        Okul.OgrenciListesiGetir("5"); ;
                        break;
                    case "6":
                        Console.WriteLine("Öğrencinin tüm notlarını listele");
                        break;
                    case "7":
                        Console.WriteLine("Öğrencinin okuduğu kitapları listele");
                        break;
                    case "8":
                        Console.WriteLine("Okuldaki en yüksek notlu 5 öğrenciyi listele");
                        break;
                    case "9":
                        Console.WriteLine("Okuldaki en düşük notlu 3 öğrenciyi listele");
                        break;
                    case "10":
                        Console.WriteLine("Şubedeki en yüksek notlu 5 öğrenciyi listele");
                        break;
                    case "11":
                        Console.WriteLine("Şubedeki en düşük notlu 3 öğrenciyi listele");
                        break;
                    case "12":
                        Console.WriteLine("Öğrencinin not ortalamasını gör");
                        break;
                    case "13":
                        Console.WriteLine("Şubenin not ortalamasını gör");
                        break;
                    case "14":
                        Console.WriteLine("Öğrencinin okuduğu son kitabı gör");
                        break;
                    case "15":
                        Console.WriteLine("Öğrenci ekle");
                        break;
                    case "16":
                        Console.WriteLine("Öğrenci güncelle");
                        break;
                    case "17":
                        Console.WriteLine("Öğrenci sil");
                        break;
                    case "18":
                        Console.WriteLine("Öğrencinin adresini gir");
                        break;
                    case "19":
                        Console.WriteLine("Öğrencinin okuduğu kitabı gir");
                        break;
                    case "20":
                        Console.WriteLine("Öğrencinin notunu gir");
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
        public void NotGir()
        {

            Console.WriteLine("20-Not Gir -----------------------------------------------");

            Console.Write("Öğrencinin Numarası: ");
            
            int no = AracGerec.SayiAl("Öğrencinin numarasını girin."); //Sorun çözüldü :D
            
            //sayı al methodu...

            Console.WriteLine("Not eklemek istediğiniz ders: ");
            //yazı al...
            string ders = Console.ReadLine();
            Console.WriteLine("Eklemek istediğiniz not adedi...");
            int adet = int.Parse(Console.ReadLine());

            for (int i = 1; i <= adet; i++)
            {
                Console.Write(i + ". Notu Girin: ");
                int not = int.Parse(Console.ReadLine());

                Okul.NotEkle(no, ders, not);
            }

        }

        public void SahteVeriGir()
        {

            Okul.OgrenciEkle(20, "Aydın", "Kaya", new DateTime(2009, 7, 9), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.C);
            Okul.OgrenciEkle(20, "Yunus", "Emre", new DateTime(1975, 8, 27), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(20, "Ayşe", "Fatma", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.B);
            Okul.OgrenciEkle(20, "Ebru", "Demir", new DateTime(2000, 4, 6), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(20, "Murat", "Kurt", new DateTime(1987, 1, 7), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.C);
            Okul.OgrenciEkle(20, "Ayşe", "Fatma", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.B);
            Okul.OgrenciEkle(20, "Burak", "Tok", new DateTime(1990, 3, 27), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(20, "Hayriye", "Durak", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.B);
            Okul.OgrenciEkle(20, "Nadir", "Işık", new DateTime(2003, 2, 19), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Okul.OgrenciEkle(20, "Nadide", "Başak", new DateTime(1989, 3, 11), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.C);
            Okul.OgrenciEkle(20, "Bartu", "Özgün", new DateTime(2008, 4, 4), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.B);

        }

    }
}
