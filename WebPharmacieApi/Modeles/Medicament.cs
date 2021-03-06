//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebPharmacieApi.Modeles
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicament()
        {
            this.Commandes = new HashSet<Commande>();
            this.Paniers = new HashSet<Panier>();
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
    
        public virtual Categorie Categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }
    }
}
