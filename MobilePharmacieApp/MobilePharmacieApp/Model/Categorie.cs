using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePharmacieApp.Model
{
    class Categorie
    {
        public string NomCategorie { get; set; }
        public List<Medicament> Medicaments { get; set; }
    }
}
