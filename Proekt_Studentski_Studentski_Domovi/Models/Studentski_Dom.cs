//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proekt_Studentski_Studentski_Domovi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Studentski_Dom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Studentski_Dom()
        {
            this.Korisniks = new HashSet<Korisnik>();
            this.Sobas = new HashSet<Soba>();
        }
    
        public int SD_Id { get; set; }
        public string Ime_SD { get; set; }
        public string Adresa { get; set; }
        public Nullable<int> Broj_Spratovi { get; set; }
        public Nullable<int> Broj_Sobi { get; set; }
        public string Opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korisnik> Korisniks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Soba> Sobas { get; set; }
    }
}