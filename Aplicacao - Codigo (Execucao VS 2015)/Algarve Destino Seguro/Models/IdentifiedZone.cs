//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Algarve_Destino_Seguro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IdentifiedZone
    {
        public IdentifiedZone()
        {
            this.IdentifiedZoneSchedule = new HashSet<IdentifiedZoneSchedule>();
        }
    
        public string Name { get; set; }
        public double Radius { get; set; }
    
        public virtual Vertex Vertex { get; set; }
        public virtual ICollection<IdentifiedZoneSchedule> IdentifiedZoneSchedule { get; set; }
    }
}
