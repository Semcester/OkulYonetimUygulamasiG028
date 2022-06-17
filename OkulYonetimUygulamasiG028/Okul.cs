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
            SUBE:
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");

                string sube = Console.ReadLine().ToUpper();

                if (sube == "A")
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.A).ToList();

                    OgrenciListele(liste);

                }
                else if (sube == "B")
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.B).ToList();

                    OgrenciListele(liste);
                }
                else if (sube == "C")
                {
                    liste = this.Ogrenciler.Where(a => a.Sube == Ogrenci.SUBE.C).ToList();

                    OgrenciListele(liste);
                }
                else
                {
                    Console.WriteLine("Böyle bir şube yok. Lütfen tekrar seçim yapınız.");
                    goto SUBE;

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
                Console.Write("Listelemek istediğiniz il girin (Ankara): ");
                string il = Console.ReadLine().ToUpper();



                //sayi mi yazi mi kontrol'ü eklenecek




                liste = Ogrenciler.Where(a => a.Adres.Il == il).ToList();
                OgrenciListele(liste);


            }

            return liste;

        }

        public void OgrenciListele(List<Ogrenci> liste)//16.06.2020 15:30:00 Mert Anıl Deke , Enes Kırış
        {
            if (liste.Count == 0)
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
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(12) + item.Ad +" " + item.Soyad.PadRight(10));
            }

            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");



        }

    }
}
