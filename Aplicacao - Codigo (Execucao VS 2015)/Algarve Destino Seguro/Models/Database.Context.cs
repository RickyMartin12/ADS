﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ADSEntities : DbContext
    {
        public ADSEntities()
            : base("name=ADSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Theme> Theme { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<SubTopic> SubTopic { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<ThemeContent> ThemeContent { get; set; }
        public virtual DbSet<TopicContent> TopicContent { get; set; }
        public virtual DbSet<SubTopicContent> SubTopicContent { get; set; }
        public virtual DbSet<Phrase> Phrase { get; set; }
        public virtual DbSet<EntityType> EntityType { get; set; }
        public virtual DbSet<EntityTypeLanguage> EntityTypeLanguage { get; set; }
        public virtual DbSet<Vertex> Vertex { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryLanguage> CountryLanguage { get; set; }
        public virtual DbSet<EntityLanguage> EntityLanguage { get; set; }
        public virtual DbSet<IdentifiedZone> IdentifiedZone { get; set; }
        public virtual DbSet<IdentifiedZoneType> IdentifiedZoneType { get; set; }
        public virtual DbSet<IdentifiedZoneSchedule> IdentifiedZoneSchedule { get; set; }
        public virtual DbSet<CommunicationType> CommunicationType { get; set; }
        public virtual DbSet<CommunicationState> CommunicationState { get; set; }
        public virtual DbSet<Communication> Communication { get; set; }
    }
}
