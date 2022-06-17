using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemi_GoldenMade_son_ödev
{
    class AracGerec
    {
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
                    string kontrol = Console.ReadLine();
                    if (HarfMi(kontrol))
                    {

                        return kontrol;

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

        static void HataMesaj()
        {
            Console.WriteLine("Hatalı Giriş Yaptınız. Tekrar Giriş Yapınız.");
        } // Her yere aynısını yazmak istemedim




    }
}
