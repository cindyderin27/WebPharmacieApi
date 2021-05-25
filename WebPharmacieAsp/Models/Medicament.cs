using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPharmacieAsp.Models
{
    public class Medicament
    {
        public Medicament()
        {
        }

        public int IdMedicament { get; set; }
        public string Reference { get; set; }
        public string Nom { get; set; }
        public System.DateTime DateFabrication { get; set; }
        public System.DateTime DatePeremption { get; set; }
        public string Composition { get; set; }
        public double PrixUnitaire { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdStock { get; set; }
        public int IdCategorie { get; set; }

        public  IEnumerable<SelectListItem> Categories { get; set; }
        public Categorie Categorie{ get; set; }

        //  public virtual ICollection<Commande> Commandes { get; set; }
        public virtual Categorie Stock { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        //public virtual ICollection<Panier> Paniers { get; set; }
    }
}