//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgramskoInzenjerstvo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PosiljkaStanje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PosiljkaStanje()
        {
            this.PosiljkaKupovinas = new HashSet<PosiljkaKupovina>();
            this.PosiljkaNarudzbas = new HashSet<PosiljkaNarudzba>();
        }
    
        public int IDPosiljkaStanje { get; set; }
        public string Stanje { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PosiljkaKupovina> PosiljkaKupovinas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PosiljkaNarudzba> PosiljkaNarudzbas { get; set; }
    }
}