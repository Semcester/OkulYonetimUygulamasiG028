using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiG028
{
    class DersNotu
    {

        public string DersAdi { get; set; }

        public float Not { get; set; }

        public DersNotu(string dersadi, int not)
        {

            this.DersAdi = dersadi;
            this.Not = not;
        
        }
        public void SahteVeri2()
        {
            DersNotu a = new DersNotu("matematik", 60);
            DersNotu a1 = new DersNotu("türkçe", 30);
            DersNotu a2 = new DersNotu("sosyal", 70);
            DersNotu a3 = new DersNotu("fen", 20);
            DersNotu a4 = new DersNotu("ingilizce", 50);
        }
    }
}
