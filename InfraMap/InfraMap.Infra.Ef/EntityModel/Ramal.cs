//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfraMap.Infra.Ef.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ramal
    {
        public Ramal()
        {
            this.Mesa = new HashSet<Mesa>();
        }
    
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
    
        public virtual ICollection<Mesa> Mesa { get; set; }
    }
}
