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
    
    public partial class Entity
    {
        public Entity()
        {
            this.EntityLanguage = new HashSet<EntityLanguage>();
        }
    
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public int CountryCode { get; set; }
        public string EntityTypeName { get; set; }
        public double VertexLatitude { get; set; }
        public double VertexLongitude { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Attachment { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual EntityType EntityType { get; set; }
        public virtual Vertex Vertex { get; set; }
        public virtual ICollection<EntityLanguage> EntityLanguage { get; set; }
    }
}
