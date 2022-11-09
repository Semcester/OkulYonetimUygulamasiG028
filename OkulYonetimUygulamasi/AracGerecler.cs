using System;
using System.Collections.Generic;
using System.Text;

namespace OkulYonetimUygulamasi
{
    class AracGerecler
    {


        static public int SayiAl(string mesaj)
        {
            int sayi;

            do
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);

        }



        static public string YaziAl(string yazi, bool gerekli)
        {
            int sayi;

            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    Console.WriteLine("Hatalı islem tekrar girin.");
                }
                else if (gerekli && string.IsNullOrEmpty(giris))
                {
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                }
                else
                {
                    return giris;
                }
            } while (true);

        }
        static public DateTime TarihAl(string yazi)
        {
            DateTime tarihx;
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (DateTime.TryParse(giris, out tarihx))
                {
                    return tarihx;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }
            } while (true);
        }


        static public DateTime TarihAlGuncelle(string yazi)
        {
            DateTime tarih;
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (DateTime.TryParse(giris, out tarih))
                {
                    return tarih;
                }
                else
                {
                    return DateTime.MinValue;

                }

            } while (true);
        }

        static public CINSIYET KizMiErkekMi(string yazi, bool gerekli)
        {
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();

                if (!gerekli && string.IsNullOrEmpty(giris))
                {
                    return CINSIYET.Empty;
                }

                if (giris.ToUpper() == "K")
                {
                    return CINSIYET.Kiz;
                }
                else if (giris.ToUpper() == "E")
                {
                    return CINSIYET.Erkek;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);
        }

        static public SUBE SubeAl(string yazi, bool gerekli)
        {
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();

                if (!gerekli && string.IsNullOrEmpty(giris))
                {
                    return SUBE.Empty;
                }

                if (giris.ToUpper() == "A")
                {
                    return SUBE.A;
                }
                else if (giris.ToUpper() == "B")
                {
                    return SUBE.B;
                }
                else if (giris.ToUpper() == "C")
                {
                    return SUBE.C;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);
        }

        static public string DersGir()
        {


            while (true)
            {
                Console.Write("Not eklemek istediğiniz dersi giriniz: ");
                return Console.ReadLine().ToUpper();


            }

        }


    }
}
