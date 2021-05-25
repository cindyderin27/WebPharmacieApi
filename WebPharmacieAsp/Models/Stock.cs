using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPharmacieAsp.Models
{
    public class Categorie
    {
        public Categorie()
        {
        }

        public int IdStock { get; set; }
        public int QteStock { get; set; }
        public double MontantTotal { get; set; }

        public ICollection<Medicament> Medicaments { get; set; }
    }
}