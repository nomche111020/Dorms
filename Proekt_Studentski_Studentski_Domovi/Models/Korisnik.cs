//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

namespace Proekt_Studentski_Studentski_Domovi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            this.Smetkas = new HashSet<Smetka>();
        }
    
        public int Id_Korisnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Godina_Na_Raganje { get; set; }
        public string Pol { get; set; }
        public Nullable<int> Godina_Na_Studii { get; set; }
        public Nullable<int> Korisnik_SD { get; set; }
        public Nullable<int> Korisnik_Soba { get; set; }

        public int ID_Studentski_Dom { get; set; }
        public int ID_Soba{ get; set; }
        [ForeignKey("ID_Studentski_Dom")]
        public virtual Studentski_Dom Studentski_Dom { get; set; }
        [ForeignKey("ID_Soba")]
        public virtual Soba Soba { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Smetka> Smetkas { get; set; }
    }
}
