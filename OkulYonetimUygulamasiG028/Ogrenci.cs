using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiG028
{
    class Ogrenci
    {

        public int No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public SUBE Sube { get; set; }

        public CINSIYET Cinsiyet { get; set; }

        public DateTime DogumTarihi { get; set; }

        public float Ortalama
        {
            get
            {
                return this.Notlar.Average(x => x.Not);
            }

        }

        public Adres Adres = new Adres();

        public List<string> Kitaplar = new List<string>();

        public List<DersNotu> Notlar = new List<DersNotu>();
        

        
        public enum SUBE
        {

            Empty, A, B, C

        }

        public enum CINSIYET
        {

            Empty, Kiz, Erkek

        }

    }
}
