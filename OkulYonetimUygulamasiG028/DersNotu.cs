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
       
    }
}
