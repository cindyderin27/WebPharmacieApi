using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPharmacieAsp.Models
{
    public class Utilisateur
    {
        public Utilisateur()
        {
        }

        public int IdUtilisateur { get; set; }
        public string CodeUtilisateur { get; set; }
        public string NomUtilisateur { get; set; }
        public string Email { get; set; }
        public string MotPasse { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }
    }
}