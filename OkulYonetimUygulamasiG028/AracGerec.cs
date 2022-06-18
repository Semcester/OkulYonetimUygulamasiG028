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

        static public Ogrenci.SUBE SubeAl(string mesaj)
        {
        SUBE:
            Console.Write(mesaj);
            string secim = Console.ReadLine().ToUpper();
            switch (secim)
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
            foreach (char item in mesaj)
            {
                if (char.IsNumber(item))
                {
                    return true;
                }
            }
            return false;
        }
        static public bool HarfMi(string giris)
        {
            foreach (char item in giris)
            {
                if (!char.IsNumber(item))
                {
                    return true;
                }
            }
            return false;
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
                    string yazi = Console.ReadLine(); // "Kontrol" "Yazı" ile değiştirildi... Karışıklık olmaması için...
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

        public bool OgrenciBul(int no)
        {
            while (true)
            {

                List<Ogrenci> ogrenci = new List<Ogrenci>();

                Ogrenci yeni = ogrenci.Where(x => x.No == no).FirstOrDefault();
                if (yeni != null)
                {
                    return true;
                }
                Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");

            }


        }
        //static public Ogrenci.SUBE SubeAl(string mesaj)
        public static Ogrenci.CINSIYET CinsiyetAl(string mesaj)
        {
            while (true)
            {

                Console.Write(mesaj);
                string cins = Console.ReadLine().ToUpper();
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






        static void HataMesaj()
        {
            Console.WriteLine("Hatalı Giriş Yaptınız. Tekrar Giriş Yapınız.");
        } // Her yere aynısını yazmak istemedim




    }
}
