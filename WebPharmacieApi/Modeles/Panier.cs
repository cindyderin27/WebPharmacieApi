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
    
    public partial class Panier
    {
        public int IdPanier { get; set; }
        public int Qte { get; set; }
        public int IdMedicament { get; set; }
        public string PanierId { get; set; }
    
        public virtual Medicament Medicament { get; set; }
    }
}