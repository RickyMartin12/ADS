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
    
    public partial class Vertex
    {
        public Vertex()
        {
            this.Entity = new HashSet<Entity>();
        }
    
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    
        public virtual ICollection<Entity> Entity { get; set; }
        public virtual IdentifiedZone IdentifiedZone { get; set; }
    }
}