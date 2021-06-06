using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePharmacieApp.Model
{
    class Medicament
    {
        public string Nom { get; set; }
        public double PrixUnitaire { get; set; }
        public string Image { get; set; }

        public string ImageFullPath
        {
            get
            {
                return String.Format("http://orion-v-des1:8086/{0}",
                    Image.Substring(1));
            }

        }
    }

}
