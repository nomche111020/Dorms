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
    
    public partial class Smetka
    {
        public int Id_Smetka { get; set; }
        public Nullable<int> Smetka_Soba_Broj { get; set; }
        public Nullable<int> Smetka_Student { get; set; }
        public Nullable<int> Suma { get; set; }
    
        public virtual Korisnik Korisnik { get; set; }
        public virtual Soba Soba { get; set; }
    }
}
