using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulYonetimUygulamasiG028;

namespace OkulYonetimSistemi_GoldenMade_son_ödev
{
    class AracGerec
    {

        static public Ogrenci.SUBE SubeAl(string mesaj)//şubeyi gir(a/b/c)
        {
        SUBE:
            string girdi = YaziAl(mesaj).ToUpper();

            switch (girdi)
            {

                case "A":
                    return Ogrenci.SUBE.A;
                case "B":
                    return Ogrenci.SUBE.B;
                case "C":
                    return Ogrenci.SUBE.C;

                default:
                    Console.WriteLine("Böyle bir şube yok tekrar deneyiniz.");
                    goto SUBE;

            }

        }
        static public Ogrenci.SUBE SubeGuncelle(string mesaj, Ogrenci ogrenci)//şubeyi gir(a/b/c)
        {
        SUBE:
            string girdi = YaziAl(mesaj).ToUpper();
            if( girdi == "")
            {
                return ogrenci.Sube;
            }

            switch (girdi)
            {

                case "A":
                    return Ogrenci.SUBE.A;
                case "B":
                    return Ogrenci.SUBE.B;
                case "C":
                    return Ogrenci.SUBE.C;

                default:
                    Console.WriteLine("Böyle bir şube yok tekrar deneyiniz.");
                    goto SUBE;

            }

        }
        static public bool SayiMi(string mesaj)//16 14 10 6 4 mert 
        {
            do
            {
                try
                {
                    if (int.TryParse(mesaj, out int sayi))
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
        static public bool HarfMi(string giris)//213a
        {
            do
            {
                try
                {
                    if (!int.TryParse(giris, out int sayi))
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
        static public int SayiAl(string giris)
        {
            do
            {
                try
                {

                    Console.Write(giris);
                    string kontrol = Console.ReadLine();

                    if (SayiMi(kontrol))
                    {
                        int.TryParse(kontrol, out int sayi);
                        return sayi;
                    }
                    HataMesaj();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            } while (true);
        }
        static public string YaziAl(string mesaj)
        {
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string yazi = BasHarfBuyut(Console.ReadLine()); // "Kontrol" "Yazı" ile değiştirildi... Karışıklık olmaması için...
                    if (HarfMi(yazi))
                    {

                        return yazi;

                    }
                    HataMesaj();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); 
                }

            } while (true);
        }
        static public string AdGuncelle(string mesaj, Ogrenci ogrenci)
        {
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string yazi = BasHarfBuyut(Console.ReadLine()); // "Kontrol" "Yazı" ile değiştirildi... Karışıklık olmaması için...

                    if( yazi == "")
                    {
                        return ogrenci.Ad;
                    }
                    if (HarfMi(yazi))
                    {

                        return yazi;

                    }
                    HataMesaj();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);
        }
        static public string SoyAdGuncelle(string mesaj, Ogrenci ogrenci)
        {
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string yazi = BasHarfBuyut(Console.ReadLine()); // "Kontrol" "Yazı" ile değiştirildi... Karışıklık olmaması için...

                    if (yazi == "")
                    {
                        return ogrenci.Soyad;
                    }
                    if (HarfMi(yazi))
                    {

                        return yazi;

                    }
                    HataMesaj();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);
        }
        static public DateTime TarihAl(string mesaj)
        {
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string dogum = Console.ReadLine();
                    if (DateTime.TryParse(dogum, out DateTime dogumTarihi))
                    {
                        return dogumTarihi;
                    }
                    HataMesaj();

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            } while (true);
        }
        static public DateTime TarihGuncelle(string mesaj, Ogrenci ogrenci)
        {
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string dogum = Console.ReadLine();

                    if(dogum == "")
                    {
                        return ogrenci.DogumTarihi;
                    }
                    if (DateTime.TryParse(dogum, out DateTime dogumTarihi))
                    {
                        return dogumTarihi;
                    }
                    HataMesaj();

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            } while (true);
        }
        public static Ogrenci.CINSIYET CinsiyetAl(string mesaj)//cinsiyeti giriniz(e/k)
        {
            while (true)
            {

                string cins = YaziAl(mesaj).ToUpper();
                switch (cins)
                {
                    case "K":
                        return Ogrenci.CINSIYET.Erkek;
                    case "E":
                        return Ogrenci.CINSIYET.Kiz;
                    default:
                        HataMesaj();
                        break;

                }

            }

        }
        public static Ogrenci.CINSIYET CinsiyetGuncelle(string mesaj, Ogrenci ogrenci)//cinsiyeti giriniz(e/k)
        {
            while (true)
            {

                string cins = YaziAl(mesaj).ToUpper();

                if(cins == "")
                {
                    
                    return ogrenci.Cinsiyet;
                }
                switch (cins)
                {
                    case "E":
                        return Ogrenci.CINSIYET.Erkek;
                    case "K":
                        return Ogrenci.CINSIYET.Kiz;
                    default:
                        HataMesaj();
                        break;

                }

            }

        }
        public static string BasHarfBuyut(string girdi)//mert 
        {
            string[] dizi = girdi.Split(' ');
            string cikanMetin = "";
            if (dizi != null || dizi.Length > 0)
            {
                
                for (int i = 0; i < dizi.Length; i++)// enes=0 mert=1 kiris2  deke3
                {
                    if (dizi[i] != "")
                    {
                        cikanMetin += dizi[i].Substring(0, 1).ToUpper() + dizi[i].Substring(1).ToLower() + " ";
                    }
                    
                }
                return cikanMetin.Trim();
            }
            return girdi.Substring(0, 1).ToUpper() + girdi.Substring(1).ToLower();
        }

        static public void HataMesaj()
        {
            Console.WriteLine("Hatalı Giriş Yaptınız. Tekrar Giriş Yapınız.");
        } // Her yere aynısını yazmak istemedim
        public static void MenuMesaji()
        {
            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");
            Console.WriteLine();
        }
    }
}
