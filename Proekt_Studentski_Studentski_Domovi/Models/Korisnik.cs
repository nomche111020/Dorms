﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            this.Smetkas = new HashSet<Smetka>();
        }
    
        public int Id_Korisnik { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string Ime { get; set; }
        [Required]
        [Display(Name = "Презиме")]
        public string Prezime { get; set; }
        [Required]
        [Display(Name = "Адреса")]
        public string Adresa { get; set; }
        [Required]
        [Display(Name = "Емаил")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Дата на раѓање")]
        public Nullable<System.DateTime> Godina_Na_Raganje { get; set; }
        [Required]
        [Display(Name = "Пол")]
        public string Pol { get; set; }
        [Required]
        [Display(Name = "Година на студии")]
        public Nullable<int> Godina_Na_Studii { get; set; }
        [Required]
        [Display(Name = "Студентски дом")]
        public Nullable<int> Korisnik_SD { get; set; }
        [Required]
        [Display(Name = "Соба")]
        public Nullable<int> Korisnik_Soba { get; set; }
    
        public virtual Studentski_Dom Studentski_Dom { get; set; }
        public virtual Soba Soba { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Smetka> Smetkas { get; set; }
    }
}